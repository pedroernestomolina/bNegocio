using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibSistema
{
    public interface IMoneda
    {
        DtoLib.ResultadoEntidad<DtoLibSistema.Moneda.Entidad.Ficha>
            Moneda_GetFichaById(int id);
    }
}