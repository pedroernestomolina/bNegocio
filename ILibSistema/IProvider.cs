using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibSistema
{
    
    public interface IProvider: IDeposito, ISucursal, IUsuario, 
        IFuncion, IGrupoUsuario, IServConf, IPermisos, IConfiguracion,
        IVendedor, ICobrador, ISerieFiscal, IReconversionMonetaria,
        INegocio, IControlAcceso, ITablaPrecio, ISucursalGrupo, 
        IPrecioEtiqueta, IMediosCobroPago
    {

        DtoLib.ResultadoEntidad<DateTime> FechaServidor();
        DtoLib.ResultadoEntidad<DtoLibSistema.Empresa.Data.Ficha> Empresa_Datos();

    }

}