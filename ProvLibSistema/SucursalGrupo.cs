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

        public DtoLib.ResultadoLista<DtoLibSistema.GrupoSucursal.Lista.Ficha> 
            SucursalGrupo_GetLista()
        {
            var result = new DtoLib.ResultadoLista<DtoLibSistema.GrupoSucursal.Lista.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var sql = @"select eg.auto, eg.nombre, egExt.estatus, ePrecio.descrpcion as refPrecio
                                from empresa_grupo as eg 
                                join empresa_grupo_ext as egExt on eg.auto=egExt.auto_EmpresaGrupo
                                join empresa_hnd_precios as ePrecio on ePrecio.id=egExt.idEmpresaHndPrecio";
                    var lst = cnn.Database.SqlQuery<DtoLibSistema.GrupoSucursal.Lista.Ficha>(sql).ToList();
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
        public DtoLib.ResultadoEntidad<DtoLibSistema.GrupoSucursal.Entidad.Ficha> 
            SucursalGrupo_GetById(string id)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibSistema.GrupoSucursal.Entidad.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@id", id);
                    var sql = @"select eg.auto, eg.nombre, egExt.estatus, ePrecio.id as idPrecio, ePrecio.descrpcion as refPrecio
                                from empresa_grupo as eg 
                                join empresa_grupo_ext as egExt on eg.auto=egExt.auto_EmpresaGrupo
                                join empresa_hnd_precios as ePrecio on ePrecio.id=egExt.idEmpresaHndPrecio
                                where eg.auto=@id";
                    var ent = cnn.Database.SqlQuery<DtoLibSistema.GrupoSucursal.Entidad.Ficha>(sql,p1).FirstOrDefault();
                    if (ent == null) 
                    {
                        result.Mensaje = "[ ID ] ENTIDAD GRUPO SUCURSAL NO ENCONTRADO";
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
            SucursalGrupo_Agregar(DtoLibSistema.GrupoSucursal.Agregar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoAuto();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var sql = "update sistema_contadores set a_empresa_grupo=a_empresa_grupo+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        var aEmpresaGrupo = cnn.Database.SqlQuery<int>("select a_empresa_grupo from sistema_contadores").FirstOrDefault();
                        var autoEmpresaGrupo = aEmpresaGrupo.ToString().Trim().PadLeft(10, '0');

                        var xp1 = new MySql.Data.MySqlClient.MySqlParameter("@xp1", autoEmpresaGrupo);
                        var xp2 = new MySql.Data.MySqlClient.MySqlParameter("@xp2", ficha.nombre);
                        var xp3 = new MySql.Data.MySqlClient.MySqlParameter("@xp3", "");
                        var sql_1 = @"INSERT INTO empresa_grupo (
                                    auto, nombre, idPrecio) 
                                    values(@xp1, @xp2, @xp3)";
                        var r2 = cnn.Database.ExecuteSqlCommand(sql_1, xp1, xp2, xp3);
                        if (r2 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL REGISTRAR GRUPO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();

                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", autoEmpresaGrupo);
                        var p2 = new MySql.Data.MySqlClient.MySqlParameter("@p2", ficha.idPrecio);
                        var p3 = new MySql.Data.MySqlClient.MySqlParameter("@p3", "1");
                        var sql_2 = @"INSERT INTO empresa_grupo_ext (
                                    auto_empresaGrupo, idEmpresaHndPrecio, estatus) 
                                    values(@p1, @p2, @p3)";
                        var r3 = cnn.Database.ExecuteSqlCommand(sql_2, p1, p2, p3);
                        if (r3 == 0) 
                        {
                            result.Mensaje = "PROBLEMA AL REGISTRAR GRUPO_EXT";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();

                        ts.Complete();
                        result.Auto = autoEmpresaGrupo;
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
            SucursalGrupo_Editar(DtoLibSistema.GrupoSucursal.Editar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = cnn.empresa_grupo.Find(ficha.auto);
                        if (ent == null) 
                        {
                            result.Mensaje = "[ ID ] ENTIDAD GRUPO SUCURSAL NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        };
                        ent.nombre = ficha.nombre;
                        cnn.SaveChanges();

                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", ficha.idPrecio);
                        var p2 = new MySql.Data.MySqlClient.MySqlParameter("@p2", ficha.auto);
                        var sql = @"update empresa_grupo_ext set idEmpresaHndPrecio=@p1 
                                    where auto_empresaGrupo=@p2";
                        var r1= cnn.Database.ExecuteSqlCommand(sql, p1, p2);
                        if (r1 == 0) 
                        {
                            result.Mensaje = "[ ID ] ENTIDAD GRUPO_EXT SUCURSAL NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
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
            SucursalGrupo_Eliminar(string id)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {

                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", id);
                        var sql = @"delete from empresa_grupo_ext 
                                    where auto_empresaGrupo=@p1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql,p1);
                        if (r1 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ELIMINAR REGISTRO GRUPO_EXT";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();

                        var p2 = new MySql.Data.MySqlClient.MySqlParameter("@p2", id);
                        sql = @"delete from empresa_grupo 
                                    where auto=@p2";
                        var r2 = cnn.Database.ExecuteSqlCommand(sql, p2);
                        if (r2 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ELIMINAR REGISTRO GRUPO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
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