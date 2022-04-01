﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleSistema
{


    class Program
    {

        static void Main(string[] args)
        {
            ILibSistema.IProvider sistPrv = new ProvLibSistema.Provider("localhost", "pita");
            //var r01 = sistPrv.SucursalGrupo_GetLista();
            //var ficha = new DtoLibSistema.GrupoSucursal.Editar()
            //{
            //    auto="0000000003",
            //    nombre = "MAYOR",
            //    precioId = "4",
            //};
            //var r01 = sistPrv.SucursalGrupo_Editar(ficha);
            //var r01 = sistPrv.Sucursal_GetLista();
            //var r01 = sistPrv.Sucursal_GetFicha("0000000002");
            //var ficha = new DtoLibSistema.Sucursal.Editar()
            //{
            //    auto= "0000000004",
            //    autoGrupo = "0000000003",
            //    codigo = "MY-01",
            //    nombre = "MAYOR 01",
            //};
            //var r01 = sistPrv.Sucursal_Editar (ficha);
            //var ficha = new DtoLibSistema.Sucursal.AsignarDepositoPrincipal()
            //{
            //    auto = "0000000004",
            //    autoDepositoPrincipal = "0000000003",
            //};
            //var r01 = sistPrv.Sucursal_AsignarDepositoPrincipal(ficha);

            //var ficha = new DtoLibSistema.Deposito.Agregar()
            //{
            //    nombre = "VTA MAYOR TOCUYITO",
            //    codigo = "MY-TOCUYIT",
            //    autoSucursal = "0000000004",
            //    codigoSucursal = "MY-01",
            //};
            //var r01 = sistPrv.Deposito_Agregar(ficha);
            //var ficha = new DtoLibSistema.Precio.Etiquetar.Actualizar()
            //{
            //    descripcion_1 = "Pv1",
            //    descripcion_2 = "Pv2",
            //    descripcion_3 = "Pv3",
            //    descripcion_4 = "Pv4",
            //    descripcion_5 = "Pv5",
            //};
            //var r01 = sistPrv.Precio_Etiquetar_Actualizar(ficha);
            //var r01 = sistPrv.Precio_Etiquetar_GetFicha();
            //var r01 = sistPrv.Sucursal_GetLista();
            //var r00= sistPrv.Funcion_GetLista();
            //var list = new List<DtoLibSistema.GrupoUsuario.Permiso>();
            //foreach(var it in r00.Lista.OrderBy(o=>o.codigo).ToList())
            //{
            //    var p= new DtoLibSistema.GrupoUsuario.Permiso()
            //    {
            //         codigoFuncion=it.codigo,
            //         estatus="0",
            //         seguridad="Ninguna",
            //    };
            //    list.Add(p);
            //}
            //var ficha = new DtoLibSistema.GrupoUsuario.Agregar()
            //{
            //    nombre = "INVENTARIO",
            //    permisos = list,
            //};
            //var r01 = sistPrv.GrupoUsuario_Agregar(ficha);
            //var ficha = new DtoLibSistema.Configuracion.InicializarBD.Ficha()
            //{
            //    CodSucursal = "01",
            //    IdEquipo = "01",
            //};
            //var r01 = sistPrv.Inicializar_BD(ficha);
            //var r01 = sistPrv.Sucursal_GeneraCodigoAutomatico();
            //var r01 = sistPrv.Deposito_GeneraCodigoAutomatico ();

            //var r01 = sistPrv.Empresa_Datos();
            //var ficha = new DtoLibSistema.Usuario.Buscar.Ficha() { codigo = "01", clave = "" };
            //var r01 = sistPrv.Usuario_Buscar(ficha);
            //var r01 = sistPrv.Permiso_ToolSistema("0000000004");
            //var r01 = sistPrv.Configuracion_TasaRecepcionPos();
            //var ficha = new DtoLibSistema.Configuracion.ActualizarTasaRecepcionPos.Ficha() { ValorNuevo = 520000 };
            //var r01 = sistPrv.Configuracion_Actualizar_TasaRecepcionPos (ficha);
            //var r01 = sistPrv.Configuracion_Actualizar_TasaDivisa_CapturarData();

            //var filtro1 = new DtoLibSistema.Vendedor.Lista.Filtro();
            //var r01 = sistPrv.Vendedor_GetLista(filtro1);

            //var filtro2 = new DtoLibSistema.Cobrador.Lista.Filtro();
            //var r02 = sistPrv.Cobrador_GetLista(filtro2);

            //var filtro = new DtoLibSistema.SerieFiscal.Lista.Filtro();
            //var r02 = sistPrv.SerieFiscal_GetLista(filtro);

            //var r01 = sistPrv.SerieFiscal_GetFicha_ById("0000000001");

            //var r01 = sistPrv.ReconversionMonetaria_GetData();
            //var r01 = sistPrv.ReconversionMonetaria_GetCount();

            //var r01 = sistPrv.GrupoUsuario_GetUsuarios("0000000004");
            //var r01 = sistPrv.GrupoUsuario_Validar_EliminarGrupo("0000000012");
            //if (r01.Result != DtoLib.Enumerados.EnumResult.isError) 
            //{
            //    var r02 = sistPrv.GrupoUsuario_ELiminar("0000000012");
            //}

            //var filtro = new DtoLibSistema.Usuario.Lista.Filtro();
            //filtro.IdGrupo = "0000000004";
            //var r01 = sistPrv.Usuario_GetLista(filtro);

            //var r01 = sistPrv.Usuario_Eliminar("0000000026");

            //var r01 = sistPrv.Configuracion_Modulo_Capturar();

            //var ficha = new DtoLibSistema.Configuracion.Modulo.Actualizar.Ficha()
            //{
            //    claveNivMaximo = "123",
            //    claveNivMedio = "",
            //    claveNivMinimo = "",
            //    visualizarPrdInactivos = "No",
            //    cantDocVisualizar = 1500,
            //};
            //var r01 = sistPrv.Configuracion_Modulo_Actualizar(ficha);

            //var r01 = sistPrv.Deposito_Inactivar("0000000004");
            //var r01 = sistPrv.Deposito_Activar("0000000004");

            //var ficha = new DtoLibSistema.TablaPrecio.Crear.Ficha() { codigo = "05", descripcion = "BODEGA TIPO 5" };
            //var r01 = sistPrv.TablaPrecio_Crear(ficha);

            //var r01 = sistPrv.FechaServidor();


            //var ficha = new DtoLibSistema.TablaPrecio.Agregar.Ficha() { descripcion = "BODEGA TIPO 2" };
            //var r01 = sistPrv.TablaPrecio_Agregar(ficha);
            //var ficha = new DtoLibSistema.TablaPrecio.Editar.Ficha() { id = 6, descripcion = "BODEGA TIPO 1" };
            //var r01 = sistPrv.TablaPrecio_Editar(ficha);
            //var r01 = sistPrv.TablaPrecio_GetById(1);
            //var r01 = sistPrv.TablaPrecio_GetLista();


            //var r01 = sistPrv.SucursalGrupo_GetLista();
            //var r01 = sistPrv.SucursalGrupo_GetById("0000000008");
            //var ficha = new DtoLibSistema.GrupoSucursal.Agregar.Ficha() { idPrecio = 3, nombre = "BODEGA TIPO 3" };
            //var r01 = sistPrv.SucursalGrupo_Agregar (ficha);
            //var r01 = sistPrv.SucursalGrupo_Eliminar("0000000002");
            //var ficha = new DtoLibSistema.GrupoSucursal.Editar.Ficha() { auto = "0000000003", idPrecio = 3, nombre = "PRECIO TIPO 3" };
            //var r01 = sistPrv.SucursalGrupo_Editar(ficha);


            //var filtroDTO = new DtoLibSistema.Sucursal.Lista.Filtro() {  autoGrupo="0000000002"};
            //var r01 = sistPrv.Sucursal_GetLista(filtroDTO);
            //var fichaDTO = new DtoLibSistema.Sucursal.Agregar.Ficha()
            //{
            //    autoGrupo = "0000000002",
            //    estatusFactMayor = "1",
            //    nombre = "PRUEBA 1",
            //};
            //var r01 = sistPrv.Sucursal_Agregar(fichaDTO);
            //var r01 = sistPrv.Sucursal_GetFicha("0000000030");
            //var fichaDTO = new DtoLibSistema.Sucursal.Editar.Ficha()
            //{
            //    auto="0000000025",
            //    autoGrupo = "0000000001",
            //    estatusFactMayor = "0",
            //    nombre = "DISTRIB / VIVERES",
            //};
            //var r01 = sistPrv.Sucursal_Editar(fichaDTO);

        }

    }

}