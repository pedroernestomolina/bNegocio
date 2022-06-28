using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.MediosCobroPago
{
    
    public abstract class baseAgregarEditar
    {
        
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string estatusCobro {get;set;}
        public string estatusPago { get; set; }

    }

}