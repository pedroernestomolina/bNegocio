using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceSistema.Interfaces
{

    public interface ISucursalGrupo
    {

        DtoLib.ResultadoLista<DtoLibSistema.GrupoSucursal.Lista.Ficha>
            SucursalGrupo_GetLista();
        DtoLib.ResultadoEntidad<DtoLibSistema.GrupoSucursal.Entidad.Ficha>
            SucursalGrupo_GetFicha(string auto);
        DtoLib.ResultadoAuto 
            SucursalGrupo_Agregar(DtoLibSistema.GrupoSucursal.Agregar.Ficha ficha);
        DtoLib.Resultado 
            SucursalGrupo_Editar(DtoLibSistema.GrupoSucursal.Editar.Ficha ficha);
        DtoLib.Resultado
            SucursalGrupo_Eliminar(string id);

    }

}