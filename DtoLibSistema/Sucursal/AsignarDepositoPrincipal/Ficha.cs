using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Sucursal.AsignarDepositoPrincipal
{


    public class Ficha
    {

        public string auto { get; set; }
        public string autoDepositoPrincipal { get; set; }


        public Ficha() 
        {
            auto = "";
            autoDepositoPrincipal = "";
        }

    }

}