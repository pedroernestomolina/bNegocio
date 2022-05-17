using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceSistema.Interfaces
{

    public interface IPrecioEtiqueta
    {

        DtoLib.ResultadoEntidad<DtoLibSistema.PrecioEtiqueta.Entidad.Ficha>
            PrecioEtiqueta_GetFicha();
        DtoLib.Resultado 
            PrecioEtiqueta_Actualizar(DtoLibSistema.PrecioEtiqueta.Actualizar.Ficha ficha);

    }

}