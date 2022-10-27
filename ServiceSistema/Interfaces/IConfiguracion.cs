using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceSistema.Interfaces
{
    
    public interface IConfiguracion
    {

        DtoLib.ResultadoEntidad<string>
            Configuracion_ModuloSistema_Modo();
        DtoLib.ResultadoEntidad<string>
            Configuracion_CalculoDiferenciaEntreTasas();
        DtoLib.Resultado
            Configuracion_Actualizar_CalculoDiferenciaEntreTasas(string modo);


        DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> 
            Configuracion_ForzarRedondeoPrecioVenta();
        DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio>
            Configuracion_PreferenciaRegistroPrecio();

        DtoLib.ResultadoEntidad<string> 
            Configuracion_TasaCambioActual();
        DtoLib.ResultadoEntidad<string> 
            Configuracion_TasaRecepcionPos();

        DtoLib.Resultado 
            Configuracion_Actualizar_TasaRecepcionPos(DtoLibSistema.Configuracion.ActualizarTasaRecepcionPos.Ficha ficha);
        DtoLib.ResultadoLista<DtoLibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha> 
            Configuracion_Actualizar_TasaDivisa_CapturarData();
        DtoLib.ResultadoLista<DtoLibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.dataHndPrecio>
            Configuracion_Actualizar_TasaDivisa_CapturarData_HndPrecio();
        DtoLib.Resultado
            Configuracion_Actualizar_TasaDivisa_ActualizarData(DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.Ficha ficha);
        
        DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Modulo.Capturar.Ficha> 
            Configuracion_Modulo_Capturar();
        DtoLib.Resultado 
            Configuracion_Modulo_Actualizar(DtoLibSistema.Configuracion.Modulo.Actualizar.Ficha ficha);

        DtoLib.ResultadoEntidad<DtoLibSistema.Configuracion.Pos.Capturar.Ficha>
            Configuracion_Pos_Capturar();
        DtoLib.Resultado
            Configuracion_Pos_Actualizar(DtoLibSistema.Configuracion.Pos.Actualizar.Ficha ficha);

    }

}