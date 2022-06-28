using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.MediosCobroPago.Lista
{
    
    public class Ficha
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string estatusCobro {get;set;}
        public string estatusPago { get; set; }


        public Ficha()
        {
            auto = "";
            codigo = "";
            descripcion="";
            estatusCobro="";
            estatusPago="";
        }

    }

}