using DtoLib;
using LibEntitySistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibSistema
{
    public partial class Provider : ILibSistema.IProvider
    {
        public ResultadoLista<DtoLibSistema.SerieFiscal.Lista.Ficha> 
            SerieFiscal_GetLista(DtoLibSistema.SerieFiscal.Lista.Filtro filtro)
        {
            var rt = new ResultadoLista<DtoLibSistema.SerieFiscal.Lista.Ficha>();
            var _lst = new List<DtoLibSistema.SerieFiscal.Lista.Ficha>();
            //
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var sql = @"select 
                                    sf.auto as id, 
                                    sf.serie, 
                                    sf.correlativo, 
                                    sf.control, 
                                    sf.estatus  
                                from empresa_series_fiscales as sf 
                                where 1=1 ";
                    _lst = cnn.Database.SqlQuery<DtoLibSistema.SerieFiscal.Lista.Ficha>(sql).ToList();
                }
                rt.Lista = _lst;
                return rt;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
                return rt;
            }
        }
    }
}
