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
        public string tasaRecepcionPos { get; set; }
        public decimal factorCambio  { get; set; }
        public string permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa { get; set; }
        public string valorMaximoDescuentoPermitido { get; set; }
        public string porcAumentoPreciosDeProductosNoAdmPorDivisa { get; set; }
        public int idMonLocal { get; set; }
        public List<DtoLibSistema.AjustarTasaPos.AjustarData.Producto> productosAjustar  { get; set; }
        public List<DtoLibSistema.AjustarTasaPos.AjustarData.HistoricoPrecio> historicoPreciosAgregar { get; set; }
        //
        public Ficha()
        {
            Estacion = "";
            Usuario = "";
            tasaRecepcionPos = "";
            factorCambio = 0m;
            permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa = "";
            valorMaximoDescuentoPermitido = "";
            porcAumentoPreciosDeProductosNoAdmPorDivisa = "";
            productosAjustar = null;
            historicoPreciosAgregar = null;
            idMonLocal = -1;
        }
    }
}