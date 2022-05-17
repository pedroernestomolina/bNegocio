using LibEntitySistema;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace ProvLibSistema
{

    public partial class Provider : ILibSistema.IProvider 
    {

        public DtoLib.ResultadoEntidad<DtoLibSistema.PrecioEtiqueta.Entidad.Ficha> 
            PrecioEtiqueta_GetFicha()
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibSistema.PrecioEtiqueta.Entidad.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var sql = @"select precio_1 as descripcion_1, 
                                precio_2 as descripcion_2, precio_3 as descripcion_3
                                from empresa";
                    var ent = cnn.Database.SqlQuery <DtoLibSistema.PrecioEtiqueta.Entidad.Ficha>(sql).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "[ EMPRESA ] NO ENCONTRADA";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    result.Entidad =ent ;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }

        public DtoLib.Resultado 
            PrecioEtiqueta_Actualizar(DtoLibSistema.PrecioEtiqueta.Actualizar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var sql = "";

                        var p1 = new MySqlParameter("@precio1", ficha.descripcion_1);
                        var p2 = new MySqlParameter("@precio2", ficha.descripcion_2);
                        var p3 = new MySqlParameter("@precio3", ficha.descripcion_3);
                        var p4 = new MySqlParameter("@precio4", "");
                        var p5 = new MySqlParameter("@precio5", "");
                        sql = @"update empresa set 
                                precio_1=@precio1, 
                                precio_2=@precio2, 
                                precio_3=@precio3, 
                                precio_4=@precio4, 
                                precio_5=@precio5";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5);
                        if (r1 == 0)
                        {
                            result.Mensaje = "[ EMPRESA ] PROBLEMA AL ACTUALIZAR";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();

                        ts.Complete();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result.Mensaje = Helpers.MYSQL_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (DbUpdateException ex)
            {
                result.Mensaje = Helpers.ENTITY_VerificaError(ex);
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }

    }

}