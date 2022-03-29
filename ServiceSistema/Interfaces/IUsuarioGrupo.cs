using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceSistema.Interfaces
{

    public interface IUsuarioGrupo
    {

        DtoLib.ResultadoLista<DtoLibSistema.GrupoUsuario.Resumen> GrupoUsuario_GetLista();
        DtoLib.ResultadoEntidad<DtoLibSistema.GrupoUsuario.Ficha> GrupoUsuario_GetFicha(string auto);
        DtoLib.ResultadoAuto GrupoUsuario_Agregar(DtoLibSistema.GrupoUsuario.Agregar ficha);
        DtoLib.Resultado GrupoUsuario_Editar(DtoLibSistema.GrupoUsuario.Editar ficha);
        DtoLib.Resultado GrupoUsuario_ELiminar(string auto);
        DtoLib.ResultadoLista<DtoLibSistema.GrupoUsuario.Usuario> GrupoUsuario_GetUsuarios(string auto);

    }

}