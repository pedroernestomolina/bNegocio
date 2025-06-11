using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.AjustarTasaPos.AjustarData
{
    public class HistoricoPrecio
    {
        public string idPrd { get; set; }
        public string nombrePrd { get; set; }
        public string motivoCambio { get; set; }
        public string identificadorPrecio { get; set; }
        public decimal precioNuevo { get; set; }
        public int contEmpq { get; set; }
        public string descEmpq { get; set; }
    }
}