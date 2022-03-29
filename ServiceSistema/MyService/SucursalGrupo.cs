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

        public DtoLib.ResultadoLista<DtoLibSistema.GrupoSucursal.Resumen> SucursalGrupo_GetLista()
        {
            return ServiceProv.SucursalGrupo_GetLista();
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.GrupoSucursal.Ficha> SucursalGrupo_GetFicha(string auto)
        {
            return ServiceProv.SucursalGrupo_GetFicha(auto);
        }

        public DtoLib.ResultadoAuto SucursalGrupo_Agregar(DtoLibSistema.GrupoSucursal.Agregar ficha)
        {
            return ServiceProv.SucursalGrupo_Agregar(ficha);
        }

        public DtoLib.Resultado SucursalGrupo_Editar(DtoLibSistema.GrupoSucursal.Editar ficha)
        {
            return ServiceProv.SucursalGrupo_Editar(ficha);
        }

    }

}