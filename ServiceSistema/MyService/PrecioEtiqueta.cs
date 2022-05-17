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

        public DtoLib.ResultadoEntidad<DtoLibSistema.PrecioEtiqueta.Entidad.Ficha > 
            PrecioEtiqueta_GetFicha()
        {
            return ServiceProv.PrecioEtiqueta_GetFicha();
        }
        public DtoLib.Resultado 
            PrecioEtiqueta_Actualizar(DtoLibSistema.PrecioEtiqueta.Actualizar.Ficha ficha)
        {
            return ServiceProv.PrecioEtiqueta_Actualizar(ficha);
        }

    }

}