using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Sucursal.Agregar
{

    
    public class Ficha
    {


        public string autoGrupo { get; set; }
        public string nombre { get; set; }
        public string estatusFactMayor { get; set; }
        public string estatusVentaCredito { get; set; }


        public Ficha()
        {
            autoGrupo = "";
            nombre = "";
            estatusFactMayor = "";
            estatusVentaCredito = "";
        }

    }

}