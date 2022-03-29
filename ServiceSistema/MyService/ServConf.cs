using ServiceSistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceSistema.MyService
{
    
    public partial class Service : IService
    {

        public DtoLib.Resultado Inicializar_BD(DtoLibSistema.Configuracion.InicializarBD.Ficha ficha)
        {
            return ServiceProv.Inicializar_BD(ficha);
        }

    }

}
