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

        public DtoLib.ResultadoLista<DtoLibSistema.Vendedor.Lista.Ficha> Vendedor_GetLista(DtoLibSistema.Vendedor.Lista.Filtro filtro)
        {
            return ServiceProv.Vendedor_GetLista(filtro);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Vendedor.Entidad.Ficha> Vendedor_GetFicha_ById(string id)
        {
            return ServiceProv.Vendedor_GetFicha_ById(id);
        }

        public DtoLib.ResultadoAuto Vendedor_AgregarFicha(DtoLibSistema.Vendedor.Agregar.Ficha ficha)
        {
            var r01 = ServiceProv.Vendedor_Validar_Agregar(ficha);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                return new DtoLib.ResultadoAuto()
                {
                    Auto = "",
                    Mensaje = r01.Mensaje,
                    Result = DtoLib.Enumerados.EnumResult.isError,
                };
            }
            return ServiceProv.Vendedor_AgregarFicha(ficha);
        }

        public DtoLib.Resultado Vendedor_EditarFicha(DtoLibSistema.Vendedor.Editar.Ficha ficha)
        {
            var r01 = ServiceProv.Vendedor_Validar_Editar(ficha);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                return new DtoLib.Resultado()
                {
                    Mensaje = r01.Mensaje,
                    Result = DtoLib.Enumerados.EnumResult.isError,
                };
            }
            return ServiceProv.Vendedor_EditarFicha(ficha);
        }

        public DtoLib.Resultado Vendedor_Activar(DtoLibSistema.Vendedor.ActivarInactivar.Ficha ficha)
        {
            return ServiceProv.Vendedor_Activar(ficha);
        }

        public DtoLib.Resultado Vendedor_Inactivar(DtoLibSistema.Vendedor.ActivarInactivar.Ficha ficha)
        {
            return ServiceProv.Vendedor_Inactivar(ficha);
        }

    }

}