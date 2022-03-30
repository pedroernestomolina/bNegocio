using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceSistema.Interfaces
{
    
    public interface ITablaPrecio
    {

        DtoLib.ResultadoId
            TablaPrecio_Agregar(DtoLibSistema.TablaPrecio.Agregar.Ficha ficha);
        DtoLib.Resultado
            TablaPrecio_Editar(DtoLibSistema.TablaPrecio.Editar.Ficha ficha);
        DtoLib.ResultadoEntidad<DtoLibSistema.TablaPrecio.Entidad.Ficha>
            TablaPrecio_GetById(int id);
        DtoLib.ResultadoLista<DtoLibSistema.TablaPrecio.Lista.Ficha>
            TablaPrecio_GetLista();

    }

}