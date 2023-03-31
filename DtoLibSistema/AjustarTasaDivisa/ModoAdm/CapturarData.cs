using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.AjustarTasaDivisa.ModoAdm
{
    public class CapturarData
    {
        public string autoPrd { get; set; }
        public string codigoPrd { get; set; }
        public string descPrd { get; set; }
        public string estatusDivisa { get; set; }
        public decimal costoMonLocalEmpCompra { get; set; }
        public decimal costoDivisaEmpCompra { get; set; }
        public int contEmpCompra { get; set; }
        public int idPrecioVta { get; set; }
        public decimal pNetoMonLocalEmpVta { get; set; }
        public decimal pFullDivisaEmpVta { get; set; }
        public int contEmpVta { get; set; }
        public decimal tasaIva { get; set; }
        public string tipoEmpVta { get; set; }
        public string descEmpVta { get; set; }
    }
}