using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Configuracion.Pos.Capturar
{
    
    public class Ficha
    {

        public string tasaManejoDivisaSist { get; set; }
        public string tasaManejoDivisaPos { get; set; }
        public string permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa { get; set; }
        public string valorMaximoDescuentoPermitido { get; set; }


        public Ficha()
        {
            tasaManejoDivisaPos = "";
            tasaManejoDivisaSist = "";
            permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa ="";
            valorMaximoDescuentoPermitido = "";
        }

    }

}