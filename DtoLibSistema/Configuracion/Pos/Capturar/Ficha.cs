using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Configuracion.Pos.Capturar
{
    
    public class Ficha
    {

        public string permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa { get; set; }
        public string valorMaximoDescuentoPermitido { get; set; }


        public Ficha()
        {
            permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa ="";
            valorMaximoDescuentoPermitido = "";
        }

    }

}