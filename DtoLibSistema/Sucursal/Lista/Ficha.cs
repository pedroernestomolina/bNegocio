using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Sucursal.Lista
{
    

    public class Ficha
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string estatus { get; set; }
        public string estatusFactMayor { get; set; }
        public string estatusVentaCredito { get; set; }
        public string nombreGrupo { get; set; }
        public string nombreDeposito { get; set; }


        public Ficha() 
        {
            auto = "";
            codigo = "";
            nombre = "";
            estatus = "";
            estatusFactMayor = "";
            estatusVentaCredito = "";
            nombreGrupo = "";
            nombreDeposito = "";
        }

    }

}