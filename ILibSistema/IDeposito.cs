using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibSistema
{

    public interface IDeposito
    {

        DtoLib.ResultadoLista<DtoLibSistema.Deposito.Lista.Ficha> 
            Deposito_GetLista(DtoLibSistema.Deposito.Lista.Filtro filtro);
        DtoLib.ResultadoEntidad<DtoLibSistema.Deposito.Entidad.Ficha> 
            Deposito_GetFicha(string auto);
        DtoLib.ResultadoAuto 
            Deposito_Agregar(DtoLibSistema.Deposito.Agregar.Ficha ficha);
        DtoLib.Resultado 
            Deposito_Editar (DtoLibSistema.Deposito.Editar.Ficha ficha);
        DtoLib.Resultado 
            Deposito_Activar(string id);
        DtoLib.Resultado 
            Deposito_Inactivar(string id);

    }

}