using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibSistema
{
    public interface IAjustarTasaDivisa_ModoAdm
    {
        DtoLib.ResultadoLista<DtoLibSistema.AjustarTasaDivisa.ModoAdm.CapturarData>
            AjustarTasaDivisa_ModoAdm_CapturarData();
        DtoLib.ResultadoEntidad<int>
            AjustarTasaDivisa_ModoAdm_Ajustar(DtoLibSistema.AjustarTasaDivisa.ModoAdm.Ajustar.Ficha ficha);
    }
}