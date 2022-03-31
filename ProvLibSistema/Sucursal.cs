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
                    var sql_1 =@"SELECT eSuc.auto, eSuc.codigo, eSuc.nombre, 
                                    eSucExt.es_activo as estatus, eSuc.estatus_facturar_mayor as estatusFactMayor, 
                                    eDep.nombre as nombreDeposito, eGrupo.nombre as nombreGrupo
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
                                    eGrupo.nombre as nombreGrupo
                                    from empresa_sucursal as eSuc
                                    join empresa_sucursal_ext as eSucExt on eSucExt.auto_sucursal=eSuc.auto
                                    join empresa_grupo as eGrupo on eGrupo.auto=eSuc.autoEmpresaGrupo ";
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
                        var sql_2 = @"INSERT INTO empresa_sucursal_ext (
                                        auto_sucursal, es_activo)
                                        VALUES (@xp1, '1')";
                        var r3 = cnn.Database.ExecuteSqlCommand(sql_2, xp1);
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

    }

}