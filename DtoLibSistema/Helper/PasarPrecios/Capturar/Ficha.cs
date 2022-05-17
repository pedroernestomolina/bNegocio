using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Helper.PasarPrecios.Capturar
{


    public class Ficha
    {

        public string auto { get; set; }
        public string autoMedidaNeto1 { get; set; }
        public string autoMedidaNeto2 { get; set; }
        public string autoMedidaNeto3 { get; set; }
        public string autoMedidaNeto4 { get; set; }
        public string autoMedidaNeto5 { get; set; }
        public int contNeto1 { get; set; }
        public int contNeto2 { get; set; }
        public int contNeto3 { get; set; }
        public int contNeto4 { get; set; }
        public int contNeto5 { get; set; }
        public decimal utilidadNeto1 { get; set; }
        public decimal utilidadNeto2 { get; set; }
        public decimal utilidadNeto3 { get; set; }
        public decimal utilidadNeto4 { get; set; }
        public decimal utilidadNeto5 { get; set; }
        public decimal neto1 { get; set; }
        public decimal neto2 { get; set; }
        public decimal neto3 { get; set; }
        public decimal neto4 { get; set; }
        public decimal neto5 { get; set; }
        public decimal fullDivisa1 { get; set; }
        public decimal fullDivisa2 { get; set; }
        public decimal fullDivisa3 { get; set; }
        public decimal fullDivisa4 { get; set; }
        public decimal fullDivisa5 { get; set; }
        public string autoMay1{ get; set; }
        public int contMay1 { get; set; }
        public decimal utilMay1 { get; set; }
        public decimal precioMay1 { get; set; }
        public decimal fullDivisaMay1 { get; set; }


        public Ficha() 
        {
            auto = "";
            autoMedidaNeto1 = "";
            autoMedidaNeto2 = "";
            autoMedidaNeto3 = "";
            autoMedidaNeto4 = "";
            autoMedidaNeto5 = "";
            contNeto1 = 0;
            contNeto2 = 0;
            contNeto3 = 0;
            contNeto4 = 0;
            contNeto5 = 0;
            utilidadNeto1 = 0.0m;
            utilidadNeto2 = 0.0m;
            utilidadNeto3 = 0.0m;
            utilidadNeto4 = 0.0m;
            utilidadNeto5 = 0.0m;
            neto1 = 0.0m;
            neto2 = 0.0m;
            neto3 = 0.0m;
            neto4 = 0.0m;
            neto5 = 0.0m;
            fullDivisa1 = 0.0m;
            fullDivisa2 = 0.0m;
            fullDivisa3 = 0.0m;
            fullDivisa4 = 0.0m;
            fullDivisa5 = 0.0m;
            autoMay1 = "";
            contMay1 = 0;
            utilMay1 = 0.0m;
            precioMay1 = 0.0m;
            fullDivisaMay1 = 0.0m;
        }

    }

}