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
            //
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
                                        estatus_pago as estatusPago,
                                        estatus_cobro_gAnticipo as aplicaParaEl_ModuloCobroAnticipo, 
                                        aplica_en_pos as aplicaParaEl_POS, 
                                        id_currencies as idMoneda, 
                                        aplica_lote_referencia as aplicaParaEl_SolicitarLoteReferencia, 
                                        aplica_bono_pago_divisa as aplicaParaEl_BonoPagoEnDivisa, 
                                        aplica_igtf as aplicaParaEl_IGTF, 
                                        aplica_retorno_cambio_vuelto as aplicaParaEl_RetornoCambioVuelto 
                                    FROM empresa_medios";
                    var sql_2 = " where auto=@auto ";
                    var sql = sql_1 + sql_2;
                    var ent = cnn.Database.SqlQuery<DtoLibSistema.MediosCobroPago.Entidad.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null) 
                    {
                        throw new Exception("ID MEDIO DE COBRO/PAGO NO REGISTRADO");
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
        public DtoLib.ResultadoAuto 
            MediosCobroPago_AgregarFicha(DtoLibSistema.MediosCobroPago.Agregar.Ficha ficha)
        {
            var result = new DtoLib.ResultadoAuto();
            //
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var fechaSistema = cnn.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                        //
                        var sql = "update sistema_contadores set a_empresa_medios=a_empresa_medios+1";
                        var r1 = cnn.Database.ExecuteSqlCommand(sql);
                        if (r1 == 0)
                        {
                            throw new Exception("PROBLEMA AL ACTUALIZAR CONTADORES");
                        }
                        var auto = cnn.Database.SqlQuery<int>("select a_empresa_medios from sistema_contadores").FirstOrDefault();
                        var id = auto.ToString().Trim().PadLeft(10, '0');
                        //
                        var sql_2 = @"INSERT INTO empresa_medios (
                                        auto,
                                        codigo,
                                        nombre,
                                        estatus_cobro,
                                        estatus_pago,
                                        estatus_cobro_gAnticipo, 
                                        aplica_en_pos, 
                                        id_currencies, 
                                        aplica_lote_referencia, 
                                        aplica_bono_pago_divisa, 
                                        aplica_igtf, 
                                        aplica_retorno_cambio_vuelto
                                    )
                                    VALUES (
                                        @auto,
                                        @codigo, 
                                        @descripcion, 
                                        @estCobro,
                                        @estPago,
                                        @estatus_cobro_gAnticipo, 
                                        @aplica_en_pos, 
                                        @id_currencies, 
                                        @aplica_lote_referencia, 
                                        @aplica_bono_pago_divisa, 
                                        @aplica_igtf, 
                                        @aplica_retorno_cambio_vuelto
                                    )";
                        var p01= new MySql.Data.MySqlClient.MySqlParameter("@auto",id);
                        var p02= new MySql.Data.MySqlClient.MySqlParameter("@codigo",ficha.codigo);
                        var p03= new MySql.Data.MySqlClient.MySqlParameter("@descripcion",ficha.descripcion);
                        var p04= new MySql.Data.MySqlClient.MySqlParameter("@estCobro",ficha.estatusCobro);
                        var p05= new MySql.Data.MySqlClient.MySqlParameter("@estPago",ficha.estatusPago);
                        var p06= new MySql.Data.MySqlClient.MySqlParameter("@estatus_cobro_gAnticipo",ficha.aplicaParaEl_ModuloCobroAnticipo);
                        var p07= new MySql.Data.MySqlClient.MySqlParameter("@aplica_en_pos", ficha.aplicaParaEl_POS);
                        var p08= new MySql.Data.MySqlClient.MySqlParameter("@id_currencies", ficha.idMoneda);
                        var p09= new MySql.Data.MySqlClient.MySqlParameter("@aplica_lote_referencia",ficha.aplicaParaEl_SolicitarLoteReferencia);
                        var p10= new MySql.Data.MySqlClient.MySqlParameter("@aplica_bono_pago_divisa",ficha.aplicaParaEl_BonoPagoEnDivisa);
                        //
                        var p11= new MySql.Data.MySqlClient.MySqlParameter("@aplica_igtf", ficha.aplicaParaEl_IGTF);
                        var p12= new MySql.Data.MySqlClient.MySqlParameter("@aplica_retorno_cambio_vuelto", ficha.aplicaParaEl_RetornoCambioVuelto);
                        //
                        var xr = cnn.Database.ExecuteSqlCommand(sql_2,
                            p01, p02, p03, p04, p05, p06,
                            p07, p08, p09, p10, p11, p12);
                        if (xr==0)
                        {
                            throw new Exception("PROBLEMA AL REGISTRAR MEDIO DE COBRO/PAGO");
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
            //
            return result;
        }
        public DtoLib.Resultado 
            MediosCobroPago_EditarFicha(DtoLibSistema.MediosCobroPago.Editar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();
            //
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
                                        estatus_pago=@estPago,
                                        estatus_cobro_gAnticipo=@estatus_cobro_gAnticipo, 
                                        aplica_en_pos=@aplica_en_pos, 
                                        id_currencies=@id_currencies, 
                                        aplica_lote_referencia=@aplica_lote_referencia, 
                                        aplica_bono_pago_divisa=@aplica_bono_pago_divisa, 
                                        aplica_igtf=@aplica_igtf, 
                                        aplica_retorno_cambio_vuelto=@aplica_retorno_cambio_vuelto
                                    where auto=@auto";
                        var p01 = new MySql.Data.MySqlClient.MySqlParameter("@auto", ficha.auto);
                        var p02 = new MySql.Data.MySqlClient.MySqlParameter("@codigo", ficha.codigo);
                        var p03 = new MySql.Data.MySqlClient.MySqlParameter("@descripcion", ficha.descripcion);
                        var p04 = new MySql.Data.MySqlClient.MySqlParameter("@estCobro", ficha.estatusCobro);
                        var p05 = new MySql.Data.MySqlClient.MySqlParameter("@estPago", ficha.estatusPago);
                        var p06 = new MySql.Data.MySqlClient.MySqlParameter("@estatus_cobro_gAnticipo", ficha.aplicaParaEl_ModuloCobroAnticipo);
                        var p07 = new MySql.Data.MySqlClient.MySqlParameter("@aplica_en_pos", ficha.aplicaParaEl_POS);
                        var p08 = new MySql.Data.MySqlClient.MySqlParameter("@id_currencies", ficha.idMoneda);
                        var p09 = new MySql.Data.MySqlClient.MySqlParameter("@aplica_lote_referencia", ficha.aplicaParaEl_SolicitarLoteReferencia);
                        var p10 = new MySql.Data.MySqlClient.MySqlParameter("@aplica_bono_pago_divisa", ficha.aplicaParaEl_BonoPagoEnDivisa);
                        //
                        var p11 = new MySql.Data.MySqlClient.MySqlParameter("@aplica_igtf", ficha.aplicaParaEl_IGTF);
                        var p12 = new MySql.Data.MySqlClient.MySqlParameter("@aplica_retorno_cambio_vuelto", ficha.aplicaParaEl_RetornoCambioVuelto);
                        //
                        var xr = cnn.Database.ExecuteSqlCommand(sql_2,
                                    p01, p02, p03, p04, p05, p06,
                                    p07, p08, p09, p10, p11, p12);
                        if (xr == 0)
                        {
                            throw new Exception("PROBLEMA AL EDITAR MEDIO DE COBRO/PAGO");
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
            //
            return result;
        }
    }
}