using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.Sucursal.Entidad
{
    

    public class Ficha
    {

        public string auto { get; set; }
        public string autoGrupo { get; set; }
        public string autoDepositoPrincipal { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string estatus { get; set; }
        public string estatusFactMayor { get; set; }
        public string nombreGrupo { get; set; }
        public string nombreDepositoAsignado { get; set; }


        public Ficha() 
        {
            auto = "";
            autoGrupo = "";
            autoDepositoPrincipal = "";
            codigo = "";
            nombre = "";
            estatus = "";
            estatusFactMayor = "";
            nombreGrupo = "";
            nombreDepositoAsignado = "";
        }

    }

}