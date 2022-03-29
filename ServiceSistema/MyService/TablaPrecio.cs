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

        public DtoLib.ResultadoId 
            TablaPrecio_Agregar(DtoLibSistema.TablaPrecio.Agregar.Ficha ficha)
        {
            return ServiceProv.TablaPrecio_Agregar(ficha);
        }
        public DtoLib.Resultado 
            TablaPrecio_Editar(DtoLibSistema.TablaPrecio.Editar.Ficha ficha)
        {
            return ServiceProv.TablaPrecio_Editar(ficha);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.TablaPrecio.Entidad.Ficha> 
            TablaPrecio_GetById(int id)
        {
            return ServiceProv.TablaPrecio_GetById(id);
        }
        public DtoLib.ResultadoLista<DtoLibSistema.TablaPrecio.Lista.Ficha> 
            TablaPrecio_GetLista()
        {
            return ServiceProv.TablaPrecio_GetLista();
        }

    }

}