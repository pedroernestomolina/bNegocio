using LibEntitySistema;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace ProvLibSistema
{
    
    public class Helpers
    {

        static public string 
            MYSQL_VerificaError(MySql.Data.MySqlClient.MySqlException ex) 
        {
            var msg = "";
            if (ex.Number == 1452)
            {
                msg= "FALLO EN CLAVE FORANEA" + Environment.NewLine + ex.Message;
                return msg;
            }
            if (ex.Number == 1451)
            {
                msg= "REGISTRO CONTIENE DATA RELACIONADA" + Environment.NewLine + ex.Message;
                return msg;
            }
            if (ex.Number == 1062)
            {
                msg= "CAMPO DUPLICADO" + Environment.NewLine + Environment.NewLine + ex.Message;
                return msg;
            }
            msg= ex.Message;
            return msg;
        }

        static public string 
            ENTITY_VerificaError(DbUpdateException ex)
        {
            var msg = "";
            var dbUpdateEx = ex as DbUpdateException;
            var sqlEx = dbUpdateEx.InnerException;
            if (sqlEx != null)
            {
                var exx = (MySql.Data.MySqlClient.MySqlException)sqlEx.InnerException;
                if (exx != null)
                {
                    if (exx.Number == 1452)
                    {
                        msg = "FALLO EN CLAVE FORANEA" + Environment.NewLine + exx.Message;
                        return msg;
                    }
                    if (exx.Number == 1451)
                    {
                        msg = "REGISTRO CONTIENE DATA RELACIONADA" + Environment.NewLine + exx.Message;
                        return msg;
                    }
                    if (exx.Number == 1062)
                    {
                        msg="CAMPO DUPLICADO" + Environment.NewLine + exx.Message;
                        return msg;
                    }
                }
            }
            msg = ex.Message;
            return msg;
        }


        //
        static public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> 
            Permiso_Modulo(string autoGrupoUsuario, string codigoFuncion)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(Provider._cnSist.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1",autoGrupoUsuario);
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter("@p2", codigoFuncion);
                    var sql = @"select estatus, seguridad 
                                from usuarios_grupo_permisos 
                                where codigo_grupo=@p1 and codigo_funcion=@p2";
                    var permiso = cnn.Database.SqlQuery<DtoLibSistema.Permiso.Ficha>(sql, p1,p2).FirstOrDefault();
                    if (permiso == null)
                    {
                        result.Mensaje = "PERMISO NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }
                    result.Entidad = permiso;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }


        //
        static public DtoLib.ResultadoLista<DtoLibSistema.Helper.PasarPrecios.Capturar.Ficha>
            PasarPrecios_Capturar()
        {
            var result = new DtoLib.ResultadoLista<DtoLibSistema.Helper.PasarPrecios.Capturar.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(Provider._cnSist.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var sql_1 = @"select 
                                    auto, 
                                    auto_precio_1 as autoMedidaNeto1,
                                    auto_precio_2 as autoMedidaNeto2,
                                    auto_precio_3 as autoMedidaNeto3,
                                    auto_precio_4 as autoMedidaNeto4,
                                    auto_precio_pto as autoMedidaNeto5,
                                    contenido_1 as contNeto1,
                                    contenido_2 as contNeto2,
                                    contenido_3 as contNeto3,
                                    contenido_4 as contNeto4,
                                    contenido_pto as contNeto5,
                                    utilidad_1 utilidadNeto1,
                                    utilidad_2 utilidadNeto2,
                                    utilidad_3 utilidadNeto3,
                                    utilidad_4 utilidadNeto4,
                                    utilidad_pto utilidadNeto5,
                                    precio_1 as neto1, 
                                    precio_2 as neto2, 
                                    precio_3 as neto3, 
                                    precio_4 as neto4,
                                    precio_pto as neto5,
                                    pdf_1 as fullDivisa1,
                                    pdf_2 as fullDivisa2,
                                    pdf_3 as fullDivisa3,
                                    pdf_4 as fullDivisa4,
                                    pdf_pto as fullDivisa5,
                                    pExt.auto_precio_may_1 as autoMay1,
                                    pExt.contenido_may_1 as contMay1,
                                    pExt.utilidad_may_1 as utilMay1,
                                    pExt.precio_may_1 as precioMay1,
                                    pExt.pdmf_1 as fullDivisaMay1 
                                    FROM productos as p
                                    JOIN productos_ext as pExt on pExt.auto_producto=p.auto";
                    var sql_2 = " where 1=1 ";
                    var sql = sql_1 + sql_2;
                    var lst = cnn.Database.SqlQuery<DtoLibSistema.Helper.PasarPrecios.Capturar.Ficha>(sql, p1).ToList();
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
        static public DtoLib.Resultado
            PasarPrecios_Insertar(List<DtoLibSistema.Helper.PasarPrecios.Insertar.Ficha> lst)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(Provider._cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {

                        var sql = "truncate table productos_hnd_precio";
                        cnn.Database.CommandTimeout = 0;
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == -1)
                        {
                            result.Mensaje = "ERROR";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();

                        var xlst = new List<productos_hnd_precio>();
                        foreach (var rg in lst)
                        {
                            var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", rg.autoProducto);
                            var p2 = new MySql.Data.MySqlClient.MySqlParameter("@p2", rg.autoMedida1);
                            var p3 = new MySql.Data.MySqlClient.MySqlParameter("@p3", rg.autoMedida2);
                            var p4 = new MySql.Data.MySqlClient.MySqlParameter("@p4", rg.autoMedida3);
                            var p5 = new MySql.Data.MySqlClient.MySqlParameter("@p5", rg.cont1);
                            var p6 = new MySql.Data.MySqlClient.MySqlParameter("@p6", rg.cont2);
                            var p7 = new MySql.Data.MySqlClient.MySqlParameter("@p7", rg.cont3);
                            var p8 = new MySql.Data.MySqlClient.MySqlParameter("@p8", rg.neto1);
                            var p9 = new MySql.Data.MySqlClient.MySqlParameter("@p9", rg.neto2);
                            var p10 = new MySql.Data.MySqlClient.MySqlParameter("@p10", rg.neto3);
                            var p11 = new MySql.Data.MySqlClient.MySqlParameter("@p11", rg.utilidad1);
                            var p12 = new MySql.Data.MySqlClient.MySqlParameter("@p12", rg.utilidad2);
                            var p13 = new MySql.Data.MySqlClient.MySqlParameter("@p13", rg.utilidad3);
                            var p14 = new MySql.Data.MySqlClient.MySqlParameter("@p14", rg.fullDivisa1);
                            var p15 = new MySql.Data.MySqlClient.MySqlParameter("@p15", rg.fullDivisa2);
                            var p16 = new MySql.Data.MySqlClient.MySqlParameter("@p16", rg.fullDivisa3);
                            var p17 = new MySql.Data.MySqlClient.MySqlParameter("@p17", rg.idPrecio);
                            var sql_1 = @"INSERT INTO productos_hnd_precio (
                                        `autoProducto` ,
                                        `autoMedida_1` ,
                                        `autoMedida_2` ,
                                        `autoMedida_3` ,
                                        `contenido_1` ,
                                        `contenido_2` ,
                                        `contenido_3` ,
                                        `neto_1` ,
                                        `neto_2` ,
                                        `neto_3` ,
                                        `utilidad_1` ,
                                        `utilidad_2` ,
                                        `utilidad_3` ,
                                        `fullDivisa_1` ,
                                        `fullDivisa_2` ,
                                        `fullDivisa_3` ,
                                        `idEmpresaPrecio`)
                                        values(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17)";
                            cnn.Database.CommandTimeout = 0;
                            var rx = cnn.Database.ExecuteSqlCommand(sql_1, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17);
                            if (rx == 0)
                            {
                                result.Mensaje = "ERROR";
                                result.Result = DtoLib.Enumerados.EnumResult.isError;
                                return result;
                            }
                            cnn.SaveChanges();
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

    }

}