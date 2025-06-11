using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.AjustarTasaPos.CapturarData
{
    public class Item
    {
        public string idPrd { get; set; }
        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }

        public decimal p1 { get; set; }
        public decimal p2 { get; set; }
        public decimal p3 { get; set; }
        public decimal p4 { get; set; }

        public decimal may1 { get; set; }
        public decimal may2 { get; set; }
        public decimal may3 { get; set; }
        public decimal may4 { get; set; }

        public decimal dsp1 { get; set; }
        public decimal dsp2 { get; set; }
        public decimal dsp3 { get; set; }
        public decimal dsp4 { get; set; }

        public decimal contEmp1 { get; set; }
        public decimal contEmp2 { get; set; }
        public decimal contEmp3 { get; set; }

        public string descEmp1 { get; set; }
        public string descEmp2 { get; set; }
        public string descEmp3 { get; set; }
    }
}