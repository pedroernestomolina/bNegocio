using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.GrupoSucursal.Entidad
{


    public class Ficha
    {

        public string auto { get; set; }
        public int idPrecio { get; set; }
        public string nombre { get; set; }
        public string estatus { get; set; }
        public string refPrecio { get; set; }


        public Ficha()
        {
            auto = "";
            idPrecio = -1;
            nombre = "";
            estatus = "";
            refPrecio = "";
        }

    }

}