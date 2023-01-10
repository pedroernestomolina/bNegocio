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
        public DtoLib.ResultadoLista<DtoLibSistema.Sucursal.Lista.Ficha> 
            Sucursal_GetLista(DtoLibSistema.Sucursal.Lista.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibSistema.Sucursal.Lista.Ficha>();
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var p1= new MySql.Data.MySqlClient.MySqlParameter();
                    var sql_1 = @"SELECT eSuc.auto, eSuc.codigo, eSuc.nombre, 
                                    eSucExt.es_activo as estatus, eSuc.estatus_facturar_mayor as estatusFactMayor, 
                                    eSucExt.estatus_fact_credito as estatusVentaCredito,
                                    eDep.nombre as nombreDeposito, eGrupo.nombre as nombreGrupo,
                                    eSucExt.habilita_surtido_pos as estatusPosVentaSurtido,
                                    eSucExt.habilita_vuelto_divisa_pos as estatusPosVueltoDivisa 
                                    from empresa_sucursal as eSuc
                                    join empresa_sucursal_ext as eSucExt on eSucExt.auto_sucursal=eSuc.auto
                                    join empresa_grupo as eGrupo on eGrupo.auto=eSuc.autoEmpresaGrupo
                                    left join empresa_depositos as eDep on eDep.auto=eSuc.autodepositoPrincipal ";
                    var sql_2 =" where 1=1 ";
                    if (filtro.autoGrupo != "") 
                    {
                        p1.ParameterName="@p1";
                        p1.Value=filtro.autoGrupo;
                        sql_2+= " and eSuc.autoEmpresaGrupo=@p1 ";
                    }
                    var sql= sql_1+sql_2;
                    var lst=cnn.Database.SqlQuery<DtoLibSistema.Sucursal.Lista.Ficha>(sql,p1).ToList();
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
        public DtoLib.ResultadoEntidad<DtoLibSistema.Sucursal.Entidad.Ficha> 
            Sucursal_GetFicha(string auto)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibSistema.Sucursal.Entidad.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", auto);
                    var sql_1 = @"SELECT eSuc.auto, eSuc.codigo, eSuc.nombre, eSuc.autoEmpresaGrupo as autoGrupo, 
                                    eSuc.autoDepositoPrincipal as autoDepositoPrincipal,
                                    eSucExt.es_activo as estatus, eSuc.estatus_facturar_mayor as estatusFactMayor,
                                    eSucExt.estatus_fact_credito as estatusVentaCredito,
                                    eGrupo.nombre as nombreGrupo, eDep.nombre as nombreDepositoAsignado,
                                    eSucExt.habilita_surtido_pos as estatusPosVentaSurtido,
                                    eSucExt.habilita_vuelto_divisa_pos as estatusPosVueltoDivisa
                                    from empresa_sucursal as eSuc
                                    join empresa_sucursal_ext as eSucExt on eSucExt.auto_sucursal=eSuc.auto
                                    join empresa_grupo as eGrupo on eGrupo.auto=eSuc.autoEmpresaGrupo 
                                    left join empresa_depositos as eDep on eDep.auto=eSuc.autodepositoPrincipal ";
                    var sql_2 = " where eSuc.auto=@p1 ";
                    var sql = sql_1 + sql_2;
                    var ent = cnn.Database.SqlQuery<DtoLibSistema.Sucursal.Entidad.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] SUCURSAL NO ENCONTRADO";
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
            Sucursal_Agregar(DtoLibSistema.Sucursal.Agregar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoAuto();
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var sql = "update sistema_contadores set a_empresa_sucursal=a_empresa_sucursal+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        var aEmpresaSucursal = cnn.Database.SqlQuery<int>("select a_empresa_sucursal from sistema_contadores").FirstOrDefault();
                        var autoEmpresaSucursal = aEmpresaSucursal.ToString().Trim().PadLeft(10, '0');


                        var cnt = cnn.empresa_sucursal.Count()+1;
                        if (cnt > MaxSucursalesPermitidas)
                        {
                            result.Mensaje = "MAXIMO SUCURSALES PERMITIDO ALCANZADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }

                        var sCnt = cnt.ToString("X").Trim().PadLeft(2, '0');
                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", autoEmpresaSucursal);
                        var p2 = new MySql.Data.MySqlClient.MySqlParameter("@p2", "");
                        var p3 = new MySql.Data.MySqlClient.MySqlParameter("@p3", ficha.autoGrupo);
                        var p4 = new MySql.Data.MySqlClient.MySqlParameter("@p4", sCnt);
                        var p5 = new MySql.Data.MySqlClient.MySqlParameter("@p5", ficha.nombre);
                        var p6 = new MySql.Data.MySqlClient.MySqlParameter("@p6", ficha.estatusFactMayor);
                        var sql_1 = @"INSERT INTO empresa_sucursal (
                                        auto, autoDepositoPrincipal, autoEmpresaGrupo, codigo, nombre, estatus_facturar_mayor)
                                        VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
                        var r2 = cnn.Database.ExecuteSqlCommand(sql_1, p1, p2, p3, p4, p5, p6);
                        if (r2 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL REGISTRAR SUCURSAL";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }

                        var xp1 = new MySql.Data.MySqlClient.MySqlParameter("@xp1", autoEmpresaSucursal);
                        var xp2 = new MySql.Data.MySqlClient.MySqlParameter("@xp2", ficha.estatusVentaCredito);
                        var xp3 = new MySql.Data.MySqlClient.MySqlParameter("@xp3", ficha.estatusPosVentaSurtido);
                        var xp4 = new MySql.Data.MySqlClient.MySqlParameter("@xp4", ficha.estatusPosVueltoDivisa);
                        var sql_2 = @"INSERT INTO empresa_sucursal_ext (
                                        auto_sucursal, 
                                        es_activo, 
                                        estatus_fact_credito,
                                        habilita_surtido_pos,
                                        habilita_vuelto_divisa_pos,
                                        modo_factura_pos,
                                        habilita_modulo_gastos_pos)
                                        VALUES (@xp1, '1', @xp2, @xp3, @xp4, 'D', '0')";
                        var r3 = cnn.Database.ExecuteSqlCommand(sql_2, xp1, xp2, xp3, xp4);
                        if (r3 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL REGISTRAR SUCURSAL_EXT";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();

                        ts.Complete();
                        result.Auto = autoEmpresaSucursal;
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
            Sucursal_Editar(DtoLibSistema.Sucursal.Editar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoAuto();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = cnn.empresa_sucursal.Find(ficha.auto);
                        if (ent == null) 
                        {
                            result.Mensaje = "[ ID ] SUCURSAL NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        ent.autoEmpresaGrupo=ficha.autoGrupo;
                        ent.nombre = ficha.nombre;
                        ent.estatus_facturar_mayor = ficha.estatusFactMayor;
                        cnn.SaveChanges();

                        var entExt = cnn.empresa_sucursal_ext.Find(ficha.auto);
                        entExt.estatus_fact_credito = ficha.estatusVentaCredito;
                        entExt.habilita_surtido_pos = ficha.estatusPosVentaSurtido;
                        entExt.habilita_vuelto_divisa_pos = ficha.estatusPosVueltoDivisa;
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
            Sucursal_AsignarDepositoPrincipal(DtoLibSistema.Sucursal.AsignarDepositoPrincipal.Ficha ficha)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = cnn.empresa_sucursal.Find(ficha.auto);
                        if (ent == null)
                        {
                            result.Mensaje = "[ ID ] SUCURSAL NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        var entExt = cnn.empresa_sucursal_ext.Find(ficha.auto);
                        if (entExt == null)
                        {
                            result.Mensaje = "[ ID ] SUCURSAL_EXT NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        if (entExt.es_activo == "0") 
                        {
                            result.Mensaje = "ESTATUS SUCURSAL: INACTIVA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        var entDepExt = cnn.empresa_depositos_ext.Find(ficha.autoDepositoPrincipal);
                        if (entDepExt.es_activo == "0")
                        {
                            result.Mensaje = "ESTATUS DEPOSITO : INACTIVA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        ent.autoDepositoPrincipal = ficha.autoDepositoPrincipal;
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
            Sucursal_QuitarDepositoPrincipal(string autoSuc)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = cnn.empresa_sucursal.Find(autoSuc);
                        if (ent == null)
                        {
                            result.Mensaje = "[ ID ] SUCURSAL NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        ent.autoDepositoPrincipal = "";
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
            Sucursal_Activar(string autoSuc)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var entExt = cnn.empresa_sucursal_ext.Find(autoSuc);
                        if (entExt == null)
                        {
                            result.Mensaje = "[ ID ] SUCURSAL_EXT NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        if (entExt.es_activo == "1")
                        {
                            result.Mensaje = "SUCURSAL ESTATUS: ACTIVA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        entExt.es_activo="1";
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
            Sucursal_Inactivar(string autoSuc)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var entExt = cnn.empresa_sucursal_ext.Find(autoSuc);
                        if (entExt == null)
                        {
                            result.Mensaje = "[ ID ] SUCURSAL_EXT NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        if (entExt.es_activo == "0")
                        {
                            result.Mensaje = "SUCURSAL ESTATUS: INACTIVA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        if (entExt.empresa_sucursal.autoDepositoPrincipal != "")
                        {
                            result.Mensaje = "DEPOSITO PRINCIPAL ASIGNADO A SUCURSAL";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        var cnt = cnn.empresa_depositos.Where(w => w.codigo_sucursal == entExt.empresa_sucursal.codigo).Count();
                        if (cnt > 0) 
                        {
                            result.Mensaje = "DEPOSITOS ASIGNADO A SUCURSAL";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        entExt.es_activo = "0";
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