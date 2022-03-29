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

        public DtoLib.ResultadoLista<DtoLibSistema.SerieFiscal.Lista.Ficha> SerieFiscal_GetLista(DtoLibSistema.SerieFiscal.Lista.Filtro filtro)
        {
            return ServiceProv.SerieFiscal_GetLista(filtro);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.SerieFiscal.Entidad.Ficha> SerieFiscal_GetFicha_ById(string id)
        {
            return ServiceProv.SerieFiscal_GetFicha_ById(id);
        }

        public DtoLib.ResultadoAuto SerieFiscal_AgregarFicha(DtoLibSistema.SerieFiscal.Agregar.Ficha ficha)
        {
            return ServiceProv.SerieFiscal_AgregarFicha(ficha);
        }

        public DtoLib.Resultado SerieFiscal_EditarFicha(DtoLibSistema.SerieFiscal.Editar.Ficha ficha)
        {
            return ServiceProv.SerieFiscal_EditarFicha(ficha);
        }

        public DtoLib.Resultado SerieFiscal_Activar(DtoLibSistema.SerieFiscal.ActivarInactivar.Ficha ficha)
        {
            return ServiceProv.SerieFiscal_Activar(ficha);
        }

        public DtoLib.Resultado SerieFiscal_Inactivar(DtoLibSistema.SerieFiscal.ActivarInactivar.Ficha ficha)
        {
            return ServiceProv.SerieFiscal_Inactivar(ficha);
        }

    }

}