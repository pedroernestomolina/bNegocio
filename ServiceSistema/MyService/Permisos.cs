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

        public DtoLib.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMaximo()
        {
            return ServiceProv.Permiso_PedirClaveAcceso_NivelMaximo();
        }
        public DtoLib.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMedio()
        {
            return ServiceProv.Permiso_PedirClaveAcceso_NivelMedio();
        }
        public DtoLib.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMinimo()
        {
            return ServiceProv.Permiso_PedirClaveAcceso_NivelMinimo();
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ToolSistema(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ToolSistema (autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_InicializarBD(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_InicializarBD (autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_InicializarBD_Sucursal(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_InicializarBD_Sucursal (autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_AjustarTasaDivisa(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_AjustarTasaDivisa(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_AjustarTasaDivisaRecepcionPos(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_AjustarTasaDivisaRecepcionPos(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_EtiquetaParaPrecios(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_EtiquetaParaPrecios(autoGrupoUsuario);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_AsignarDepositoSucursal(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_AsignarDepositoSucursal(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_AsignarDepositoSucursal_EliminarAsignacion(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_AsignarDepositoSucursal_EliminarAsignacion(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_AsignarDepositoSucursal_EditarAsignacion(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_AsignarDepositoSucursal_EditarAsignacion(autoGrupoUsuario);
        }
        
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlSucursalGrupo(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlSucursalGrupo(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlSucursalGrupo_Agregar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlSucursalGrupo_Agregar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlSucursalGrupo_Editar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlSucursalGrupo_Editar(autoGrupoUsuario);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlSucursal(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlSucursal(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlSucursal_Agregar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlSucursal_Agregar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlSucursal_Editar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlSucursal_Editar(autoGrupoUsuario);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlDeposito(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlDeposito(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlDeposito_Agregar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlDeposito_Agregar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlDeposito_Editar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlDeposito_Editar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlDeposito_ActivarInactivar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlDeposito_ActivarInactivar(autoGrupoUsuario);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlUsuarioGrupo(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlUsuarioGrupo(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlUsuarioGrupo_Agregar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlUsuarioGrupo_Agregar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlUsuarioGrupo_Editar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlUsuarioGrupo_Editar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlUsuarioGrupo_Eliminar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlUsuarioGrupo_Eliminar(autoGrupoUsuario);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlUsuario(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlUsuario(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlUsuario_Agregar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlUsuario_Agregar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlUsuario_Editar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlUsuario_Editar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlUsuario_ActivarInactivar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlUsuario_ActivarInactivar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlUsuario_Eliminar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlUsuario_Eliminar(autoGrupoUsuario);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlVendedor(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlVendedor(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlVendedor_Agregar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlVendedor_Agregar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlVendedor_Editar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlVendedor_Editar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlVendedor_ActivarInactivar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlVendedor_ActivarInactivar(autoGrupoUsuario);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlCobrador(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlCobrador(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlCobrador_Agregar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlCobrador_Agregar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlCobrador_Editar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlCobrador_Editar(autoGrupoUsuario);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlSerieFiscal(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlSerieFiscal(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlSerieFiscal_Agregar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlSerieFiscal_Agregar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlSerieFiscal_Editar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlSerieFiscal_Editar(autoGrupoUsuario);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_ControlSerieFiscal_ActivarInactivar(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_ControlSerieFiscal_ActivarInactivar(autoGrupoUsuario);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Permiso.Ficha> Permiso_Configuracion_Sistema(string autoGrupoUsuario)
        {
            return ServiceProv.Permiso_Configuracion_Sistema(autoGrupoUsuario);
        }

    }

}