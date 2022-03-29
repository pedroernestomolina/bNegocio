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

        public static ILibSistema.IProvider ServiceProv;


        public Service(string instancia, string bd, string usuario="root")
        {
            ServiceProv = new ProvLibSistema.Provider(instancia, bd, usuario);
        }


        public DtoLib.ResultadoEntidad<DateTime> FechaServidor()
        {
            return ServiceProv.FechaServidor();
        }

        public DtoLib.ResultadoEntidad<DtoLibSistema.Empresa.Data.Ficha> Empresa_Datos()
        {
            return ServiceProv.Empresa_Datos();
        }

    }

}