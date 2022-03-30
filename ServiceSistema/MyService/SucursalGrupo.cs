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

        public DtoLib.ResultadoLista<DtoLibSistema.GrupoSucursal.Lista.Ficha> 
            SucursalGrupo_GetLista()
        {
            return ServiceProv.SucursalGrupo_GetLista();
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.GrupoSucursal.Entidad.Ficha> 
            SucursalGrupo_GetFicha(string auto)
        {
            return ServiceProv.SucursalGrupo_GetById(auto);
        }
        public DtoLib.ResultadoAuto 
            SucursalGrupo_Agregar(DtoLibSistema.GrupoSucursal.Agregar.Ficha ficha)
        {
            return ServiceProv.SucursalGrupo_Agregar(ficha);
        }
        public DtoLib.Resultado 
            SucursalGrupo_Editar(DtoLibSistema.GrupoSucursal.Editar.Ficha ficha)
        {
            return ServiceProv.SucursalGrupo_Editar(ficha);
        }
        public DtoLib.Resultado 
            SucursalGrupo_Eliminar(string id)
        {
            return ServiceProv.SucursalGrupo_Eliminar(id);
        }

    }

}