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
        public DtoLib.ResultadoEntidad<DtoLibSistema.AjustarTasaPos.CapturarData.Ficha> 
            AjustarTasaPos_CapturarData()
        {
            return ServiceProv.AjustarTasaPos_CapturarData();
        }
    }
}