using LibEntitySistema;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace ProvLibSistema
{
    
    public partial class Provider : ILibSistema.IProvider
    {

        public DtoLib.ResultadoEntidad<string> 
            Configuracion_TasaCambioActual()
        {
            var result = new DtoLib.ResultadoEntidad<string>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var ent = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL12");
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    result.Entidad = ent.usuario;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.ResultadoEntidad<string> 
            Configuracion_TasaRecepcionPos()
        {
            var result = new DtoLib.ResultadoEntidad<string>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var ent = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL48");
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    result.Entidad = ent.usuario;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }

        public DtoLib.Resultado 
            Configuracion_Actualizar_TasaRecepcionPos(DtoLibSistema.Configuracion.ActualizarTasaRecepcionPos.Ficha ficha)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var ent = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL48");
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }

                    ent.usuario = ficha.ValorNuevo.ToString();
                    cnn.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.ResultadoLista<DtoLibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha> 
            Configuracion_Actualizar_TasaDivisa_CapturarData()
        {
            var result = new DtoLib.ResultadoLista<DtoLibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var sql = @"SELECT p.auto, p.estatus_Divisa, p.divisa, p.costo, p.contenido_compras, 
                                    p.pdf_1, p.pdf_2, p.pdf_3, p.pdf_4, p.pdf_pto, p.tasa, 
                                    p.precio_1, p.precio_2, p.precio_3, p.precio_4, p.precio_pto,
                                    pext.pdmf_1, pext.pdmf_2, pext.precio_may_1, pext.precio_may_2,
                                    pext.pdmf_3, pext.pdmf_4, pext.precio_may_3, pext.precio_may_4
                                    FROM productos as p 
                                    join productos_ext as pext on p.auto=pext.auto_producto
                                    where p.estatus='Activo'";
                    //sql += " and p.auto='0000000866' "; 
                    var list = cnn.Database.SqlQuery<DtoLibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha>(sql).ToList();
                    result.Lista = list;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.ResultadoLista<DtoLibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.dataHndPrecio> 
            Configuracion_Actualizar_TasaDivisa_CapturarData_HndPrecio()
        {
            var result = new DtoLib.ResultadoLista<DtoLibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.dataHndPrecio>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var sql = @"SELECT 
                                autoProducto, 
                                idEmpresaPrecio as idPrecio, 
                                neto_1, 
                                neto_2, 
                                neto_3,
                                fullDivisa_1, 
                                fullDivisa_2, 
                                fullDivisa_3,
                                pHndPrecio.contenido_1 as cont_1,
                                pHndPrecio.contenido_2 as cont_2,
                                pHndPrecio.contenido_3 as cont_3,
                                p.estatus_divisa as estatusDivisa, 
                                eTasa.tasa as tasaIva
                                FROM productos_hnd_precio pHndPrecio
                                join productos as p on p.auto=pHndPrecio.autoProducto
                                join empresa_tasas as eTasa on eTasa.auto=p.auto_tasa
                                WHERE p.estatus='Activo' ";
                    //sql += " and autoProducto>='0000001402'";
                    var list = cnn.Database.SqlQuery<DtoLibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.dataHndPrecio>(sql).ToList();
                    result.Lista = list;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.Resultado 
            Configuracion_Actualizar_TasaDivisa_ActualizarData(DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.Ficha ficha)
        {
            var rt = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {

                        try
                        {
                            var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();

                            var ent = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL12");
                            if (ent == null)
                            {
                                rt.Mensaje = "[ ID ] CONFIGURACION NO ENCONTRADO";
                                rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            ent.usuario = ficha.ValorDivisa.ToString();
                            cnn.SaveChanges();

                            foreach (var rg in ficha.productosCostoSinDivisa)
                            {
                                var entPrd = cnn.productos.Find(rg.autoPrd);
                                if (entPrd == null)
                                {
                                    rt.Mensaje = "[ ID ] Producto, No Encontrado";
                                    rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                    return rt;
                                }
                                entPrd.divisa = rg.costoDivisa;
                                entPrd.pdf_1 = rg.precioMonedaEnDivisaFull_1;
                                entPrd.pdf_2 = rg.precioMonedaEnDivisaFull_2;
                                entPrd.pdf_3 = rg.precioMonedaEnDivisaFull_3;
                                entPrd.pdf_4 = rg.precioMonedaEnDivisaFull_4;
                                entPrd.pdf_pto = rg.precioMonedaEnDivisaFull_5;
                                cnn.SaveChanges();

                                var entPrdExt = cnn.productos_ext.Find(rg.autoPrd);
                                if (entPrdExt == null)
                                {
                                    rt.Mensaje = "[ ID ] Producto, No Encontrado";
                                    rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                    return rt;
                                }
                                entPrdExt.pdmf_1 = rg.precioMonedaEnDivisaFull_May_1;
                                entPrdExt.pdmf_2 = rg.precioMonedaEnDivisaFull_May_2;
                                entPrdExt.pdmf_3 = rg.precioMonedaEnDivisaFull_May_3;
                                entPrdExt.pdmf_4 = rg.precioMonedaEnDivisaFull_May_4;
                                cnn.SaveChanges();
                            }

                            foreach (var rg in ficha.productosCostoPrecioDivisa)
                            {
                                var p1 = new MySql.Data.MySqlClient.MySqlParameter("@costoProveedor", rg.costoProveedor);
                                var p2 = new MySql.Data.MySqlClient.MySqlParameter("@costoProveedorUnd", rg.costoProveedorUnd);
                                var p3 = new MySql.Data.MySqlClient.MySqlParameter("@costoImportacion", rg.costoImportacion);
                                var p4 = new MySql.Data.MySqlClient.MySqlParameter("@costoImportacionUnd", rg.costoImportacionUnd);
                                var p5 = new MySql.Data.MySqlClient.MySqlParameter("@costoVario", rg.costoVario);
                                var p6 = new MySql.Data.MySqlClient.MySqlParameter("@costoVarioUnd", rg.costoVarioUnd);
                                var p7 = new MySql.Data.MySqlClient.MySqlParameter("@costo", rg.costo);
                                var p8 = new MySql.Data.MySqlClient.MySqlParameter("@costoUnd", rg.costoUnd);
                                var p9 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
                                var pa = new MySql.Data.MySqlClient.MySqlParameter("@precio_1", rg.precio_1);
                                var pb = new MySql.Data.MySqlClient.MySqlParameter("@precio_2", rg.precio_2);
                                var pc = new MySql.Data.MySqlClient.MySqlParameter("@precio_3", rg.precio_3);
                                var pd = new MySql.Data.MySqlClient.MySqlParameter("@precio_4", rg.precio_4);
                                var pe = new MySql.Data.MySqlClient.MySqlParameter("@precio_5", rg.precio_5);
                                var pf = new MySql.Data.MySqlClient.MySqlParameter("@auto", rg.autoPrd);
                                var sql = @"update productos set 
                                            costo_proveedor=@costoProveedor,
                                            costo_proveedor_und = @costoProveedorUnd,
                                            costo_importacion = @costoImportacion,
                                            costo_importacion_und = @costoImportacionUnd,
                                            costo_varios = @costoVario,
                                            costo_varios_und = @costoVarioUnd,
                                            costo = @costo,
                                            costo_und = @costoUnd,
                                            fecha_ult_costo = @fecha,
                                            fecha_cambio = @fecha,
                                            precio_1 = @precio_1,
                                            precio_2 = @precio_2,
                                            precio_3 = @precio_3,
                                            precio_4 = @precio_4,
                                            precio_pto = @precio_5
                                            where auto=@auto";
                                var i = cnn.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8, p9, pa, pb, pc, pd, pe, pf);
                                if (i == 0)
                                {
                                    rt.Mensaje = "PROBLEMA AL ACTUALIZAR ITEM [" + rg.autoPrd + "]";
                                    rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                    return rt;
                                }

                                var p11 = new MySql.Data.MySqlClient.MySqlParameter("@precio_may_1", rg.precioMay_1);
                                var p22 = new MySql.Data.MySqlClient.MySqlParameter("@precio_may_2", rg.precioMay_2);
                                var p44 = new MySql.Data.MySqlClient.MySqlParameter("@precio_may_3", rg.precioMay_3);
                                var p55 = new MySql.Data.MySqlClient.MySqlParameter("@precio_may_4", rg.precioMay_4);
                                var p33 = new MySql.Data.MySqlClient.MySqlParameter("@auto", rg.autoPrd);
                                var sql2 = @"update productos_ext set 
                                            precio_may_1 = @precio_may_1,
                                            precio_may_2 = @precio_may_2,
                                            precio_may_3 = @precio_may_3,
                                            precio_may_4 = @precio_may_4
                                            where auto_producto=@auto";
                                var i2 = cnn.Database.ExecuteSqlCommand(sql2, p11, p22, p44, p55, p33);
                                if (i2 == 0)
                                {
                                    rt.Mensaje = "PROBLEMA AL ACTUALIZAR ITEM [" + rg.autoPrd + "]";
                                    rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                    return rt;
                                }
                            }

                            //foreach (var rg in ficha.productosCostoPrecioDivisa)
                            //{
                            //    var entPrd = cnn.productos.Find(rg.autoPrd);
                            //    if (entPrd == null)
                            //    {
                            //        rt.Mensaje = "[ ID ] Producto, No Encontrado";
                            //        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                            //        return rt;
                            //    }
                            //    entPrd.costo_proveedor = rg.costoProveedor;
                            //    entPrd.costo_proveedor_und = rg.costoProveedorUnd;
                            //    entPrd.costo_importacion = rg.costoImportacion;
                            //    entPrd.costo_importacion_und = rg.costoImportacionUnd;
                            //    entPrd.costo_varios = rg.costoVario;
                            //    entPrd.costo_varios_und = rg.costoVarioUnd;
                            //    entPrd.costo = rg.costo;
                            //    entPrd.costo_und = rg.costoUnd;
                            //    entPrd.fecha_ult_costo = fechaSistema.Date;
                            //    entPrd.fecha_cambio = fechaSistema.Date;

                            //    entPrd.precio_1 = rg.precio_1;
                            //    entPrd.precio_2 = rg.precio_2;
                            //    entPrd.precio_3 = rg.precio_3;
                            //    entPrd.precio_4 = rg.precio_4;
                            //    entPrd.precio_pto = rg.precio_5;
                            //    cnn.SaveChanges();
                            //}

                            cnn.Configuration.AutoDetectChangesEnabled = false;
                            var lentHist = new List<productos_costos>();
                            foreach (var rg in ficha.productosCostoPrecioDivisa)
                            {
                                var entHist = new productos_costos()
                                {
                                    auto_producto = rg.autoPrd,
                                    costo = rg.costo,
                                    costo_divisa = rg.costoDivisa,
                                    divisa = ficha.ValorDivisa,
                                    documento = rg.documento,
                                    estacion = ficha.EstacionEquipo,
                                    fecha = fechaSistema.Date,
                                    hora = fechaSistema.ToShortTimeString(),
                                    nota = rg.nota,
                                    serie = rg.serie,
                                    usuario = ficha.nombreUsuario,
                                };
                                lentHist.Add(entHist);
                            }
                            cnn.productos_costos.AddRange(lentHist);
                            cnn.SaveChanges();

                            var lentHist_2 = new List<productos_precios>();
                            foreach (var rg in ficha.productosPrecioHistorico)
                            {
                                var entHist = new productos_precios()
                                {
                                    auto_producto = rg.autoPrd,
                                    estacion = ficha.EstacionEquipo,
                                    fecha = fechaSistema.Date,
                                    hora = fechaSistema.ToShortTimeString(),
                                    usuario = ficha.nombreUsuario,
                                    nota = rg.nota,
                                    precio = rg.precio,
                                    precio_id = rg.idPrecio,
                                };
                                lentHist_2.Add(entHist);
                            }
                            cnn.productos_precios.AddRange(lentHist_2);
                            cnn.SaveChanges();

                            foreach (var rg in ficha.productosHndPrecio)
                            {
                                if (rg.esAdmDivisa)
                                {
                                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                                    var p5 = new MySql.Data.MySqlClient.MySqlParameter();

                                    p1.ParameterName = "@neto1";
                                    p1.Value = rg.neto_1;
                                    p2.ParameterName = "@neto2";
                                    p2.Value = rg.neto_2;
                                    p3.ParameterName = "@neto3";
                                    p3.Value = rg.neto_3;
                                    p4.ParameterName = "@autoPrd";
                                    p4.Value = rg.autoProducto;
                                    p5.ParameterName = "@idPrecio";
                                    p5.Value = rg.idPrecio;
                                    var xsql = @"update productos_hnd_precio set neto_1=@neto1, neto_2=@neto2, neto_3=@neto3
                                                where autoProducto=@autoPrd and idEmpresaPrecio=@idPrecio";
                                    var xrg = cnn.Database.ExecuteSqlCommand(xsql, p1, p2, p3, p4, p5);
                                    if (xrg == -1)
                                    {
                                        rt.Mensaje = "PROBLEMA AL ACTUALIZAR PRODUCTO_HND_PRECIO";
                                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                        return rt;
                                    }
                                    cnn.SaveChanges();
                                }
                                else
                                {
                                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                                    var p2 = new MySql.Data.MySqlClient.MySqlParameter();
                                    var p3 = new MySql.Data.MySqlClient.MySqlParameter();
                                    var p4 = new MySql.Data.MySqlClient.MySqlParameter();
                                    var p5 = new MySql.Data.MySqlClient.MySqlParameter();

                                    p1.ParameterName = "@fulldivisa1";
                                    p1.Value = rg.fullDivisa_1;
                                    p2.ParameterName = "@fulldivisa2";
                                    p2.Value = rg.fullDivisa_2;
                                    p3.ParameterName = "@fulldivisa3";
                                    p3.Value = rg.fullDivisa_3;
                                    p4.ParameterName = "@autoPrd";
                                    p4.Value = rg.autoProducto;
                                    p5.ParameterName = "@idPrecio";
                                    p5.Value = rg.idPrecio;
                                    var xsql = @"update productos_hnd_precio set 
                                                    fullDivisa_1=@fulldivisa1, 
                                                    fullDivisa_2=@fulldivisa2, 
                                                    fullDivisa_3=@fulldivisa3
                                                where autoProducto=@autoPrd and idEmpresaPrecio=@idPrecio";
                                    var xrg = cnn.Database.ExecuteSqlCommand(xsql, p1, p2, p3, p4, p5);
                                    if (xrg == -1)
                                    {
                                        rt.Mensaje = "PROBLEMA AL ACTUALIZAR PRODUCTO_HND_PRECIO";
                                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                        return rt;
                                    }
                                    cnn.SaveChanges();
                                }
                            }

                            ts.Commit();
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            rt.Mensaje = Helpers.MYSQL_VerificaError(ex);
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        }
                        catch (DbUpdateException ex)
                        {
                            rt.Mensaje = Helpers.ENTITY_VerificaError(ex);
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        }
                        //catch (DbUpdateException ex)
                        //{
                        //    var dbUpdateEx = ex as DbUpdateException;
                        //    var sqlEx = dbUpdateEx.InnerException;
                        //    if (sqlEx != null)
                        //    {
                        //        var exx = (MySql.Data.MySqlClient.MySqlException)sqlEx.InnerException;
                        //        if (exx != null)
                        //        {
                        //            if (exx.Number == 1451)
                        //            {
                        //                rt.Mensaje = "REGISTRO CONTIENE DATA RELACIONADA";
                        //                rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        //                return rt;
                        //            }
                        //            if (exx.Number == 1062)
                        //            {
                        //                rt.Mensaje = exx.Message;
                        //                rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        //                return rt;
                        //            }
                        //            rt.Mensaje = exx.Message;
                        //            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        //            return rt;
                        //        }
                        //    }
                        //    rt.Mensaje = ex.Message;
                        //    rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        //}
                        finally
                        {
                            cnn.Configuration.AutoDetectChangesEnabled = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return rt;
        }
        
        public DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> 
            Configuracion_ForzarRedondeoPrecioVenta()
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var ent = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL46");
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }

                    var modo = DtoLibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.SinDefinir;
                    switch (ent.usuario.Trim().ToUpper())
                    {
                        case "SIN REDONDEO":
                            modo = DtoLibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.SinRedeondeo;
                            break;
                        case "UNIDAD":
                            modo = DtoLibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad;
                            break;
                        case "DECENA":
                            modo = DtoLibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena;
                            break;
                    }

                    result.Entidad = modo;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio> 
            Configuracion_PreferenciaRegistroPrecio()
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var ent = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL41");
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }

                    var modo = DtoLibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.SinDefinir;
                    switch (ent.usuario.Trim().ToUpper())
                    {
                        case "PRECIO NETO":
                            modo = DtoLibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Neto;
                            break;
                        case "PRECIO+IVA":
                            modo = DtoLibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full;
                            break;
                    }

                    result.Entidad = modo;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Modulo.Capturar.Ficha> 
            Configuracion_Modulo_Capturar()
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Modulo.Capturar.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var  ent1= cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL17");
                    if (ent1 == null)
                    {
                        result.Mensaje = "[ GLOBAL17 ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    var ent2 = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL18");
                    if (ent2 == null)
                    {
                        result.Mensaje = "[ GLOBAL18 ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    var ent3 = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL19");
                    if (ent3 == null)
                    {
                        result.Mensaje = "[ GLOBAL19 ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    var ent4 = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL52");
                    if (ent4 == null)
                    {
                        result.Mensaje = "[ GLOBAL52 ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    var ent5 = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL53");
                    if (ent5 == null)
                    {
                        result.Mensaje = "[ GLOBAL53 ] CONFIGURACION NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }

                    var rg = new DtoLibSistema.Configuracion.Modulo.Capturar.Ficha()
                    {
                        claveNivMaximo = ent1.usuario,
                        claveNivMedio = ent2.usuario,
                        claveNivMinimo = ent3.usuario,
                        visualizarPrdInactivos = ent4.usuario,
                        cantDocVisualizar = ent5.usuario,
                    };
                    result.Entidad = rg;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.Resultado 
            Configuracion_Modulo_Actualizar(DtoLibSistema.Configuracion.Modulo.Actualizar.Ficha ficha)
        {
            var rt= new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    { 
                        try
                        {
                            var ent1 = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL17");
                            if (ent1 == null)
                            {
                                rt.Mensaje = "[ GLOBAL17 ] CONFIGURACION NO ENCONTRADO";
                                rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            ent1.usuario = ficha.claveNivMaximo;
                            cnn.SaveChanges();

                            var ent2 = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL18");
                            if (ent2 == null)
                            {
                                rt.Mensaje = "[ GLOBAL18 ] CONFIGURACION NO ENCONTRADO";
                                rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            ent2.usuario = ficha.claveNivMedio;
                            cnn.SaveChanges();

                            ent1.usuario = ficha.claveNivMaximo;
                            var ent3 = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL19");
                            if (ent3 == null)
                            {
                                rt.Mensaje = "[ GLOBAL19 ] CONFIGURACION NO ENCONTRADO";
                                rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            ent3.usuario = ficha.claveNivMinimo;
                            cnn.SaveChanges();

                            var ent4 = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL52");
                            if (ent4 == null)
                            {
                                rt.Mensaje = "[ GLOBAL52 ] CONFIGURACION NO ENCONTRADO";
                                rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            ent4.usuario = ficha.visualizarPrdInactivos;
                            cnn.SaveChanges();

                            var ent5 = cnn.sistema_configuracion.FirstOrDefault(f => f.codigo == "GLOBAL53");
                            if (ent5 == null)
                            {
                                rt.Mensaje = "[ GLOBAL53 ] CONFIGURACION NO ENCONTRADO";
                                rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            ent5.usuario = ficha.cantDocVisualizar.ToString();
                            cnn.SaveChanges();

                            ts.Commit();
                        }
                        catch (DbUpdateException ex)
                        {
                            var dbUpdateEx = ex as DbUpdateException;
                            var sqlEx = dbUpdateEx.InnerException;
                            if (sqlEx != null)
                            {
                                var exx = (MySql.Data.MySqlClient.MySqlException)sqlEx.InnerException;
                                if (exx != null)
                                {
                                    if (exx.Number == 1451)
                                    {
                                        rt.Mensaje = "REGISTRO CONTIENE DATA RELACIONADA";
                                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                        return rt;
                                    }
                                    if (exx.Number == 1062)
                                    {
                                        rt.Mensaje = exx.Message;
                                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                        return rt;
                                    }
                                    rt.Mensaje = exx.Message;
                                    rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                    return rt;
                                }
                            }
                            rt.Mensaje = ex.Message;
                            rt.Result = DtoLib.Enumerados.EnumResult.isError;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return rt;
        }

    }

}