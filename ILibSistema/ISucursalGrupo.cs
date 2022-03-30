using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibSistema
{
    
    public interface ISucursalGrupo
    {

        DtoLib.ResultadoLista<DtoLibSistema.GrupoSucursal.Lista.Ficha> 
            SucursalGrupo_GetLista();
        DtoLib.ResultadoEntidad<DtoLibSistema.GrupoSucursal.Entidad.Ficha>
            SucursalGrupo_GetById(string id);
        DtoLib.ResultadoAuto 
            SucursalGrupo_Agregar(DtoLibSistema.GrupoSucursal.Agregar.Ficha ficha);
        DtoLib.Resultado 
            SucursalGrupo_Editar (DtoLibSistema.GrupoSucursal.Editar.Ficha ficha);
        DtoLib.Resultado
            SucursalGrupo_Eliminar(string id);

    }

}