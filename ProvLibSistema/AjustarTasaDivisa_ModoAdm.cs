using LibEntitySistema;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibSistema
{
    public partial class Provider : ILibSistema.IProvider
    {
        public DtoLib.ResultadoLista<DtoLibSistema.AjustarTasaDivisa.ModoAdm.CapturarData> 
            AjustarTasaDivisa_ModoAdm_CapturarData()
        {
            var result = new DtoLib.ResultadoLista<DtoLibSistema.AjustarTasaDivisa.ModoAdm.CapturarData>();
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var sql = @"SELECT 
                                    p.auto as autoPrd, 
                                    p.codigo as codigoPrd, 
                                    p.nombre as descPrd, 
                                    p.estatus_divisa as estatusDivisa, 
                                    p.costo as costoMonLocalEmpCompra,
                                    p.divisa as costoDivisaEmpCompra,
                                    p.contenido_compras as contEmpCompra,
                                    x1.id as idPrecioVta, 
                                    x1.neto_monedaLocal as pNetoMonLocalEmpVta, 
                                    x1.full_divisa as pFullDivisaEmpVta,
                                    x2.contenido_empaque as contEmpVta,
                                    x2.tipo_empaque as tipoEmpVta,
                                    empTasas.tasa as tasaIva,
                                    pMed.nombre as descEmpVta
                                FROM `productos_ext_hnd_precioventa` as x1
                                join productos as p on p.auto=x1.auto_producto
                                join productos_ext_hnd_empventa as x2 on x2.id=x1.id_prd_hnd_empVenta
                                join empresa_tasas as empTasas on empTasas.auto=p.auto_tasa
                                join productos_medida as pMed on pMed.auto=x2.auto_empaque
                                where x1.neto_monedaLocal>0 and p.estatus='Activo' ";
                    var _lst = cnn.Database.SqlQuery<DtoLibSistema.AjustarTasaDivisa.ModoAdm.CapturarData>(sql).ToList();
                    result.Lista = _lst;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DtoLib.ResultadoEntidad<int> 
            AjustarTasaDivisa_ModoAdm_Ajustar(DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.Ficha ficha)
        {
            var rt = new DtoLib.ResultadoEntidad<int>();
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = cnn.Database.BeginTransaction())
                    {
                        try
                        {
                            var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();

                            var p1 = new MySql.Data.MySqlClient.MySqlParameter("@ValorNuevo", ficha.TasaDivisaNueva);
                            var _sql = @"update sistema_configuracion set 
                                            usuario=@ValorNuevo
                                        where codigo='GLOBAL12'";
                            var i=cnn.Database.ExecuteSqlCommand(_sql, p1);
                            if (i == 0)
                            {
                                rt.Mensaje = "PROBLEMA AL ACTUALIZAR CONFIGUTACION [GLOBAL12]";
                                rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                return rt;
                            }

                            cnn.SaveChanges();

                            var xp1 = new MySql.Data.MySqlClient.MySqlParameter("@ValorNuevo", ficha.TasaDivisaNueva);
                            _sql = @"update sistema_configuracion set 
                                            usuario=@ValorNuevo
                                        where codigo='GLOBAL48'";
                            i=cnn.Database.ExecuteSqlCommand(_sql, xp1);
                            if (i == 0)
                            {
                                rt.Mensaje = "PROBLEMA AL ACTUALIZAR CONFIGUTACION [GLOBAL48]";
                                rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                return rt;
                            }
                            cnn.SaveChanges();

                            if (ficha.noAdmDivisa != null)
                            {
                                foreach (var rg in ficha.noAdmDivisa.prd)
                                {
                                    var xt1 = new MySql.Data.MySqlClient.MySqlParameter("@autoPrd", rg.autoprd);
                                    var xt2 = new MySql.Data.MySqlClient.MySqlParameter("@costoDivisa", rg.costoDivisa);
                                    var xt3 = new MySql.Data.MySqlClient.MySqlParameter("@fechaSist", fechaSistema.Date);
                                    _sql = @"update productos set 
                                            divisa=@costoDivisa, fecha_cambio=@fechaSist
                                        where auto=@autoPrd";
                                    i=cnn.Database.ExecuteSqlCommand(_sql, xt1, xt2, xt3);
                                    if (i == 0)
                                    {
                                        rt.Mensaje = "PROBLEMA AL ACTUALIZAR ITEM [" + rg.descPrd + "]";
                                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                        return rt;
                                    }
                                    cnn.SaveChanges();
                                }
                                foreach (var rg in ficha.noAdmDivisa.precio)
                                {
                                    var xt1 = new MySql.Data.MySqlClient.MySqlParameter("@idPrecioVta", rg.idPrecioVta);
                                    var xt2 = new MySql.Data.MySqlClient.MySqlParameter("@divisaFull", rg.pDivisaFull);
                                    _sql = @"update productos_ext_hnd_precioventa set 
                                            full_divisa=@divisaFull
                                        where id=@idPrecioVta";
                                    i = cnn.Database.ExecuteSqlCommand(_sql, xt1, xt2);
                                    if (i == 0)
                                    {
                                        rt.Mensaje = "PROBLEMA AL ACTUALIZAR ITEM [" + rg.descPrd + "]";
                                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                        return rt;
                                    }
                                    cnn.SaveChanges();
                                }
                            }

                            if (ficha.siAdmDivisa != null)
                            {
                                foreach (var rg in ficha.siAdmDivisa.prd)
                                {
                                    var t1 = new MySql.Data.MySqlClient.MySqlParameter("@costoProv", rg.costoProv);
                                    var t2 = new MySql.Data.MySqlClient.MySqlParameter("@costoProvUnd", rg.costoProvUnd);
                                    var t3 = new MySql.Data.MySqlClient.MySqlParameter("@costoImp", rg.costoImp);
                                    var t4 = new MySql.Data.MySqlClient.MySqlParameter("@costoImpUnd", rg.costoImpUnd);
                                    var t5 = new MySql.Data.MySqlClient.MySqlParameter("@costoVario", rg.costoVario);
                                    var t6 = new MySql.Data.MySqlClient.MySqlParameter("@costoVarioUnd", rg.costoVarioUnd);
                                    var t7 = new MySql.Data.MySqlClient.MySqlParameter("@costo", rg.costo);
                                    var t8 = new MySql.Data.MySqlClient.MySqlParameter("@costoUnd", rg.costoUnd);
                                    var t9 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
                                    var t10 = new MySql.Data.MySqlClient.MySqlParameter("@auto", rg.autoprd);
                                    var sql = @"update productos set 
                                            costo_proveedor=@costoProv,
                                            costo_proveedor_und = @costoProvUnd,
                                            costo_importacion = @costoImp,
                                            costo_importacion_und = @costoImpUnd,
                                            costo_varios = @costoVario,
                                            costo_varios_und = @costoVarioUnd,
                                            costo = @costo,
                                            costo_und = @costoUnd,
                                            fecha_ult_costo = @fecha,
                                            fecha_cambio = @fecha
                                            where auto=@auto";
                                    i = cnn.Database.ExecuteSqlCommand(sql, t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
                                    if (i == 0)
                                    {
                                        rt.Mensaje = "PROBLEMA AL ACTUALIZAR ITEM [" + rg.descPrd + "]";
                                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                        return rt;
                                    }
                                    cnn.SaveChanges();
                                }
                                foreach (var rg in ficha.siAdmDivisa.precio)
                                {
                                    var xt1 = new MySql.Data.MySqlClient.MySqlParameter("@idPrecioVta", rg.idPrecioVta);
                                    var xt2 = new MySql.Data.MySqlClient.MySqlParameter("@netoMonLocal", rg.pnetoMonLocal);
                                    _sql = @"update productos_ext_hnd_precioventa set 
                                            neto_monedaLocal=@netoMonLocal
                                        where id=@idPrecioVta";
                                    i = cnn.Database.ExecuteSqlCommand(_sql, xt1, xt2);
                                    if (i == 0)
                                    {
                                        rt.Mensaje = "PROBLEMA AL ACTUALIZAR ITEM [" + rg.descPrd + "]";
                                        rt.Result = DtoLib.Enumerados.EnumResult.isError;
                                        return rt;
                                    }
                                    cnn.SaveChanges();
                                }
                                foreach (var rg in ficha.siAdmDivisa.historia)
                                {
                                    var zxp1 = new MySql.Data.MySqlClient.MySqlParameter("@autoPrd", rg.autoPrd);
                                    var zxp2 = new MySql.Data.MySqlClient.MySqlParameter("@empDesc", rg.empDesc);
                                    var zxp3 = new MySql.Data.MySqlClient.MySqlParameter("@empCont", rg.empCont);
                                    var zxp4 = new MySql.Data.MySqlClient.MySqlParameter("@fecha", fechaSistema.Date);
                                    var zxp5 = new MySql.Data.MySqlClient.MySqlParameter("@hora", fechaSistema.ToShortTimeString());
                                    var zxp6 = new MySql.Data.MySqlClient.MySqlParameter("@usuCodigo", ficha.usuCodigo);
                                    var zxp7 = new MySql.Data.MySqlClient.MySqlParameter("@usuNombre", ficha.usuNombre);
                                    var zxp8 = new MySql.Data.MySqlClient.MySqlParameter("@estacion", ficha.estacion);
                                    var zxp9 = new MySql.Data.MySqlClient.MySqlParameter("@factorCambio", ficha.TasaDivisaNueva);
                                    var zxp10 = new MySql.Data.MySqlClient.MySqlParameter("@netoMonLocal", rg.netoMonLocal);
                                    var zxp11 = new MySql.Data.MySqlClient.MySqlParameter("@fullDivisa", rg.fullDivisa);
                                    var zxp12 = new MySql.Data.MySqlClient.MySqlParameter("@tipoEmpVenta", rg.tipoEmpaqueVenta);
                                    var zxp13 = new MySql.Data.MySqlClient.MySqlParameter("@tipoPrecioVenta", rg.tipoPrecioVenta);
                                    var zxp14 = new MySql.Data.MySqlClient.MySqlParameter("@prdCodigo", rg.prdCodigo);
                                    var zxp15 = new MySql.Data.MySqlClient.MySqlParameter("@prdDesc", rg.prdDesc);
                                    var zxp16 = new MySql.Data.MySqlClient.MySqlParameter("@nota", ficha.nota);
                                    var _sql2 = @"INSERT INTO `productos_precios_historia` (
                                                `id` ,
                                                `auto_producto` ,
                                                `empaque_desc` ,
                                                `empaque_cont` ,
                                                `fecha` ,
                                                `hora` ,
                                                `usuario_codigo` ,
                                                `usuario_nombre` ,
                                                `estacion` ,
                                                `factor_cambio` ,
                                                `neto` ,
                                                `full_Divisa` ,
                                                `tipoempVenta` ,
                                                `tipo_precio` ,
                                                `prd_codigo` ,
                                                `prd_descripcion` ,
                                                `nota`
                                            )
                                            VALUES (
                                                NULL, 
                                                @autoPrd, @empDesc, @empCont, @fecha, @hora, @usuCodigo, @usuNombre, @estacion,
                                                @factorCambio, @netoMonLocal, @fullDivisa, @tipoEmpVenta, @tipoPrecioVenta, 
                                                @prdCodigo, @prdDesc, @nota)";
                                    var _nr = cnn.Database.ExecuteSqlCommand(_sql2, zxp1, zxp2, zxp3, zxp4,
                                                                                zxp5, zxp6, zxp7, zxp8, zxp9,
                                                                                zxp10, zxp11, zxp12, zxp13,
                                                                                zxp14, zxp15, zxp16);
                                    cnn.SaveChanges();
                                }
                            }
                            ts.Commit();
                            rt.Entidad = 0;
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            throw new Exception(Helpers.MYSQL_VerificaError(ex));
                        }
                        catch (DbUpdateException ex)
                        {
                            throw new Exception(Helpers.ENTITY_VerificaError(ex));
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message );
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