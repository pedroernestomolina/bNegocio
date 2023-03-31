using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar
{
    public class Ficha
    {
        public string usuCodigo { get; set; }
        public string usuNombre { get; set; }
        public string estacion { get; set; }
        public string nota { get; set; }
        public decimal TasaDivisaNueva { get; set; }
        public NoAdmDivisa noAdmDivisa  { get; set; }
        public SiAdmDivisa siAdmDivisa { get; set; }
    }
}