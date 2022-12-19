using MASTER;
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
            Test_1()
        {
            var result = new DTO.ResultadoEntidad<DateTime>();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var sql = @"SELECT GETDATE()";
                    var ent = ctx.Database.SqlQuery<DateTime>(sql).FirstOrDefault();
                    result.Entidad = ent;
                    return result;
                }
            }
            catch (Exception e)
            {
                var msgE="";
                if (e.InnerException!=null)
                {
                    msgE = e.InnerException.Message;
                }
                result.Mensaje = e.Message+Environment.NewLine+msgE;
                result.Result = DTO.Enumerados.EnumResult.isError;
            }

            return result;
        }

        public DTO.ResultadoEntidad<DTO.MASTER.EstatusFechaServidor> 
            Get_EstatusFechaServidor(string codProducto)
        {
            var result = new DTO.ResultadoEntidad<DTO.MASTER.EstatusFechaServidor>();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var p1 = new SqlParameter("@Cod_Producto", codProducto);
                    var sql = @"SELECT
                                    getdate() as FechaServidor, 
                                    c.mensaje, 
                                    c.vencimiento, 
                                    c.Nro_intentos,
                                    c.Lapso,
                                    c.Dias_inact, 
                                    c.Inactividad, 
                                    c.espera 
                                FROM MpSecurityConfig AS c 
                                WHERE c.producto = @Cod_Producto";
                    var ent = ctx.Database.SqlQuery<DTO.MASTER.EstatusFechaServidor>(sql, p1).FirstOrDefault();
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
        public DTO.ResultadoEntidad<DTO.MASTER.EstatusUsuario> 
            Get_EstatusUsuario(string codUsu)
        {
            var result = new DTO.ResultadoEntidad<DTO.MASTER.EstatusUsuario>();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var p1 = new SqlParameter("@usuario", codUsu);
                    var sql = @"select 
                                    Fec_Prox, 
                                    Fec_Ult, 
                                    Veces, 
                                    Fec_Ult_FA, 
                                    Estado, 
                                    getdate() as fechaServidor, 
                                    Ad_Login as Ad_Login
                                    FROM MpUsuario WHERE Cod_Usuario = @usuario";
                    var ent =ctx.Database.SqlQuery<DTO.MASTER.EstatusUsuario>(sql, p1).FirstOrDefault();
                    if (ent == null) 
                    {
                        throw new Exception("USUARIO NO ENCONTRADO");
                    }
                    result.Entidad=ent;
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
        public DTO.ResultadoEntidad<int> 
            AutenticarUsuario(string codUsu, string psw)
        {
            var result = new DTO.ResultadoEntidad<int>();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var p1 = new SqlParameter("@sUsuario", codUsu);
                    var p2 = new SqlParameter("@sPassword", psw);
                    var r1 = ctx.Database.SqlQuery<int>("pAutenticarUsuario @sUsuario, @sPassword", p1, p2).FirstOrDefault();
                    result.Entidad = r1;
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
        public DTO.ResultadoEntidad<DTO.MASTER.MpUsuario> 
            SeleccionarUsuario(string codUsu)
        {
            var result = new DTO.ResultadoEntidad<DTO.MASTER.MpUsuario>();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var p1 = new SqlParameter("@sCod_Usuario", codUsu);
                    var r1 = ctx.Database.SqlQuery<DTO.MASTER.MpUsuario>("pSeleccionarUsuario @sCod_Usuario", p1).FirstOrDefault();
                    result.Entidad = r1;
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
        public DTO.Resultado 
            ActualizarNumeroIntentos(string codUsu, bool actualizar)
        {
            var result = new DTO.Resultado();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var p1 = new SqlParameter("@sPkUsuario", codUsu);
                    var p2 = new SqlParameter("@sReiniciar", actualizar);
                    var r1 = ctx.Database.ExecuteSqlCommand("pActualizarNumeroIntentos @sPkUsuario, @sReiniciar", p1, p2);
                    if (r1 == 0)
                    {
                        result.Result = DTO.Enumerados.EnumResult.isError;
                        result.Mensaje = "PROBLEMA AL ACTUALIZAR NUMERO DE INTENTOS";
                    }
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
        public DTO.Resultado 
            ActualizarFechaUltimoLogueo(string codUsu)
        {
            var result = new DTO.Resultado();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var p1 = new SqlParameter("@sPkUsuario", codUsu);
                    var r1 = ctx.Database.ExecuteSqlCommand("pActualizarFechaUltimoLogueo @sPkUsuario", p1);
                    if (r1 == 0)
                    {
                        result.Result = DTO.Enumerados.EnumResult.isError;
                        result.Mensaje = "PROBLEMA AL ACTUALIZAR ULTIMO LOGUEO";
                    }
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
        public DTO.Resultado 
            InsertarPista(string codUsu, string tabla, string tipoOp, string nomEquipo, string coSucu, string campos)
        {
            var result = new DTO.Resultado();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var p1 = new SqlParameter("@sUsuario_Id", codUsu);
                    var p2 = new SqlParameter("@dtFecha", DBNull.Value);
                    var p3 = new SqlParameter("@sCo_Sucu", coSucu);
                    var p4 = new SqlParameter("@sTipo_Op", tipoOp);
                    var p5 = new SqlParameter("@sMaquin", nomEquipo);
                    var p6 = new SqlParameter("@sCampos", campos);
                    var p7 = new SqlParameter("@deAUX01", DBNull.Value);
                    var p8 = new SqlParameter("@sAUX02", DBNull.Value);
                    var p9 = new SqlParameter("@sTablaOri", tabla);
                    var sql = @"INSERT INTO MpPista (
                                usuario_id, 
                                fecha, 
                                co_sucu, 
                                tipo_op, 
                                maquina, 
                                campos, 
                                AUX01, 
                                AUX02, 
                                tablaOri)
                                VALUES (
                                @sUsuario_Id,
                                GETDATE(),
                                @sCo_Sucu,
                                @sTipo_Op, 
                                @sMaquin, 
                                @sCampos, 
                                @deAUX01, 
                                @sAUX02, 
                                @sTablaOri)";
                    var r1 = ctx.Database.ExecuteSqlCommand(sql, p1, p3, p4, p5, p6, p7, p8, p9);
                    if (r1 == 0)
                    {
                        result.Result = DTO.Enumerados.EnumResult.isError;
                        result.Mensaje = "PROBLEMA AL INSERTAR PISTA";
                    }
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
        public DTO.ResultadoLista<DTO.MASTER.ConsultarUsuarioAccesos> 
            ConsultarUsuarioAccesos(string codUsu, string sProducto)
        {
            var result = new DTO.ResultadoLista<DTO.MASTER.ConsultarUsuarioAccesos>();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var p1 = new SqlParameter("@sCod_Usuario", codUsu);
                    var p2 = new SqlParameter("@sProducto", sProducto);
                    var lst = ctx.Database.SqlQuery<DTO.MASTER.ConsultarUsuarioAccesos>("PConsultarUsuarioAccesos @sCod_Usuario, @sProducto", p1, p2).ToList();
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
        public DTO.ResultadoEntidad<DTO.MASTER.MpEmpresa> 
            SeleccionarMpEmpresa(string codEmpresa)
        {
            var result = new DTO.ResultadoEntidad<DTO.MASTER.MpEmpresa>();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var p1 = new SqlParameter("@sCod_Empresa", codEmpresa);
                    var ent = ctx.Database.SqlQuery<DTO.MASTER.MpEmpresa>("pSeleccionarMpEmpresa @sCod_Empresa", p1).FirstOrDefault();
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
        public DTO.ResultadoEntidad<string> 
            ObtenerMapaUsuario(string codUsu, string psw, string sEmpresa, string sProducto)
        {
            var result = new DTO.ResultadoEntidad<string>();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var p1 = new SqlParameter("@sUsuario", codUsu);
                    var p2 = new SqlParameter("@sPassword ", psw);
                    var p3 = new SqlParameter("@sEmpresa", sEmpresa);
                    var p4 = new SqlParameter("@sProducto", sProducto);
                    var ent = ctx.Database.SqlQuery<string>("pObtenerMapaUsuario @sUsuario, @sPassword, @sEmpresa, @sProducto", p1, p2, p3, p4).FirstOrDefault();
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
        public DTO.ResultadoEntidad<DTO.MASTER.MpMapa> 
            SeleccionarMapa(string codMapa, string sProducto)
        {
            var result = new DTO.ResultadoEntidad<DTO.MASTER.MpMapa>();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var p1 = new SqlParameter("@sCO_MAPA", codMapa);
                    var p2 = new SqlParameter("@sPRODUCTO", sProducto);
                    var ent = ctx.Database.SqlQuery<DTO.MASTER.MpMapa>("pSeleccionarMapa @sCO_MAPA, @sPRODUCTO", p1, p2).FirstOrDefault();
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
        public DTO.ResultadoLista<DTO.MASTER.MpConfiguracion> 
            Get_MpConfiguracion()
        {
            var result = new DTO.ResultadoLista<DTO.MASTER.MpConfiguracion>();
            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var sql = "select MpC.* FROM MpConfiguracion AS MpC";
                    var lst = ctx.Database.SqlQuery<DTO.MASTER.MpConfiguracion>(sql).ToList();
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