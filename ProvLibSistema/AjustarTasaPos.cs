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
        public DtoLib.ResultadoEntidad<DtoLibSistema.AjustarTasaPos.CapturarData.Ficha> 
            AjustarTasaPos_CapturarData()
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibSistema.AjustarTasaPos.CapturarData.Ficha>();
            //
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var sql = @"SELECT 
                                    prd.auto as idPrd,
                                    prd.codigo as codigoPrd,
                                    prd.nombre as nombreprd,

                                    prd.precio_1 as p1,
                                    prd.precio_2 as p2,
                                    prd.precio_3 as p3,
                                    prd.precio_4 as p4,
    
                                    prdExt.precio_may_1 as may1,
                                    prdExt.precio_may_2 as may2,
                                    prdExt.precio_may_3 as may3,
                                    prdExt.precio_may_4 as may4,
    
                                    prdExt.precio_dsp_1 as dsp1,
                                    prdExt.precio_dsp_2 as dsp2,
                                    prdExt.precio_dsp_3 as dsp3,
                                    prdExt.precio_dsp_4 as dsp4,   
    
                                    prdExt.cont_emp_venta_tipo_1 as contEmp1,
                                    prdExt.cont_emp_venta_tipo_2 as contEmp2,
                                    prdExt.cont_emp_venta_tipo_3 as contEmp3,
    
                                    med1.nombre as descEmp1,
                                    med2.nombre as descEmp2,
                                    med3.nombre as descEmp3
    
                                from productos as prd
                                join productos_ext as prdExt on prdExt.auto_producto=prd.auto
                                join productos_medida as med1 on med1.auto=prdExt.auto_emp_venta_tipo_1
                                join productos_medida as med2 on med2.auto=prdExt.auto_emp_venta_tipo_2
                                join productos_medida as med3 on med3.auto=prdExt.auto_emp_venta_tipo_3

                                where estatus_divisa='0' AND
                                    estatus= 'Activo' AND
                                    categoria = 'Producto Terminado'";
                    var _lst = cnn.Database.SqlQuery<DtoLibSistema.AjustarTasaPos.CapturarData.Item>(sql).ToList();
                    result.Entidad = new DtoLibSistema.AjustarTasaPos.CapturarData.Ficha()
                    {
                        items = _lst,
                    };
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