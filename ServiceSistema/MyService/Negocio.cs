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

        public DtoLib.ResultadoEntidad<DtoLibSistema.Negocio.Entidad.Ficha> Negocio_GetEntidad_ByAuto(string autoEmpresa)
        {
            return ServiceProv.Negocio_GetEntidad_ByAuto(autoEmpresa);
        }

        public DtoLib.Resultado Negocio_EditarFicha(DtoLibSistema.Negocio.Editar.Ficha ficha)
        {
            return ServiceProv.Negocio_EditarFicha(ficha);
        }

    }

}