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

        public DtoLib.ResultadoLista<DtoLibSistema.Cobrador.Lista.Ficha> Cobrador_GetLista(DtoLibSistema.Cobrador.Lista.Filtro filtro)
        {
            return ServiceProv.Cobrador_GetLista(filtro);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Cobrador.Entidad.Ficha> Cobrador_GetFicha_ById(string id)
        {
            return ServiceProv.Cobrador_GetFicha_ById(id);
        }

        public DtoLib.ResultadoAuto Cobrador_AgregarFicha(DtoLibSistema.Cobrador.Agregar.Ficha ficha)
        {
            var r01 = ServiceProv.Cobrador_Validar_Agregar(ficha);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                return new DtoLib.ResultadoAuto()
                {
                    Auto = "",
                    Mensaje = r01.Mensaje,
                    Result = DtoLib.Enumerados.EnumResult.isError,
                };
            }
            return ServiceProv.Cobrador_AgregarFicha(ficha);
        }

        public DtoLib.Resultado Cobrador_EditarFicha(DtoLibSistema.Cobrador.Editar.Ficha ficha)
        {
            var r01 = ServiceProv.Cobrador_Validar_Editar(ficha);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                return new DtoLib.Resultado()
                {
                    Mensaje = r01.Mensaje,
                    Result = DtoLib.Enumerados.EnumResult.isError,
                };
            }
            return ServiceProv.Cobrador_EditarFicha(ficha);
        }

    }

}