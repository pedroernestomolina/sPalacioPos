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
        public DTO.ResultadoLista<DTO.Sistema.CajaPago.Lista> 
            cjPago_Lista()
        {
            var result = new DTO.ResultadoLista<DTO.Sistema.CajaPago.Lista>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var sql = @"SELECT 
                                    [Extent1].[cod_caja] AS [cod_caja], 
                                    [Extent1].[descrip] AS [descrip], 
                                    [Extent1].[inactivo] AS [inactivo] 
                                FROM saCaja AS [Extent1]";
                    var lst = ctx.Database.SqlQuery<DTO.Sistema.CajaPago.Lista>(sql).ToList();
                    result.Lista = lst;
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
        public DTO.ResultadoEntidad<DTO.Sistema.CajaPago.Ficha> 
            cjPago_GetCajaPagoById(string codCjaPago)
        {
            var result = new DTO.ResultadoEntidad<DTO.Sistema.CajaPago.Ficha>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@codCaja", codCjaPago);
                    var sql = @"SELECT 
                                    [Extent1].[cod_caja] AS [cod_caja], 
                                    [Extent1].[descrip] AS [descrip], 
                                    [Extent1].[co_mone] AS [co_mone], 
                                    [Extent1].[inactivo] AS [inactivo], 
                                    [Extent1].[rowguid] AS [rowguid] 
                                FROM [saCaja] AS [Extent1]
                                WHERE [Extent1].[cod_caja] = @codCaja";
                    var ent = ctx.Database.SqlQuery<DTO.Sistema.CajaPago.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null) 
                    {
                        throw new Exception("CODIGO DE CAJA NO ENCONTRADO");
                    }
                    result.Entidad= ent;
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