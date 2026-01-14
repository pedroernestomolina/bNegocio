using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibSistema.MediosCobroPago.Entidad
{
    public class Ficha: baseAgregarEditar
    {
        public string auto { get; set; }
        public Ficha()
        {
            auto = "";
            codigo = "";
            descripcion = "";
            estatusCobro = "";
            estatusPago = "";
            idMoneda = 0;
            aplicaParaEl_ModuloCobroAnticipo = "0";
            aplicaParaEl_POS = "0";
            aplicaParaEl_SolicitarLoteReferencia = "0";
            aplicaParaEl_BonoPagoEnDivisa = "0";
            aplicaParaEl_IGTF = "0";
            aplicaParaEl_RetornoCambioVuelto = "0";
        }
    }
}