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

        public DtoLib.Resultado ReconversionMonetaria_Actualizar(DtoLibSistema.ReconversionMonetaria.Actualizar.Ficha ficha)
        {
            return ServiceProv.ReconversionMonetaria_Actualizar(ficha);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.ReconversionMonetaria.Data.Ficha> ReconversionMonetaria_GetData()
        {
            return ServiceProv.ReconversionMonetaria_GetData();
        }

        public DtoLib.ResultadoEntidad<int> ReconversionMonetaria_GetCount()
        {
            return ServiceProv.ReconversionMonetaria_GetCount();
        }

    }

}