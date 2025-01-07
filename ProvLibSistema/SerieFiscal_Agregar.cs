using DtoLib;
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
    public partial class Provider : ILibSistema.IProvider
    {
        public ResultadoAuto
            SerieFiscal_AgregarFicha(DtoLibSistema.SerieFiscal.Agregar.Ficha ficha)
        {
            var result = new ResultadoAuto();
            //
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var _sql = @"update sistema_contadores set 
                                        a_empresa_series_fiscales=a_empresa_series_fiscales+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(_sql);
                        if (r1 == 0)
                        {
                            throw new Exception("PROBLEMA AL ACTUALIZAR TABLA CONTADORES");
                        }
                        //
                        var auto = cnn.Database.SqlQuery<int>("select a_empresa_series_fiscales from sistema_contadores").FirstOrDefault();
                        var id = auto.ToString().Trim().PadLeft(10, '0');
                        //
                        _sql = @"INSERT INTO empresa_series_fiscales (
                                    auto, 
                                    serie, 
                                    correlativo, 
                                    estatus_factura, 
                                    estatus_nd, 
                                    estatus_nc, 
                                    estatus_ne, 
                                    estatus, 
                                    control, 
                                    aplicar_libro_venta
                                ) VALUES (
                                    @p1,
                                    @p2,
                                    @p3,
                                    @p4,
                                    @p5,
                                    @p6,
                                    @p7,
                                    'Activo',
                                    @p8,
                                    @p9
                                )";
                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", id);
                        var p2 = new MySql.Data.MySqlClient.MySqlParameter("@p2", ficha.serie);
                        var p3 = new MySql.Data.MySqlClient.MySqlParameter("@p3", ficha.correlativo);
                        var p4 = new MySql.Data.MySqlClient.MySqlParameter("@p4", ficha.estatusFactura);
                        var p5 = new MySql.Data.MySqlClient.MySqlParameter("@p5", ficha.estatusNtDebito);
                        var p6 = new MySql.Data.MySqlClient.MySqlParameter("@p6", ficha.estatusNtCredito);
                        var p7 = new MySql.Data.MySqlClient.MySqlParameter("@p7", ficha.estatusNtEntrega);
                        var p8 = new MySql.Data.MySqlClient.MySqlParameter("@p8", ficha.control);
                        var p9 = new MySql.Data.MySqlClient.MySqlParameter("@p9", ficha.estatusAplicaLibroVenta);
                        var rt = cnn.Database.ExecuteSqlCommand(_sql, p1, p2, p3, p4, p5, p6, p7, p8, p9);
                        if (rt == 0)
                        {
                            throw new Exception("PROBLEMA AL INSERTAR DATA EN [ TABLA EMPRESA_SERIES_FISCALES ]");
                        }
                        cnn.SaveChanges();
                        ts.Complete();
                        result.Auto = id;
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
            //
            return result;
        }

        public DtoLib.Resultado
            SerieFiscal_Validar_Agregar(DtoLibSistema.SerieFiscal.Agregar.Ficha ficha)
        {
            var rt = new DtoLib.Resultado();
            //
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    if (ficha.serie.Trim() == "")
                    {
                        throw new Exception("CAMPO [ SERIE ] NO PUEDE ESTAR VACIO");
                    }
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
    }
}