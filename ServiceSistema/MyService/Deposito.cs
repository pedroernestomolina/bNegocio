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

        public DtoLib.ResultadoLista<DtoLibSistema.Deposito.Lista.Ficha> 
            Deposito_GetLista(DtoLibSistema.Deposito.Lista.Filtro filtro)
        {
            return ServiceProv.Deposito_GetLista(filtro);
        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.Deposito.Entidad.Ficha> 
            Deposito_GetFicha(string auto)
        {
            return ServiceProv.Deposito_GetFicha(auto);
        }
        public DtoLib.ResultadoAuto 
            Deposito_Agregar(DtoLibSistema.Deposito.Agregar.Ficha ficha)
        {
            return ServiceProv.Deposito_Agregar(ficha);
        }
        public DtoLib.Resultado 
            Deposito_Editar(DtoLibSistema.Deposito.Editar.Ficha ficha)
        {
            return ServiceProv.Deposito_Editar(ficha);
        }
        public DtoLib.Resultado 
            Deposito_Activar(string id)
        {
            return ServiceProv.Deposito_Activar(id);
        }
        public DtoLib.Resultado 
            Deposito_Inactivar(string id)
        {
            return ServiceProv.Deposito_Inactivar(id);
        }

    }

}