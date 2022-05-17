using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Helper.PasarPrecios.Insertar
{


    public class Ficha
    {

        public string autoProducto { get; set; }
        public string autoMedida1 { get; set; }
        public string autoMedida2 { get; set; }
        public string autoMedida3 { get; set; }
        public int cont1 { get; set; }
        public int cont2 { get; set; }
        public int cont3 { get; set; }
        public decimal neto1 { get; set; }
        public decimal neto2 { get; set; }
        public decimal neto3 { get; set; }
        public decimal utilidad1 { get; set; }
        public decimal utilidad2 { get; set; }
        public decimal utilidad3 { get; set; }
        public decimal fullDivisa1 { get; set; }
        public decimal fullDivisa2 { get; set; }
        public decimal fullDivisa3 { get; set; }
        public int idPrecio { get; set; }


        public Ficha() 
        {
            autoProducto = "";
            autoMedida1 = "";
            autoMedida2 = "";
            autoMedida3 = "";
            cont1 = 0;
            cont2 = 0;
            cont3 = 0;
            neto1 = 0.0m;
            neto2 = 0.0m;
            neto3 = 0.0m;
            utilidad1 = 0.0m;
            utilidad2 = 0.0m;
            utilidad3 = 0.0m;
            fullDivisa1 = 0.0m;
            fullDivisa2 = 0.0m;
            fullDivisa3 = 0.0m;
            idPrecio = -1;
        }

    }

}
