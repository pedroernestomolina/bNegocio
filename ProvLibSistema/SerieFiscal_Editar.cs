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
        public Resultado 
            SerieFiscal_EditarFicha(DtoLibSistema.SerieFiscal.Editar.Ficha ficha)
        {
            var result = new Resultado();
            //
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var _sql = @"update empresa_series_fiscales set 
                                        serie=@p1, 
                                        correlativo=@p2, 
                                        estatus_factura=@p3, 
                                        estatus_nd=@p4, 
                                        estatus_nc=@p5, 
                                        estatus_ne=@p6,  
                                        control=@p7,
                                        aplicar_libro_venta=@p8
                                     where auto=@id";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", ficha.serie);
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter("@p2", ficha.correlativo);
                    var p3 = new MySql.Data.MySqlClient.MySqlParameter("@p3", ficha.estatusFactura);
                    var p4 = new MySql.Data.MySqlClient.MySqlParameter("@p4", ficha.estatusNtDebito);
                    var p5 = new MySql.Data.MySqlClient.MySqlParameter("@p5", ficha.estatusNtCredito);
                    var p6 = new MySql.Data.MySqlClient.MySqlParameter("@p6", ficha.estatusNtEntrega);
                    var p7 = new MySql.Data.MySqlClient.MySqlParameter("@p7", ficha.control);
                    var p8 = new MySql.Data.MySqlClient.MySqlParameter("@p8", ficha.estatusAplicaLibroVenta);
                    var id = new MySql.Data.MySqlClient.MySqlParameter("@id", ficha.id);
                    var rt = cnn.Database.ExecuteSqlCommand(_sql, p1, p2, p3, p4, p5, p6, p7, p8, id);
                    if (rt == 0)
                    {
                        throw new Exception("PROBLEMA AL ACTUALIZAR FICHA");
                    }
                    cnn.SaveChanges();
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
            SerieFiscal_Validar_Editar(DtoLibSistema.SerieFiscal.Editar.Ficha ficha)
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