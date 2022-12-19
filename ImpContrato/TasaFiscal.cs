using MASTER;
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

        public DTO.ResultadoLista<DTO.TasaFiscal.Tipo> 
            tasa_ObtenerTipoTasaFiscal()
        {
            var result = new DTO.ResultadoLista<DTO.TasaFiscal.Tipo>();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var sql = @"Select 
                                    rtrim(co_fijo) as co_fijo,
                                    orden,  
                                    rtrim(desc_fijo) as desc_fijo 
                                    from MpFijo 
                                Where co_grupo = 'ISV' and Producto = 'ADMI' 
                                Order by orden";
                    var lst = ctx.Database.SqlQuery<DTO.TasaFiscal.Tipo>(sql).ToList();
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
        public DTO.ResultadoLista<DTO.TasaFiscal.TipoValor> 
            tasa_ObtenerTasaPorTipoValor(DateTime fecha)
        {
            var result = new DTO.ResultadoLista<DTO.TasaFiscal.TipoValor>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@dtFecha", fecha);
                    var sql = "pObtenerFechaImpuestoSobreVenta @dtFecha";
                    var lst = ctx.Database.SqlQuery<DTO.TasaFiscal.TipoValor>(sql, p1).ToList();
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

    }

}