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

        public DtoLib.ResultadoLista<DtoLibSistema.Sucursal.Lista.Ficha>
            Sucursal_GetLista(DtoLibSistema.Sucursal.Lista.Filtro filtro)
        {
            return ServiceProv.Sucursal_GetLista(filtro);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Sucursal.Entidad.Ficha>
            Sucursal_GetFicha(string auto)
        {
            return ServiceProv.Sucursal_GetFicha(auto);
        }
        public DtoLib.ResultadoAuto
            Sucursal_Agregar(DtoLibSistema.Sucursal.Agregar.Ficha ficha)
        {
            return ServiceProv.Sucursal_Agregar(ficha);
        }
        public DtoLib.Resultado
            Sucursal_Editar(DtoLibSistema.Sucursal.Editar.Ficha ficha)
        {
            return ServiceProv.Sucursal_Editar(ficha);
        }
        public DtoLib.Resultado
            Sucursal_AsignarDepositoPrincipal(DtoLibSistema.Sucursal.AsignarDepositoPrincipal.Ficha ficha)
        {
            return ServiceProv.Sucursal_AsignarDepositoPrincipal(ficha);
        }
        public DtoLib.Resultado
            Sucursal_QuitarDepositoPrincipal(string autoSuc)
        {
            return ServiceProv.Sucursal_QuitarDepositoPrincipal(autoSuc);
        }
        public DtoLib.Resultado 
            Sucursal_Activar(string autoSuc)
        {
            return ServiceProv.Sucursal_Activar(autoSuc);
        }
        public DtoLib.Resultado 
            Sucursal_Inactivar(string autoSuc)
        {
            return ServiceProv.Sucursal_Inactivar(autoSuc);
        }

    }

}