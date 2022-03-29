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

        public DtoLib.ResultadoLista<DtoLibSistema.Precio.Resumen> Precio_GetLista()
        {
            return ServiceProv.Precio_GetLista();
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Precio.Etiquetar.Ficha> Precio_Etiquetar_GetFicha()
        {
            return ServiceProv.Precio_Etiquetar_GetFicha();
        }

        public DtoLib.Resultado Precio_Etiquetar_Actualizar(DtoLibSistema.Precio.Etiquetar.Actualizar ficha)
        {
            return ServiceProv.Precio_Etiquetar_Actualizar(ficha);
        }

    }

}