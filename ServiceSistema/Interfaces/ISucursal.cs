using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceSistema.Interfaces
{

    public interface ISucursal
    {

        DtoLib.ResultadoLista<DtoLibSistema.Sucursal.Lista.Ficha>
            Sucursal_GetLista(DtoLibSistema.Sucursal.Lista.Filtro filtro);
        DtoLib.ResultadoEntidad<DtoLibSistema.Sucursal.Entidad.Ficha>
            Sucursal_GetFicha(string auto);
        DtoLib.ResultadoAuto
            Sucursal_Agregar(DtoLibSistema.Sucursal.Agregar.Ficha ficha);
        DtoLib.Resultado
            Sucursal_Editar(DtoLibSistema.Sucursal.Editar.Ficha ficha);
        DtoLib.Resultado
            Sucursal_AsignarDepositoPrincipal(DtoLibSistema.Sucursal.AsignarDepositoPrincipal.Ficha ficha);
        DtoLib.Resultado
            Sucursal_QuitarDepositoPrincipal(string autoSuc);

    }

}