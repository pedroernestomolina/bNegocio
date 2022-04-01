using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Deposito.Agregar
{


    public class Ficha
    {

        public string nombre { get; set; }
        public string autoSucursal { get; set; }
        public string codigoSucursal { get; set; }


        public Ficha() 
        {
            nombre = "";
            autoSucursal = "";
            codigoSucursal = "";
        }

    }

}