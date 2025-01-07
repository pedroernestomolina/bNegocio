using DtoLib;
using LibEntitySistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibSistema
{
    public partial class Provider : ILibSistema.IProvider
    {
        public ResultadoEntidad<DtoLibSistema.SerieFiscal.Entidad.Ficha> 
            SerieFiscal_GetFicha_ById(string id)
        {
            var result = new ResultadoEntidad<DtoLibSistema.SerieFiscal.Entidad.Ficha>();
            //
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var _sql = @"select 
                                    auto as id, 
                                    serie as serie, 
                                    correlativo as correlativo, 
                                    estatus_factura as estatusFactura, 
                                    estatus_nd as estatusNtDebito, 
                                    estatus_nc as estatusNtCredito, 
                                    estatus_ne as estatusNtEntrega,  
                                    estatus as estatus, 
                                    control as control,
                                    aplicar_libro_venta as estatusAplicaLibroVenta
                                from empresa_series_fiscales
                                where auto=@p1";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1",id);
                    var ent = cnn.Database.SqlQuery<DtoLibSistema.SerieFiscal.Entidad.Ficha>(_sql,p1).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("[ ID ] SERIE FISCAL NO ENCONTRADO");
                    }
                    //
                    result.Entidad = ent;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
    }
}
