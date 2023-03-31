using ServiceSistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceSistema.MyService
{
    public partial class Service : IService
    {
        public DtoLib.ResultadoLista<DtoLibSistema.AjustarTasaDivisa.ModoAdm.CapturarData> 
            AjustarTasaDivisa_ModoAdm_CapturarData()
        {
            return ServiceProv.AjustarTasaDivisa_ModoAdm_CapturarData();
        }
        public DtoLib.ResultadoEntidad<int> 
            AjustarTasaDivisa_ModoAdm_Ajustar(DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.Ficha ficha)
        {
            return ServiceProv.AjustarTasaDivisa_ModoAdm_Ajustar(ficha);
        }
    }
}