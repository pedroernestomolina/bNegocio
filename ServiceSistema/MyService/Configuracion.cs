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

        public DtoLib.ResultadoEntidad<string> Configuracion_TasaCambioActual()
        {
            return ServiceProv.Configuracion_TasaCambioActual();
        }
        public DtoLib.ResultadoEntidad<string> Configuracion_TasaRecepcionPos()
        {
            return ServiceProv.Configuracion_TasaRecepcionPos();
        }

        public DtoLib.Resultado Configuracion_Actualizar_TasaRecepcionPos(DtoLibSistema.Configuracion.ActualizarTasaRecepcionPos.Ficha ficha)
        {
            return ServiceProv.Configuracion_Actualizar_TasaRecepcionPos(ficha);
        }
        public DtoLib.ResultadoLista<DtoLibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha> Configuracion_Actualizar_TasaDivisa_CapturarData()
        {
            return ServiceProv.Configuracion_Actualizar_TasaDivisa_CapturarData();
        }
        public DtoLib.Resultado Configuracion_Actualizar_TasaDivisa_ActualizarData(DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.Ficha ficha)
        {
            return ServiceProv.Configuracion_Actualizar_TasaDivisa_ActualizarData(ficha);
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> Configuracion_ForzarRedondeoPrecioVenta()
        {
            return ServiceProv.Configuracion_ForzarRedondeoPrecioVenta();
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio> Configuracion_PreferenciaRegistroPrecio()
        {
            return ServiceProv.Configuracion_PreferenciaRegistroPrecio();
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Modulo.Capturar.Ficha> Configuracion_Modulo_Capturar()
        {
            return ServiceProv.Configuracion_Modulo_Capturar();
        }
        public DtoLib.Resultado Configuracion_Modulo_Actualizar(DtoLibSistema.Configuracion.Modulo.Actualizar.Ficha ficha)
        {
            return ServiceProv.Configuracion_Modulo_Actualizar(ficha);
        }

    }

}