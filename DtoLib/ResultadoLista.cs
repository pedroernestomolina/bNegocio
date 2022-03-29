using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLib
{


    public class ResultadoLista<T> : Resultado
    {

        public List<T> Lista {get; set;}
        public int cntRegistro { get { return Lista == null ? 0 : Lista.Count(); } }


        public ResultadoLista()
            :base()
        {
            Lista = null;
        }

    }

}