﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceSistema.Interfaces
{

    public interface IService: ISucursal, IDeposito, ISucursalGrupo, IUsuario, IUsuarioGrupo,
        IFuncion, IServConf, IPermisos, IConfiguracion, IVendedor, ICobrador, ISerieFiscal, 
        IReconversionMonetaria,
        INegocio, IControlAcceso, ITablaPrecio, IPrecioEtiqueta 
    {

        DtoLib.ResultadoEntidad<DateTime> FechaServidor();
        DtoLib.ResultadoEntidad<DtoLibSistema.Empresa.Data.Ficha> Empresa_Datos();

    }

}
