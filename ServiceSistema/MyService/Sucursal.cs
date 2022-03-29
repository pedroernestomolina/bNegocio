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

        public DtoLib.ResultadoLista<DtoLibSistema.Sucursal.Resumen> Sucursal_GetLista()
        {
            return ServiceProv.Sucursal_GetLista();
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Sucursal.Ficha> Sucursal_GetFicha(string auto)
        {
            return ServiceProv.Sucursal_GetFicha(auto);
        }

        public DtoLib.ResultadoAuto Sucursal_Agregar(DtoLibSistema.Sucursal.Agregar ficha)
        {
            return ServiceProv.Sucursal_Agregar(ficha);
        }

        public DtoLib.Resultado Sucursal_Editar(DtoLibSistema.Sucursal.Editar ficha)
        {
            return ServiceProv.Sucursal_Editar(ficha);
        }

        public DtoLib.Resultado Sucursal_AsignarDepositoPrincipal(DtoLibSistema.Sucursal.AsignarDepositoPrincipal ficha)
        {
            return ServiceProv.Sucursal_AsignarDepositoPrincipal(ficha);
        }

        public DtoLib.Resultado Sucursal_QuitarDepositoPrincipal(string autoSuc)
        {
            return ServiceProv.Sucursal_QuitarDepositoPrincipal(autoSuc);
        }

        public DtoLib.ResultadoEntidad<int> Sucursal_GeneraCodigoAutomatico()
        {
            return ServiceProv.Sucursal_GeneraCodigoAutomatico();
        }

    }

}