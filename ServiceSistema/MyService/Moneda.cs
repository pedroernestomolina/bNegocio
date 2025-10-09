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
        public DtoLib.ResultadoEntidad<DtoLibSistema.Moneda.Entidad.Ficha> 
            Moneda_GetFichaById(int id)
        {
            return ServiceProv.Moneda_GetFichaById(id);
        }
    }
}