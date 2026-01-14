using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Configuracion.Pos.Actualizar
{
    public class Ficha
    {
        public string Estacion { get; set; }
        public string Usuario { get; set; }
        public decimal tasaRecepcionPos { get; set; }
        public decimal factorCambio  { get; set; }
        public string permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa { get; set; }
        public string valorMaximoDescuentoPermitido { get; set; }
        public string porcAumentoPreciosDeProductosNoAdmPorDivisa { get; set; }
        public int idMonLocal { get; set; }
        public List<DtoLibSistema.AjustarTasaPos.AjustarData.Producto> productosAjustar  { get; set; }
        public List<DtoLibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio> historicoPreciosAgregar { get; set; }
        //
        public decimal ValorAnterior { get; set; }
        public decimal FactorVariacion { get; set; }
        public string MonedaCodigo { get; set; }
        public string MonedaSimbolo { get; set; }
        public string UsuarioCodigo { get; set; }
        public decimal TasaDivisaSistema { get; set; }
        public decimal PorctDiferenciaTasaSistemaTasaPos { get; set; }
        public decimal PorctBono { get; set; }
        public string HabilitarBono { get; set; }
        public decimal PorctAumentoPrdNoDivisa { get; set; }
        public Ficha()
        {
            Estacion = "";
            Usuario = "";
            tasaRecepcionPos = 0m;
            factorCambio = 0m;
            permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa = "";
            valorMaximoDescuentoPermitido = "";
            porcAumentoPreciosDeProductosNoAdmPorDivisa = "";
            productosAjustar = null;
            historicoPreciosAgregar = null;
            idMonLocal = -1;
            //
            ValorAnterior = 0m;
            FactorVariacion = 0m;
            MonedaCodigo = "";
            MonedaSimbolo = "";
            UsuarioCodigo = "";
            TasaDivisaSistema = 0m;
            PorctDiferenciaTasaSistemaTasaPos = 0m;
            PorctBono = 0m;
            HabilitarBono = "";
            PorctAumentoPrdNoDivisa = 0m;
        }
    }
}