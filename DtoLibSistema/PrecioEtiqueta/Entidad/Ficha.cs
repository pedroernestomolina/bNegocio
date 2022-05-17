using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.PrecioEtiqueta.Entidad
{


    public class Ficha
    {

        public string descripcion_1 { get; set; }
        public string descripcion_2 { get; set; }
        public string descripcion_3 { get; set; }


        public Ficha() 
        {
            descripcion_1 = "";
            descripcion_2 = "";
            descripcion_3 = "";
        }

    }

}