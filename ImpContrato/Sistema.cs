using PROFIT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImpContrato
{
    
    public partial class Provider: Contrato.IProvider
    {

        public DTO.ResultadoEntidad<DTO.Sistema.Vendedor.Ficha> 
            sist_vend_ObtenerFicha(string codVen)
        {
            var result = new DTO.ResultadoEntidad<DTO.Sistema.Vendedor.Ficha>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@codVen", codVen);
                    var sql = @"SELECT 
                                        *
                                FROM saVendedor
                                WHERE co_ven = @codVen";
                    var ent = ctx.Database.SqlQuery<DTO.Sistema.Vendedor.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("[ CODIGO VENDEDOR NO ENCONTRADO]");
                    }
                    result.Entidad = ent;
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DTO.ResultadoEntidad<DTO.Sistema.CondPago.Ficha> 
            sist_condPago_ObtenerFicha(string codCond)
        {
            var result = new DTO.ResultadoEntidad<DTO.Sistema.CondPago.Ficha>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@codCond", codCond);
                    var sql = @"SELECT 
                                        *
                                FROM saCondicionPago
                                WHERE co_cond=@codCond";
                    var ent = ctx.Database.SqlQuery<DTO.Sistema.CondPago.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("[ CODIGO COND PAGO NO ENCONTRADO]");
                    }
                    result.Entidad = ent;
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DTO.ResultadoEntidad<DTO.Sistema.Transporte.Ficha>
            sist_transporte_ObtenerFicha(string codTrans)
        {
            var result = new DTO.ResultadoEntidad<DTO.Sistema.Transporte.Ficha>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@codTrans", codTrans);
                    var sql = @"SELECT 
                                        *
                                FROM saTransporte
                                WHERE co_tran=@codTrans";
                    var ent = ctx.Database.SqlQuery<DTO.Sistema.Transporte.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("[ CODIGO TRANSPORTE PAGO NO ENCONTRADO]");
                    }
                    result.Entidad = ent;
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DTO.ResultadoEntidad<DTO.Sistema.Moneda.Ficha> 
            sist_moneda_ObtenerFicha(string codMone)
        {
            var result = new DTO.ResultadoEntidad<DTO.Sistema.Moneda.Ficha>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@codMone", codMone);
                    var sql = @"SELECT 
                                        *
                                FROM saMoneda
                                WHERE co_mone=@codMone";
                    var ent = ctx.Database.SqlQuery<DTO.Sistema.Moneda.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("[ CODIGO MONEDA NO ENCONTRADO]");
                    }
                    result.Entidad = ent;
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DTO.ResultadoEntidad<DTO.Sistema.TasaCambio.ObtenerFechaTasa> 
            sist_ObtenerFechaTasa(string codMoneda, DateTime fecha)
        {
            var result = new DTO.ResultadoEntidad<DTO.Sistema.TasaCambio.ObtenerFechaTasa>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@sCo_Mone", codMoneda);
                    var p2 = new SqlParameter("@dtFecha", fecha);
                    var sql = @"exec pObtenerFechaTasa @sCo_Mone, @dtFecha";
                    var ent = ctx.Database.SqlQuery<DTO.Sistema.TasaCambio.ObtenerFechaTasa>(sql, p1, p2).FirstOrDefault();
                    result.Entidad = ent;
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.Enumerados.EnumResult.isError;
            }
            return result;
        }

    }

}