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

        public DtoLib.ResultadoLista<DtoLibSistema.Funciones.Resumen> Funcion_GetLista()
        {
            return ServiceProv.Funcion_GetLista();
        }

    }

}