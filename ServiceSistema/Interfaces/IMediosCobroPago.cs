using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceSistema.Interfaces
{
    
    public interface IMediosCobroPago
    {

        DtoLib.ResultadoLista<DtoLibSistema.MediosCobroPago.Lista.Ficha>
            MediosCobroPago_GetLista(DtoLibSistema.MediosCobroPago.Lista.Filtro filtro);
        DtoLib.ResultadoEntidad<DtoLibSistema.MediosCobroPago.Entidad.Ficha>
            MediosCobroPago_GetFicha_ById(string id);
        DtoLib.ResultadoAuto
            MediosCobroPago_AgregarFicha(DtoLibSistema.MediosCobroPago.Agregar.Ficha ficha);
        DtoLib.Resultado
            MediosCobroPago_EditarFicha(DtoLibSistema.MediosCobroPago.Editar.Ficha ficha);

    }

}