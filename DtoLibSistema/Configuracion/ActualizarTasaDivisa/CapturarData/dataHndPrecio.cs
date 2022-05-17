using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Configuracion.ActualizarTasaDivisa.CapturarData
{
 
   
    public class dataHndPrecio
    {

        public string autoProducto { get; set; }
        public string estatusDivisa { get; set; }
        public decimal tasaIva { get; set; }
        public int idPrecio { get; set; }
        public decimal neto_1 { get; set; }
        public decimal neto_2 { get; set; }
        public decimal neto_3 { get; set; }
        public decimal fullDivisa_1 { get; set; }
        public decimal fullDivisa_2 { get; set; }
        public decimal fullDivisa_3 { get; set; }
        public int cont_1 { get; set; }
        public int cont_2 { get; set; }
        public int cont_3 { get; set; }


        public dataHndPrecio() 
        {
            autoProducto = "";
            estatusDivisa = "";
            tasaIva = 0.0m;
            idPrecio = -1;
            neto_1 = 0.0m;
            neto_2 = 0.0m;
            neto_3 = 0.0m;
            fullDivisa_1 = 0.0m;
            fullDivisa_2 = 0.0m;
            fullDivisa_3 = 0.0m;
            cont_1 = 0;
            cont_2 = 0;
            cont_3 = 0;
        }

    }

}