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
        public DtoLib.ResultadoEntidad<DtoLibSistema.Moneda.Entidad.Ficha> 
            Moneda_GetFichaById(int id)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibSistema.Moneda.Entidad.Ficha>();
            //
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var _sql = @"select 
                                    id,
                                    codigo,
                                    nombre,
                                    simbolo,
                                    tasa_respecto_mon_referencia as tasaRespectoMonReferencia
                            from vl_currencies where id=@id";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@id", id);
                    var ent = cnn.Database.SqlQuery <DtoLibSistema.Moneda.Entidad.Ficha>(_sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("[ ID MONEDA ] NO ENCONTRADO");
                    }
                    result.Entidad = ent;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
        public DtoLib.ResultadoLista<DtoLibSistema.Moneda.Entidad.Ficha>
            Moneda_GetLista(DtoLibSistema.Moneda.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibSistema.Moneda.Entidad.Ficha>();
            //
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var _sql_1 = @"select 
                                    id,
                                    codigo,
                                    nombre,
                                    simbolo,
                                    tasa_respecto_mon_referencia as tasaRespectoMonReferencia
                            from vl_currencies";
                    var sql = _sql_1;
                    var list = cnn.Database.SqlQuery<DtoLibSistema.Moneda.Entidad.Ficha>(sql).ToList();
                    result.Lista = list;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
    }
}