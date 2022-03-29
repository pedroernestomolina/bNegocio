using LibEntitySistema;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace ProvLibSistema
{


    public partial class Provider : ILibSistema.IProvider
    {

        public DtoLib.ResultadoId 
            TablaPrecio_Agregar(DtoLibSistema.TablaPrecio.Agregar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoId();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {

                        var _codigo = "";
                        var cnt=cnn.empresa_hnd_precios.Count()+1;
                        if (cnt > 9)
                        {
                            result.Mensaje = "MAXIMO TIPO DE PRECIOS PERMITIDO ALCANZADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        _codigo = cnt.ToString();

                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@codigo", _codigo);
                        var p2 = new MySql.Data.MySqlClient.MySqlParameter("@descripcion", ficha.descripcion);
                        var sql_1 = @"INSERT INTO empresa_hnd_precios (id, codigo, descrpcion, estatus) 
                                    VALUES (NULL, @codigo, @descripcion, '1')";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql_1, p1, p2);
                        if (r1 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL GRABAR REGISTRO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();

                        var sql_2 = "select @@identity";
                        var id = cnn.Database.SqlQuery<int?>(sql_2).FirstOrDefault();
                        if (!id.HasValue)
                        {
                            result.Mensaje = "PROBLEMA AL GRABAR REGISTRO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        if (id.Value ==0)
                        {
                            result.Mensaje = "PROBLEMA AL GRABAR REGISTRO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }

                        var sql_3 = @"INSERT INTO productos_hnd_precios (
                                    id,
                                    idEmpresaPrecio,
                                    idProducto,
                                    idMedida_1,
                                    idMedida_2,
                                    contenido_1,
                                    neto_1,
                                    netoDivisa_1,
                                    utilidad_1,
                                    contenido_2,
                                    neto_2,
                                    netoDivisa_2,
                                    utilidad_2) 
                                    select NULL, @idPrecio, auto, '0000000001', '0000000001', 1, 0, 0, 0, 1, 0, 0, 0 
                                        from productos";
                        var xp1 = new MySql.Data.MySqlClient.MySqlParameter("@idPrecio", id.Value);
                        var r3 = cnn.Database.ExecuteSqlCommand(sql_3, xp1);
                        if (r3 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL EGISTRAR PRECIOS";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        ts.Complete();

                        result.Id = id.Value;
                        return result;
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    result.Mensaje = "REGISTRO CONTIENE DATA RELACIONADA";
                    result.Result = DtoLib.Enumerados.EnumResult.isError;
                    return result;
                }
                if (ex.Number == 1062)
                {
                    result.Mensaje = "CAMPO DUPLICADO" + Environment.NewLine + ex.Message;
                    result.Result = DtoLib.Enumerados.EnumResult.isError;
                    return result;
                }
                result.Mensaje = ex.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.Resultado 
            TablaPrecio_Editar(DtoLibSistema.TablaPrecio.Editar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var ent = cnn.empresa_hnd_precios.Find(ficha.id);
                        if (ent == null) 
                        {
                            result.Mensaje = "[ ID ] TABLA PRECIO NO ENCONTRADO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        ent.descrpcion = ficha.descripcion;
                        cnn.SaveChanges();
                        ts.Complete();

                        return result;
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                var dbUpdateEx = ex as DbUpdateException;
                var sqlEx = dbUpdateEx.InnerException;
                if (sqlEx != null)
                {
                    var exx = (MySql.Data.MySqlClient.MySqlException)sqlEx.InnerException;
                    if (exx != null)
                    {
                        if (exx.Number == 1451)
                        {
                            result.Mensaje = "REGISTRO CONTIENE DATA RELACIONADA";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        if (exx.Number == 1062)
                        {
                            result.Mensaje = "CAMPO DUPLICADO" + Environment.NewLine + exx.Message;
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                    }
                }
                result.Mensaje = ex.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;

        }
        public DtoLib.ResultadoEntidad<DtoLibSistema.TablaPrecio.Entidad.Ficha> 
            TablaPrecio_GetById(int id)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibSistema.TablaPrecio.Entidad.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@id", id);
                    var sql_1 = @"SELECT 
                                id, codigo, descrpcion as descripcion, estatus
                                FROM empresa_hnd_precios 
                                where id=@id";
                    var sql = sql_1;
                    var ent = cnn.Database.SqlQuery<DtoLibSistema.TablaPrecio.Entidad.Ficha>(sql,p1).FirstOrDefault();
                    if (ent == null) 
                    {
                        result.Mensaje = "[ ID ] TABLA PRECIO NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                    }
                    result.Entidad = ent;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.ResultadoLista<DtoLibSistema.TablaPrecio.Lista.Ficha> 
            TablaPrecio_GetLista()
        {
            var result = new DtoLib.ResultadoLista<DtoLibSistema.TablaPrecio.Lista.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var sql_1 = @"SELECT 
                                id, codigo, descrpcion as descripcion, estatus
                                FROM empresa_hnd_precios";
                    var sql = sql_1;
                    var lst = cnn.Database.SqlQuery<DtoLibSistema.TablaPrecio.Lista.Ficha>(sql).ToList();
                    result.Lista = lst;
                }
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