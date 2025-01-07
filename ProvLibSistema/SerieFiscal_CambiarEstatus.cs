using DtoLib;
using LibEntitySistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace ProvLibSistema
{
    public partial class Provider : ILibSistema.IProvider
    {
        public Resultado 
            SerieFiscal_Activar(DtoLibSistema.SerieFiscal.ActivarInactivar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();
            //
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var _sql = @"update empresa_series_fiscales set 
                                        estatus='Activo'
                                    where auto=@p1";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", ficha.id);
                    var rt = cnn.Database.ExecuteSqlCommand(_sql, p1);
                    if (rt == 0)
                    {
                        throw new Exception("PROBLEMA AL ACTUALIZAR ESTATUS [ SERIE FISCAL ]");
                    }
                    cnn.SaveChanges();
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

        public DtoLib.Resultado 
            SerieFiscal_Inactivar(DtoLibSistema.SerieFiscal.ActivarInactivar.Ficha ficha)
        {
            var result = new DtoLib.Resultado();
            //
            try
            {
                using (var cnn = new sistemaEntities(_cnSist.ConnectionString))
                {
                    var _sql = @"update empresa_series_fiscales set 
                                        estatus='Inactivo'
                                    where auto=@p1";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@p1", ficha.id);
                    var rt = cnn.Database.ExecuteSqlCommand(_sql, p1);
                    if (rt == 0)
                    {
                        throw new Exception("PROBLEMA AL ACTUALIZAR ESTATUS [ SERIE FISCAL ]");
                    }
                    cnn.SaveChanges();
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