using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar
{
    public class SiAdmDivisa
    {
        public List<PrdSiAdmDivisa> prd { get; set; }
        public List<PrecioSiAdmDivisa> precio { get; set; }
        public List<Historia> historia { get; set; }
    }
}