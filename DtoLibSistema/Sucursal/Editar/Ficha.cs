using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Sucursal.Editar
{

    
    public class Ficha
    {

        public string auto { get; set; }
        public string autoGrupo { get; set; }
        public string nombre { get; set; }
        public string estatusFactMayor { get; set; }


        public Ficha() 
        {
            auto = "";
            autoGrupo = "";
            nombre = "";
            estatusFactMayor = "";
        }

    }

}