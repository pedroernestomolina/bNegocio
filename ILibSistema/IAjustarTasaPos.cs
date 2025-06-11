using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibSistema
{
    public interface IAjustarTasaPos
    {
        DtoLib.ResultadoEntidad<DtoLibSistema.AjustarTasaPos.CapturarData.Ficha>
           AjustarTasaPos_CapturarData();
    }
}
