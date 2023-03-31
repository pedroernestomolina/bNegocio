using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar
{
    public class PrdSiAdmDivisa
    {
        public string autoprd { get; set; }
        public string descPrd { get; set; }
        public decimal costoProv { get; set; }
        public decimal costoProvUnd { get; set; }
        public decimal costoImp { get; set; }
        public decimal costoImpUnd { get; set; }
        public decimal costoVario { get; set; }
        public decimal costoVarioUnd { get; set; }
        public decimal costo { get; set; }
        public decimal costoUnd { get; set; }
    }
}