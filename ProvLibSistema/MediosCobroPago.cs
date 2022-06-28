using LibEntitySistema;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace ProvLibSistema
{
    
    public partial class Provider : ILibSistema.IProvider
    {

        public DtoLib.ResultadoLista<DtoLibSistema.MediosCobroPago.Lista.Ficha> 
            MediosCobroPago_GetLista(DtoLibSistema.MediosCobroPago.Lista.Filtro filtro)
        {
            var result = new DtoLib.ResultadoLista<DtoLibSistema.MediosCobroPago.Lista.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter();
                    var sql_1 = @"SELECT 
                                        auto, 
                                        codigo, 
                                        nombre as descripcion, 
                                        estatus_cobro as estatusCobro,
                                        estatus_pago as estatusPago
                                    FROM empresa_medios";
                    var sql_2 = " where 1=1 ";
                    var sql = sql_1 + sql_2;
                    var lst = cnn.Database.SqlQuery<DtoLibSistema.MediosCobroPago.Lista.Ficha>(sql, p1).ToList();
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
        public DtoLib.ResultadoEntidad<DtoLibSistema.MediosCobroPago.Entidad.Ficha> 
            MediosCobroPago_GetFicha_ById(string id)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibSistema.MediosCobroPago.Entidad.Ficha>();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@auto", id);
                    var sql_1 = @"SELECT 
                                        auto, 
                                        codigo, 
                                        nombre as descripcion, 
                                        estatus_cobro as estatusCobro,
                                        estatus_pago as estatusPago
                                    FROM empresa_medios";
                    var sql_2 = " where auto=@auto ";
                    var sql = sql_1 + sql_2;
                    var ent = cnn.Database.SqlQuery<DtoLibSistema.MediosCobroPago.Entidad.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null) 
                    {
                        result.Mensaje = "ID MEDIO DE COBRO/PAGO NO REGISTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
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
        public DtoLib.ResultadoAuto 
            MediosCobroPago_AgregarFicha(DtoLibSistema.MediosCobroPago.Agregar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoAuto();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        var fechaNula = new DateTime(2000, 1, 1);

                        var sql = "update sistema_contadores set a_empresa_medios=a_empresa_medios+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            result.Mensaje = "PROBLEMA AL ACTUALIZAR TABLA CONTADORES";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        var auto = cnn.Database.SqlQuery<int>("select a_empresa_medios from sistema_contadores").FirstOrDefault();
                        var id = auto.ToString().Trim().PadLeft(10, '0');
                        var sql_2 = @"INSERT INTO empresa_medios (
                                        auto,
                                        codigo,
                                        nombre,
                                        estatus_cobro,
                                        estatus_pago
                                    )
                                    VALUES (
                                        @auto,
                                        @codigo, 
                                        @descripcion, 
                                        @estCobro,
                                        @estPago
                                    )";
                        var p1= new MySql.Data.MySqlClient.MySqlParameter("@auto",id);
                        var p2= new MySql.Data.MySqlClient.MySqlParameter("@codigo",ficha.codigo);
                        var p3= new MySql.Data.MySqlClient.MySqlParameter("@descripcion",ficha.descripcion);
                        var p4= new MySql.Data.MySqlClient.MySqlParameter("@estCobro",ficha.estatusCobro);
                        var p5= new MySql.Data.MySqlClient.MySqlParameter("@estPago",ficha.estatusPago);
                        var xr = cnn.Database.ExecuteSqlCommand(sql_2, p1,p2,p3,p4,p5);
                        if (xr==0)
                        {
                            result.Mensaje = "PROBLEMA AL REGISTRAR MEDIO DE COBRO/PAGO";
                            result.Result = DtoLib.Enumerados.EnumResult.isError;
                            return result;
                        }
                        cnn.SaveChanges();
                        ts.Complete();
                        result.Auto = id;
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
        public DtoLib.Resultado 
            MediosCobroPago_EditarFicha(DtoLibSistema.MediosCobroPago.Editar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();

            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var sql_2 = @"UPDATE empresa_medios SET 
                                        codigo=@codigo,
                                        nombre=@descripcion,
                                        estatus_cobro=@estCobro,
                                        estatus_pago=@estPago
                                    where auto=@auto";
                        var p1 = new MySql.Data.MySqlClient.MySqlParameter("@auto", ficha.auto);
                        var p2 = new MySql.Data.MySqlClient.MySqlParameter("@codigo", ficha.codigo);
                        var p3 = new MySql.Data.MySqlClient.MySqlParameter("@descripcion", ficha.descripcion);
                        var p4 = new MySql.Data.MySqlClient.MySqlParameter("@estCobro", ficha.estatusCobro);
                        var p5 = new MySql.Data.MySqlClient.MySqlParameter("@estPago", ficha.estatusPago);
                        var xr = cnn.Database.ExecuteSqlCommand(sql_2, p1, p2, p3, p4, p5);
                        if (xr == 0)
                        {
                            result.Mensaje = "PROBLEMA AL EDITAR MEDIO DE COBRO/PAGO";
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