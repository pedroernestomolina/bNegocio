using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceSistema.Interfaces
{
    public interface IAjustarTasaPos
    {
        DtoLib.ResultadoEntidad<DtoLibSistema.AjustarTasaPos.CapturarData.Ficha>
           AjustarTasaPos_CapturarData();
    }
}