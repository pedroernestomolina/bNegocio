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
        public DtoLib.ResultadoLista<DtoLibSistema.MediosCobroPago.Lista.Ficha> 
            MediosCobroPago_GetLista(DtoLibSistema.MediosCobroPago.Lista.Filtro filtro)
        {
            return ServiceProv.MediosCobroPago_GetLista(filtro);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.MediosCobroPago.Entidad.Ficha>
            MediosCobroPago_GetFicha_ById(string id)
        {
            return ServiceProv.MediosCobroPago_GetFicha_ById(id);
        }
        public DtoLib.ResultadoAuto 
            MediosCobroPago_AgregarFicha(DtoLibSistema.MediosCobroPago.Agregar.Ficha ficha)
        {
            return ServiceProv.MediosCobroPago_AgregarFicha(ficha);
        }
        public DtoLib.Resultado 
            MediosCobroPago_EditarFicha(DtoLibSistema.MediosCobroPago.Editar.Ficha ficha)
        {
            return ServiceProv.MediosCobroPago_EditarFicha(ficha);
        }

    }

}