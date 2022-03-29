using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceSistema.Interfaces
{
    
    public interface IFuncion
    {

        DtoLib.ResultadoLista<DtoLibSistema.Funciones.Resumen> Funcion_GetLista();

    }

}