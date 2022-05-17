using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData
{
 
   
    public class FichaHndPrecio
    {

        public string autoProducto { get; set; }
        public int idPrecio { get; set; }
        public decimal neto_1 { get; set; }
        public decimal neto_2 { get; set; }
        public decimal neto_3 { get; set; }
        public decimal fullDivisa_1 { get; set; }
        public decimal fullDivisa_2 { get; set; }
        public decimal fullDivisa_3 { get; set; }
        public bool esAdmDivisa { get; set; }


        public FichaHndPrecio()
        {
            autoProducto = "";
            idPrecio = -1;
            neto_1 = 0.0m;
            neto_2 = 0.0m;
            neto_3 = 0.0m;
            fullDivisa_1 = 0.0m;
            fullDivisa_2 = 0.0m;
            fullDivisa_3 = 0.0m;
            esAdmDivisa = false;
        }

    }

}