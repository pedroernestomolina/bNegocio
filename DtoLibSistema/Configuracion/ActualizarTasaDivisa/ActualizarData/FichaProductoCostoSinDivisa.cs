using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData
{
    public class FichaProductoCostoSinDivisa
    {
        public string autoPrd { get; set; }
        public decimal costoMonActual { get; set; }
        public decimal costoMonActualUnd { get; set; }
        public decimal costoDivisa { get; set; }
        public decimal precioMonedaEnDivisaFull_1 { get; set; }
        public decimal precioMonedaEnDivisaFull_2 { get; set; }
        public decimal precioMonedaEnDivisaFull_3 { get; set; }
        public decimal precioMonedaEnDivisaFull_4 { get; set; }
        public decimal precioMonedaEnDivisaFull_5 { get; set; }
        public decimal precioMonedaEnDivisaFull_May_1 { get; set; }
        public decimal precioMonedaEnDivisaFull_May_2 { get; set; }
        public decimal precioMonedaEnDivisaFull_May_3 { get; set; }
        public decimal precioMonedaEnDivisaFull_May_4 { get; set; }
        public decimal precioMonedaEnDivisaFull_Dsp_1 { get; set; }
        public decimal precioMonedaEnDivisaFull_Dsp_2 { get; set; }
        public decimal precioMonedaEnDivisaFull_Dsp_3 { get; set; }
        public decimal precioMonedaEnDivisaFull_Dsp_4 { get; set; }
        public decimal precio_1 { get; set; }
        public decimal precio_2 { get; set; }
        public decimal precio_3 { get; set; }
        public decimal precio_4 { get; set; }
        public decimal precio_5 { get; set; }
        public decimal precioMay_1 { get; set; }
        public decimal precioMay_2 { get; set; }
        public decimal precioMay_3 { get; set; }
        public decimal precioMay_4 { get; set; }
        public decimal precioDsp_1 { get; set; }
        public decimal precioDsp_2 { get; set; }
        public decimal precioDsp_3 { get; set; }
        public decimal precioDsp_4 { get; set; }
        public FichaProductoCostoSinDivisa()
        {
            autoPrd = "";
            costoDivisa = 0.0m;
            costoMonActual = 0m;
            costoMonActualUnd = 0m;
            precioMonedaEnDivisaFull_1 = 0.0m;
            precioMonedaEnDivisaFull_2 = 0.0m;
            precioMonedaEnDivisaFull_3 = 0.0m;
            precioMonedaEnDivisaFull_4 = 0.0m;
            precioMonedaEnDivisaFull_5 = 0.0m;
            precioMonedaEnDivisaFull_May_1 = 0.0m;
            precioMonedaEnDivisaFull_May_2 = 0.0m;
            precioMonedaEnDivisaFull_May_3 = 0.0m;
            precioMonedaEnDivisaFull_May_4 = 0.0m;
            precioMonedaEnDivisaFull_Dsp_1 = 0.0m;
            precioMonedaEnDivisaFull_Dsp_2 = 0.0m;
            precioMonedaEnDivisaFull_Dsp_3 = 0.0m;
            precioMonedaEnDivisaFull_Dsp_4 = 0.0m;
            precio_1 = 0.0m;
            precio_2 = 0.0m;
            precio_3 = 0.0m;
            precio_4 = 0.0m;
            precio_5 = 0.0m;
            precioMay_1 = 0.0m;
            precioMay_2 = 0.0m;
            precioMay_3 = 0.0m;
            precioMay_4 = 0.0m;
            precioDsp_1 = 0.0m;
            precioDsp_2 = 0.0m;
            precioDsp_3 = 0.0m;
            precioDsp_4 = 0.0m;
        }
    }
}