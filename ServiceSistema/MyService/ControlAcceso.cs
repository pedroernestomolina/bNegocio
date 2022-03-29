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

        public DtoLib.ResultadoLista<DtoLibSistema.ControlAcceso.Data.Ficha> ControlAcceso_GetData(string idGrupo)
        {
            return ServiceProv.ControlAcceso_GetData(idGrupo);
        }

        public DtoLib.Resultado ControlAcceso_Actualizar(DtoLibSistema.ControlAcceso.Actualizar.Ficha ficha)
        {
            return ServiceProv.ControlAcceso_Actualizar(ficha);
        }

    }

}