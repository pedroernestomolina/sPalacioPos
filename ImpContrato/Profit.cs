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

        public DTO.ResultadoEntidad<DateTime>
            Test_2()
        {
            var result = new DTO.ResultadoEntidad<DateTime>();
            try
            {
                using (var ctx = new  pPanEntities(_gestion.ConnectionString))
                {
                    var sql = @"SELECT GETDATE()";
                    var ent = ctx.Database.SqlQuery<DateTime>(sql).FirstOrDefault();
                    result.Entidad = ent;
                    return result;
                }
            }
            catch (Exception e)
            {
                var msgE = "";
                if (e.InnerException != null)
                {
                    msgE = e.InnerException.Message;
                }
                result.Mensaje = e.Message + Environment.NewLine + msgE;
                result.Result = DTO.Enumerados.EnumResult.isError;
            }

            return result;
        }




        public DTO.ResultadoEntidad<DTO.GESTION.PAR_EMP> 
            SeleccionarParametrosEmpresa(string codEmpresa)
        {
            var result = new DTO.ResultadoEntidad<DTO.GESTION.PAR_EMP>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@sCOD_EMP", codEmpresa);
                    var ent = ctx.Database.SqlQuery<DTO.GESTION.PAR_EMP>("pSeleccionarParametrosEmpresa @sCOD_EMP", p1).FirstOrDefault();
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


        public DTO.ResultadoLista<DTO.GESTION.SucursalLista> 
            Get_Sucursales()
        {
            var result = new DTO.ResultadoLista<DTO.GESTION.SucursalLista>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var sql = @"SELECT 
                                    co_sucur, 
                                    sucur_des,
                                    1 AS C1, 
                                    CASE 
                                        WHEN (co_sucur IS NULL) THEN '' 
                                        ELSE 'PVDemo2k12Model.saSucursal' 
                                    END AS [C2], 
	                                'co_sucur,sucur_des' AS [C3]
                            	FROM saSucursal";
                    var lst = ctx.Database.SqlQuery<DTO.GESTION.SucursalLista>(sql).ToList();
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
        public DTO.ResultadoEntidad<DTO.GESTION.Sucursal>
            Get_SucursalById(string codSuc)
        {
            var result = new DTO.ResultadoEntidad<DTO.GESTION.Sucursal>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var sql = @"SELECT *
                            	FROM saSucursal
                                WHERE co_sucur= @codSuc";
                    var p1 = new SqlParameter("@codSuc", codSuc);
                    var ent = ctx.Database.SqlQuery<DTO.GESTION.Sucursal>(sql,p1).FirstOrDefault();
                    if (ent == null) 
                    {
                        throw new Exception("CODIGO SUCURSAL NO REGISTRADO");
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