using LibEntitySistema;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace ProvLibSistema
{

    public partial class Provider : ILibSistema.IProvider
    {

        public DtoLib.ResultadoLista<DtoLibSistema.Deposito.Lista.Ficha> 
            Deposito_GetLista(DtoLibSistema.Deposito.Lista.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibSistema.Deposito.Lista.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var sql_1 = @"SELECT ed.auto, ed.codigo, ed.nombre, 
                                edExt.es_activo as estatus,
                                eSuc.nombre as nombreSucursal  
                                FROM empresa_depositos as ed 
                                join empresa_depositos_ext as edExt on ed.auto=edExt.auto_deposito 
                                join empresa_sucursal as eSuc on eSuc.codigo= ed.codigo_sucursal
                                where 1=1";
                    var sql = sql_1;
                    var lst = cnn.Database.SqlQuery<DtoLibSistema.Deposito.Lista.Ficha>(sql).ToList();
                    result.Lista = lst;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Deposito.Entidad.Ficha> 
            Deposito_GetFicha(string auto)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibSistema.Deposito.Entidad.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1",auto);
                    var sql_1 = @"SELECT ed.auto, ed.codigo, ed.nombre, 
                                edExt.es_activo as estatus,
                                eSuc.nombre as nombreSucursal, eSuc.codigo as codigoSucursal, eSuc.auto as autoSucursal  
                                FROM empresa_depositos as ed 
                                join empresa_depositos_ext as edExt on ed.auto=edExt.auto_deposito 
                                join empresa_sucursal as eSuc on eSuc.codigo= ed.codigo_sucursal
                                where ed.auto=@p1";
                    var sql = sql_1;
                    var ent = cnn.Database.SqlQuery<DtoLibSistema.Deposito.Entidad.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] DEPOSITO NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    result.Entidad = ent;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.ResultadoAuto 
            Deposito_Agregar(DtoLibSistema.Deposito.Agregar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoAuto();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var entSuc = cnn.empresa_sucursal_ext.Find(ficha.autoSucursal);
                        if (entSuc == null) 
                        {
                            result.Mensaje = "SUCURSAL NO ENCONTRADA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        if (entSuc.es_activo  == "0")
                        {
                            result.Mensaje = "ESTATUS SUCURSAL INACTIVA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        if (entSuc.empresa_sucursal.codigo!= ficha.codigoSucursal)
                        {
                            result.Mensaje = "ESTATUS SUCURSAL CODIGO INCORRECTO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }

                        var sql = "update sistema_contadores set a_empresa_depositos=a_empresa_depositos+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        var aEmpresaDeposito = cnn.Database.SqlQuery<int>("select a_empresa_depositos from sistema_contadores").FirstOrDefault();
                        var autoEmpresaDeposito = aEmpresaDeposito.ToString().Trim().PadLeft(10, '0');

                        var xCnt = cnn.empresa_depositos.Count() + 1;
                        if (xCnt > MaxDepositoPermitidas)
                        {
                            result.Mensaje = "MAXIMO DEPOSITOS PERMITIDO ALCANZADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }

                        var cnt = aEmpresaDeposito;
                        var sCnt = cnt.ToString().Trim().PadLeft(2, '0');
                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", autoEmpresaDeposito);
                        var p2 = new MySql.Data.MySqlClient.MySqlParameter("@p2", ficha.nombre);
                        var p3 = new MySql.Data.MySqlClient.MySqlParameter("@p3", sCnt);
                        var p4 = new MySql.Data.MySqlClient.MySqlParameter("@p4", ficha.codigoSucursal);
                        var sql_1 = @"INSERT INTO empresa_depositos 
                                    (auto, nombre, codigo, codigo_sucursal)
                                    VALUES (@p1, @p2, @p3, @p4)";
                        var r2 = cnn.Database.ExecuteSqlCommand(sql_1, p1, p2, p3, p4);
                        if (r2 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL REGISTRAR DEPOSITO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();

                        var xp1 = new MySql.Data.MySqlClient.MySqlParameter("@xp1", autoEmpresaDeposito);
                        var sql_2 = @"INSERT INTO empresa_depositos_ext 
                                    (auto_deposito, es_predeterminado, es_activo)
                                    VALUES (@xp1, '', '1')";
                        var r3 = cnn.Database.ExecuteSqlCommand(sql_2, xp1);
                        if (r3 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL REGISTRAR DEPOSITO_EXT";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        ts.Complete();
                        result.Auto = autoEmpresaDeposito;
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (DbUpdateException ex)
            {
                result.Mensaje = Helpers.ENTITY_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.Resultado 
            Deposito_Editar(DtoLibSistema.Deposito.Editar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var entSuc = cnn.empresa_sucursal_ext.Find(ficha.autoSucursal);
                        if (entSuc == null)
                        {
                            result.Mensaje = "SUCURSAL NO ENCONTRADA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        if (entSuc.es_activo == "0")
                        {
                            result.Mensaje = "ESTATUS SUCURSAL INACTIVA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        if (entSuc.empresa_sucursal.codigo != ficha.codigoSucursal)
                        {
                            result.Mensaje = "ESTATUS SUCURSAL CODIGO INCORRECTO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        var ent = cnn.empresa_depositos.Find(ficha.auto);
                        if (ent == null)
                        {
                            result.Mensaje = "[ ID ] DEPOSITO NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        ent.nombre = ficha.nombre;
                        ent.codigo_sucursal = ficha.codigoSucursal;
                        cnn.SaveChanges();
                        ts.Complete();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (DbUpdateException ex)
            {
                result.Mensaje = Helpers.ENTITY_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.Resultado 
            Deposito_Activar(string idDep)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = cnn.empresa_depositos_ext.Find(idDep);
                        if (ent == null)
                        {
                            result.Mensaje = "DEPOSITO NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        };
                        if (ent.es_activo.Trim().ToUpper() == "1")
                        {
                            result.Mensaje = "DEPOSITO YA ACTIVO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        ent.es_activo = "1";
                        cnn.SaveChanges();

                        ts.Complete();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (DbUpdateException ex)
            {
                result.Mensaje = Helpers.ENTITY_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.Resultado 
            Deposito_Inactivar(string idDep)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = cnn.empresa_depositos_ext.Find(idDep);
                        if (ent==null)
                        {
                            result.Mensaje = "[ ID ] DEPOSITO NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        };
                        if (ent.es_activo.Trim().ToUpper() == "0")
                        {
                            result.Mensaje = "DEPOSITO YA INACTIVO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@autoDeposito", idDep);
                        var sql = @"SELECT count(*) AS cnt
                                    FROM productos_deposito
                                    where auto_deposito=@autoDeposito and fisica<>0";
                        var cnt=cnn.Database.SqlQuery<int?>(sql, p1).FirstOrDefault();
                        if (cnt.HasValue)
                        {
                            if (cnt.Value > 0)
                            {
                                result.Mensaje = "MERCANCIA EXISTENTE EN DEPOSITO";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                        }
                        ent.es_activo = "0";
                        cnn.SaveChanges();

                        ts.Complete();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (DbUpdateException ex)
            {
                result.Mensaje = Helpers.ENTITY_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }

    }

}