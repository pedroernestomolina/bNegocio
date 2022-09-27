using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Configuracion.Pos.Actualizar
{
    
    public class Ficha
    {

        public string  tasaRecepcionPos { get; set; }
        public string permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa { get; set; }
        public string valorMaximoDescuentoPermitido { get; set; }


        public Ficha()
        {
            tasaRecepcionPos = "";
            permitirDarDescuentoEnPosUnicamenteSiPagoEnDivisa = "";
            valorMaximoDescuentoPermitido = "";
        }

    }

}