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

        public DTO.ResultadoEntidad<DTO.Cliente.Ficha> 
            cli_ObtenerFicha(string codCli)
        {
            var result = new DTO.ResultadoEntidad<DTO.Cliente.Ficha>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@codCli", codCli);
                    var sql = @"SELECT 
                                    *
                                FROM v_saCliente_saTipoCliente
                                WHERE co_cli = @codCli";
                    var ent = ctx.Database.SqlQuery<DTO.Cliente.Ficha>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("[ CODIGO CLIENTE NO ENCONTRADO]");
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

    }

}