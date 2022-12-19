using MASTER;
using PROFIT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace ImpContrato
{

    public partial class Provider : Contrato.IProvider
    {

        public DTO.ResultadoEntidad<DTO.Venta.Pedido>
            vta_ObtenerPedido(string codDoc)
        {
            var result = new DTO.ResultadoEntidad<DTO.Venta.Pedido>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@sDoc_Num", codDoc);
                    var sql = "pSeleccionarPedidoVenta @sDoc_Num";
                    var ent = ctx.Database.SqlQuery<DTO.Venta.Pedido>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("[ DOCUMENTO PEDIDO NO ENCONTRADO]");
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
        public DTO.ResultadoLista<DTO.Venta.PedidoDetalle>
            vta_ObtenerPedidoRenglones(string codDoc)
        {
            var result = new DTO.ResultadoLista<DTO.Venta.PedidoDetalle>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@sDoc_Num", codDoc);
                    var sql = "pSeleccionarRenglonesPedidoVenta @sDoc_Num";
                    var lst = ctx.Database.SqlQuery<DTO.Venta.PedidoDetalle>(sql, p1).ToList();
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
        public DTO.ResultadoEntidad<string>
            vta_ObtenerUltimoDocPedidoByCodCli(string codCli)
        {
            var result = new DTO.ResultadoEntidad<string>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@codCli", codCli);
                    var sql = @"SELECT TOP (1) 
                                    doc_num 
                                FROM saPedidoVenta
                                WHERE co_cli=@codCli AND anulado = 0 AND status <> 2
                                ORDER BY doc_num DESC";
                    var ent = ctx.Database.SqlQuery<string>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Entidad = "";
                    }
                    else
                    {
                        result.Entidad = ent;
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
        public DTO.ResultadoLista<DTO.Venta.SerieProceso>
            vta_ObtenerSerieProceso(string codConsecutivo, string codSuc, string codEmp)
        {
            var result = new DTO.ResultadoLista<DTO.Venta.SerieProceso>();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@codigoConsecutivo", codConsecutivo);
                    var p2 = new SqlParameter("@sCo_sucur", codSuc);
                    var p3 = new SqlParameter("@sCo_emp", codEmp);
                    var sql = @"pObtenerSerieProceso @codigoConsecutivo, @sCo_sucur, @sCo_emp";
                    var lst = ctx.Database.SqlQuery<DTO.Venta.SerieProceso>(sql, p1, p2, p3).ToList();
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
        public DTO.Resultado
            vta_pValidarClienteProcesoVenta(string codCli)
        {
            var result = new DTO.Resultado();
            try
            {
                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    var p1 = new SqlParameter("@sCodigo", codCli);
                    var sql = "pValidarClienteProcesoVenta @sCodigo";
                    var ent = ctx.Database.SqlQuery<string>(sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("[ CLIENTE NO ENCONTRADO ]");
                    }
                    if (ent.ToString().Trim() != "")
                    {
                        throw new Exception(ent.ToString().Trim());
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
        public DTO.ResultadoEntidad<DTO.Venta.Insertar.regInsertResult>
            vta_Insertar(DTO.Venta.Insertar.FichaAgregar ficha)
        {
            var result = new DTO.ResultadoEntidad<DTO.Venta.Insertar.regInsertResult>();
            try
            {
                DateTime _fechaServ;
                Guid _rowGuid;

                using (var ctx = new pPanEntities(_gestion.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        SqlParameter p1;
                        SqlParameter p2;
                        SqlParameter p3;
                        SqlParameter p4;
                        SqlParameter p5;
                        SqlParameter p6;
                        SqlParameter p7;
                        string sql;

                        //ACTUALIZAR LOS STOCK 
                        foreach (var rg in ficha.stockAct)
                        {
                            p1 = new SqlParameter("@sCo_Alma", rg.codAlm);
                            p2 = new SqlParameter("@sCo_Art", rg.codArt);
                            p3 = new SqlParameter("@sCo_Uni", rg.codUnd);
                            p4 = new SqlParameter("@deCantidad", rg.cnt);
                            p5 = new SqlParameter("@sTipoStock", rg.tipoStock);
                            p6 = new SqlParameter("@bSumarStock", rg.sumarStock);
                            p7 = new SqlParameter("@bPermiteStockNegativo", rg.permiteStockNegativo);
                            sql = @"pStockActualizar @sCo_Alma, @sCo_Art, @sCo_Uni, @deCantidad, @sTipoStock, @bSumarStock, @bPermiteStockNegativo";
                            var ent = ctx.Database.SqlQuery<decimal>(sql, p1, p2, p3, p4, p5, p6, p7).FirstOrDefault();
                        }

                        //ACTUALIZAR LOS STOCK PENDIENTES
                        foreach (var rg in ficha.stockPendAct)
                        {
                            p1 = new SqlParameter("@uniRowGuidOri", rg.rowguid);
                            p2 = new SqlParameter("@deCantidad", rg.cnt);
                            p3 = new SqlParameter("@sTipoDocumento", rg.tipoDoc);
                            sql = @"pStockPendienteActualizar @uniRowGuidOri, @deCantidad, @sTipoDocumento";
                            var ent = ctx.Database.SqlQuery<DTO.Articulo.StockPendienteActualizar>(sql, p1, p2, p3).FirstOrDefault();
                        }

                        //ACTUALIZAR STATUS DEL PEDIDO
                        p1 = new SqlParameter("@nroDocPedido", ficha.nroDocPedido);
                        p2 = new SqlParameter("@chNuevoStatus","2");
                        sql = @"UPDATE
                                    saPedidoVenta
                                SET status = @chNuevoStatus
                                WHERE
                                    saPedidoVenta.doc_num = @nroDocPedido";
                        var rt= ctx.Database.ExecuteSqlCommand(sql, p1, p2);
                        

                        //FECHA DEL SERVIDOR
                        var r0 = ctx.Database.SqlQuery<DateTime>("SELECT GETDATE()").FirstOrDefault();
                        _fechaServ = r0;

                        //NUMERO CONTROL
                        p1 = new SqlParameter("@sCo_Consecutivo", ficha.coSerieControl);
                        p2 = new SqlParameter("@sCo_Sucur", "");
                        sql = @" SELECT
                                        saSerieTipo.tipo as intTipoConsecutivo,
			                            saSerie.desde_n as intDesdeN, 
			                            saSerie.hasta_n as intHastaN ,
                                        saSerie.prox_n as intProximoN, 
			                            saSerieTipo.longitud as intLongitud,
			                            saSerieTipo.reiniciar as bReiniciar,
                                        saConsecutivo.co_serie as coSerie,
			                            saConsecutivoTipo.Tabla as strTabla,
			                            saSerieTipo.prefijo as strPrefijo,
                                        saSerieTipo.sufijo as strSufijo,
			                            saSerie.desde_a as strDesdeA, 
			                            saSerie.hasta_a as strHastaA,
                                        saSerie.prox_a as strProximoA 
                                    FROM
                                        saConsecutivo
                                    INNER JOIN saSerie ON saConsecutivo.co_serie = saSerie.co_serie
                                    INNER JOIN saSerieTipo ON saSerieTipo.co_tipo_serie = saSerie.co_tipo_serie
                                    INNER JOIN saConsecutivoTipo ON saConsecutivoTipo.co_consecutivo = saConsecutivo.co_consecutivo
                                    WHERE
                                        saConsecutivo.co_consecutivo = @sCo_Consecutivo";
                        var r1 = ctx.Database.SqlQuery<DTO.Venta.Insertar.consecutivoProximoResult>(sql, p1, p2).FirstOrDefault();
                        var nControl = (r1.intProximoN + 1);
                        var nControlStr = nControl.ToString().Trim().PadLeft(r1.intLongitud, '0');

                        //NUMERO DOC
                        var q1 = new SqlParameter("@sCo_Consecutivo", ficha.coSerieDocumento);
                        var q2 = new SqlParameter("@sCo_Sucur", "");
                        var r2 = ctx.Database.SqlQuery<DTO.Venta.Insertar.consecutivoProximoResult>(sql, q1, q2).FirstOrDefault();
                        var nDocumento = (r2.intProximoN + 1);
                        var nDocumentoStr = nDocumento.ToString().Trim().PadLeft(r2.intLongitud, '0');

                        //ACTUALIZAR CONTADOR NUMERO CONTROL
                        p1 = new SqlParameter("@coSerie", r1.coSerie);
                        p2 = new SqlParameter("@intNext", nControl);
                        sql = @"UPDATE
                                saSerie
                                SET prox_n = @intNext
                                WHERE co_serie = @coSerie";
                        var r3 = ctx.Database.ExecuteSqlCommand(sql, p1, p2);

                        //ACTUALIZAR CONTADOR NUMERO DOCUMENTO
                        p1 = new SqlParameter("@coSerie", r2.coSerie);
                        p2 = new SqlParameter("@intNext", nDocumento);
                        sql = @"UPDATE
                                saSerie
                                SET prox_n = @intNext
                                WHERE co_serie = @coSerie";
                        var r4 = ctx.Database.ExecuteSqlCommand(sql, p1, p2);

                        //INSERTAR ENCABEZADO FACTURA
                        p1 = new SqlParameter("@sDoc_Num", nDocumentoStr);
                        p2 = new SqlParameter("@sCo_Cli", ficha.encabezado.coCli);
                        p3 = new SqlParameter("@sCo_Tran", ficha.encabezado.coTran);
                        p4 = new SqlParameter("sCo_Mone", ficha.encabezado.coMone);
                        p5 = new SqlParameter("@sCo_Ven", ficha.encabezado.coVen);
                        p6 = new SqlParameter("@sCo_Cond", ficha.encabezado.coCond);
                        p7 = new SqlParameter("@sdFec_Emis", r0);
                        var p8 = new SqlParameter("@sdFec_Venc", r0);
                        var p9 = new SqlParameter("@sdFec_Reg", r0);
                        var p10 = new SqlParameter("@sN_Control", nControlStr);
                        var p11 = new SqlParameter("@deTasa", ficha.encabezado.tasaCambio);
                        var p12 = new SqlParameter("@deTotal_Bruto", ficha.encabezado.totalBruto);
                        var p13 = new SqlParameter("@deMonto_Imp", ficha.encabezado.montoImp);
                        var p14 = new SqlParameter("@deTotal_Neto", ficha.encabezado.totalNeto);
                        var p15 = new SqlParameter("@bContrib", ficha.encabezado.contrib);
                        var p16 = new SqlParameter("@sCo_Us_In", ficha.encabezado.coUsu);
                        var p17 = new SqlParameter("@sCo_Sucu_In", ficha.encabezado.coSuc);
                        var p18 = new SqlParameter("@fe_us_in", r0);
                        var p19 = new SqlParameter("@sCo_Sucu_Mo", ficha.encabezado.coSuc);
                        var p20 = new SqlParameter("@sCo_Us_Mo", ficha.encabezado.coUsu);
                        var p21 = new SqlParameter("@fe_us_mo", r0);
                        sql = @" INSERT  INTO saFacturaVenta(
                                    doc_num, 
                                    descrip, 
                                    co_cli, 
                                    co_tran, 
                                    co_mone, 
                                    co_ven, 
                                    co_cond, 
                                    fec_emis, 
                                    fec_venc, 
                                    fec_reg, 
                                    anulado,
                                    status, 
                                    n_control, 
                                    ven_ter,
                                    tasa, 
                                    porc_desc_glob, 
                                    monto_desc_glob, 
                                    porc_reca, 
                                    monto_reca, 
                                    total_bruto,
                                    monto_imp, 
                                    monto_imp2, 
                                    monto_imp3, 
                                    otros1, 
                                    otros2, 
                                    otros3, 
                                    total_neto, 
                                    saldo,
                                    dir_ent,
                                    comentario, 
                                    dis_cen,
                                    feccom,
                                    numcom,
                                    contrib, 
                                    impresa,
		                            seriales_s,
                                    salestax, 
                                    impfis, 
                                    impfisfac, 
                                    imp_nro_z, 
                                    campo1, 
                                    campo2, 
                                    campo3, 
                                    campo4, 
                                    campo5, 
                                    campo6, 
                                    campo7, 
                                    campo8,
                                    co_us_in, 
                                    co_sucu_in, 
                                    fe_us_in, 
                                    co_sucu_mo, 
                                    co_us_mo, 
                                    fe_us_mo, 
                                    revisado, 
                                    trasnfe,
                                    co_cta_ingr_egr
                                    )
                                VALUES
                                    ( 
                                    @sDoc_Num, 
                                    null,
                                    @sCo_Cli, 
                                    @sCo_Tran, 
                                    @sCo_Mone, 
                                    @sCo_Ven, 
                                    @sCo_Cond, 
                                    @sdFec_Emis, 
                                    @sdFec_Venc,
                                    @sdFec_Reg, 
                                    0,
                                    0,
                                    @sN_Control, 
                                    0,
                                    @deTasa, 
                                    null,
                                    0,
                                    null,
                                    0,
                                    @deTotal_Bruto, 
                                    @deMonto_Imp, 
                                    0,
                                    0,
                                    0,  
                                    0,
                                    0,
                                    @deTotal_Neto, 
                                    0,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    @bContrib,
                                    0,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    @sCo_Us_In, 
                                    @sCo_Sucu_In, 
                                    @fe_us_in,
                                    @sCo_Sucu_Mo, 
                                    @sCo_Us_Mo, 
                                    @fe_us_mo,
                                    null,
                                    null,
                                    null
                                    )";
                        var r5 = ctx.Database.ExecuteSqlCommand(sql,
                            p1, p2, p3, p4, p5, p6, p7, p8, p9, p10,
                            p11, p12, p13, p14, p15, p16, p17, p18, p19, p20,
                            p21);

                        //CONSULTO REGISTRO RECIEN INSERTADO
                        p1 = new SqlParameter("@sDoc_Num", nDocumentoStr);
                        sql = "select validador, fe_us_in, fe_us_mo, rowguid from saFacturaVenta where doc_num=@sDoc_Num";
                        var r6 = ctx.Database.SqlQuery<DTO.Venta.Insertar.regEncabezadoResult>(sql, p1).FirstOrDefault();
                        _rowGuid = r6.rowguid;

                        //INSERTAR PISTA
                        p1 = new SqlParameter("@sUsuario_Id", ficha.encabezado.coUsu);
                        p2 = new SqlParameter("@dtFecha", _fechaServ);
                        p3 = new SqlParameter("@sCo_Sucu", ficha.encabezado.coSuc);
                        p4 = new SqlParameter("@sTablaOri", "saFacturaVenta");
                        p5 = new SqlParameter("@rowguidOri", _rowGuid);
                        p6 = new SqlParameter("@sTipo_Op", "I");
                        p7 = new SqlParameter("@sMaquin", ficha.NombreEquipo);
                        p8 = new SqlParameter("@sCampos", nDocumentoStr);
                        sql = @"INSERT INTO saPista (
                                                usuario_id, 
                                                fecha, 
                                                co_sucu, 
                                                tablaOri,
                                                rowguidOri,
                                                tipo_op, 
                                                maquina, 
                                                campos)
                                            VALUES (
                                                @sUsuario_Id,
                                                @dtFecha,
                                                @sCo_Sucu,
                                                @sTablaOri,
                                                @rowguidOri,
                                                @sTipo_Op, 
                                                @sMaquin, 
                                                @sCampos)";
                        var r7 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8);

                        //INSERTAR RENGLONES
                        var xr=0;
                        foreach (var rg in ficha.cuerpo) 
                        {
                            xr+=1;
                            p1 = new SqlParameter("@iReng_Num", xr);
                            p2 = new SqlParameter("@sDoc_Num", nDocumentoStr);
                            p3 = new SqlParameter("@sCo_Art", rg.coArt);
                            p4 = new SqlParameter("@sCo_Alma", rg.coAlma);
                            p5 = new SqlParameter("@deTotal_Art", rg.totalArt);
                            p6 = new SqlParameter("@sCo_Uni", rg.coUni);
                            p7 = new SqlParameter("@sCo_Precio", rg.coPrecio);
                            p8 = new SqlParameter("@dePrec_Vta", rg.precVta);
                            p9 = new SqlParameter("@sTipo_Imp", rg.tipoImp);
                            p10 = new SqlParameter("@dePorc_Imp", rg.porcImp);
                            p11 = new SqlParameter("@deMonto_Imp", rg.montoImp);
                            p12 = new SqlParameter("@deReng_Neto", rg.rengNeto);
                            p13 = new SqlParameter("@dePendiente", rg.pendiente);
                            p14 = new SqlParameter("@sTipo_Doc", rg.tipoDoc);
                            p15 = new SqlParameter("@sNum_Doc", nControlStr);
                            p16 = new SqlParameter("@gRowguid_Doc", _rowGuid);
                            p17 = new SqlParameter("@sCo_Us_In", rg.coUsIn);
                            p18 = new SqlParameter("@sCo_Sucu_In", rg.coSucIn);
                            p19 = new SqlParameter("@fe_us_in", _fechaServ);
                            p20 = new SqlParameter("@sCo_Us_mo", rg.coUsIn);
                            p21 = new SqlParameter("@sCo_Sucu_mo", rg.coSucIn);
                            var p22 = new SqlParameter("@fe_us_mo", _fechaServ);
                            sql = @"INSERT INTO saFacturaVentaReng(
                                        reng_num, 
                                        doc_num, 
                                        co_art, 
                                        des_art, 
                                        co_alma,
                                        total_art, 
                                        stotal_art, 
                                        co_uni, 
                                        sco_uni,
                                        co_precio, 
                                        prec_vta, 
                                        prec_vta_om, 
                                        porc_desc, 
                                        monto_desc, 
                                        tipo_imp, 
                                        tipo_imp2,
                                        tipo_imp3,
                                        porc_imp, 
                                        porc_Imp2,
                                        porc_Imp3,
                                        monto_imp, 
                                        monto_imp2, 
                                        monto_imp3,
                                        reng_neto, 
                                        pendiente, 
                                        pendiente2,
                                        tipo_doc, 
                                        num_doc, 
                                        rowguid_doc, 
                                        total_dev, 
                                        monto_dev, 
                                        otros, 
                                        comentario, 
                                        lote_asignado,
                                        Monto_Desc_Glob, 
                                        Monto_reca_Glob, 
                                        Otros1_glob, 
                                        Otros2_glob, 
                                        Otros3_glob, 
                                        Monto_imp_afec_glob,
                                        Monto_imp2_afec_glob, 
                                        Monto_imp3_afec_glob, 
                                        dis_cen, 
                                        co_us_in,
                                        co_sucu_in, 
                                        fe_us_in, 
                                        co_us_mo, 
                                        co_sucu_mo,
                                        fe_us_mo, 
                                        revisado, 
                                        trasnfe
                                        )
                                    VALUES(
                                        @iReng_Num, 
                                        @sDoc_Num, 
                                        @sCo_Art, 
                                        null,
                                        @sCo_Alma, 
                                        @deTotal_Art, 
                                        0,
                                        @sCo_Uni,
                                        null,
                                        @sCo_Precio, 
                                        @dePrec_Vta, 
                                        null,
                                        null,
                                        0,
                                        @sTipo_Imp,
                                        null,
                                        null,
                                        @dePorc_Imp, 
                                        0,
                                        0,
                                        @deMonto_Imp, 
                                        0,
                                        0,
                                        @deReng_Neto, 
                                        @dePendiente, 
                                        0,
                                        @sTipo_Doc, 
                                        @sNum_Doc, 
                                        @gRowguid_Doc, 
                                        0,
                                        0,
                                        0,
                                        null,
                                        0,
                                        0,
                                        0,
                                        0,
                                        0,
                                        0,
                                        0,
                                        0,
                                        0,
                                        null,
                                        @sCo_Us_In, 
                                        @sCo_Sucu_In, 
                                        @fe_us_in,
                                        @sCo_Us_mo, 
                                        @sCo_Sucu_mo, 
                                        @fe_us_mo,
                                        null,
                                        null
                                        )";
                            var t1 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10,
                                                        p11, p12, p13, p14, p15, p16, p17, p18, p19, p20,
                                                        p21, p22);
                            
                            //BUSCO REGISTRO INSERTADO
                            p1 = new SqlParameter("@rengNum", xr);
                            p2 = new SqlParameter("@sDoc_Num", nDocumentoStr);
                            sql = "select rowguid from saFacturaVentaReng where reng_num=@rengNum and doc_num=@sDoc_Num";
                            var t2 = ctx.Database.SqlQuery<DTO.Venta.Insertar.regCuerpoResult>(sql, p1, p2).FirstOrDefault();
                            Guid _rowGuidReng= t2.rowguid;

                            //INSERTAR PISTA
                            p1 = new SqlParameter("@sUsuario_Id", ficha.encabezado.coUsu);
                            p2 = new SqlParameter("@dtFecha", _fechaServ);
                            p3 = new SqlParameter("@sCo_Sucu", ficha.encabezado.coSuc);
                            p4 = new SqlParameter("@sTablaOri", "saFacturaVentaReng");
                            p5 = new SqlParameter("@rowguidOri", _rowGuidReng);
                            p6 = new SqlParameter("@sTipo_Op", "I");
                            p7 = new SqlParameter("@sMaquin", ficha.NombreEquipo);
                            p8 = new SqlParameter("@sCampos", nDocumentoStr);
                            sql = @"INSERT INTO saPista (
                                                usuario_id, 
                                                fecha, 
                                                co_sucu, 
                                                tablaOri,
                                                rowguidOri,
                                                tipo_op, 
                                                maquina, 
                                                campos)
                                            VALUES (
                                                @sUsuario_Id,
                                                @dtFecha,
                                                @sCo_Sucu,
                                                @sTablaOri,
                                                @rowguidOri,
                                                @sTipo_Op, 
                                                @sMaquin, 
                                                @sCampos)";
                            var t3 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8);
                        }

                        //INSERTAR DOCUMENTO DE VENTA A COBRAR
                        p1 = new SqlParameter("@sCo_Tipo_Doc", "FACT");
                        p2 = new SqlParameter("@sNro_Doc", nDocumentoStr);
                        p3 = new SqlParameter("@sCo_Cli", ficha.docVenta.co_cli);
                        p4 = new SqlParameter("@sCo_Ven", ficha.docVenta.co_ven);
                        p5 = new SqlParameter("@sCo_Mone", ficha.docVenta.co_mone);
                        p6 = new SqlParameter("@deTasa", ficha.docVenta.tasa);
                        p7 = new SqlParameter("@sObserva", ficha.docVenta.observa);
                        p8 = new SqlParameter("@sdFec_Reg", _fechaServ);
                        p9 = new SqlParameter("@sdFec_Emis", _fechaServ);
                        p10 = new SqlParameter("@sdFec_Venc", _fechaServ);
                        p11 = new SqlParameter("@bContrib", ficha.docVenta.contrib);
                        p12 = new SqlParameter("@sDoc_Orig", "FACT");
                        p13 = new SqlParameter("@sNro_Orig", nDocumentoStr);
                        p14 = new SqlParameter("@deTotal_Bruto", ficha.docVenta.total_bruto);
                        p15 = new SqlParameter("@deTotal_Neto", ficha.docVenta.total_neto);
                        p16 = new SqlParameter("@deMonto_Imp", ficha.docVenta.monto_imp);
                        p17 = new SqlParameter("@sN_Control", nControlStr);
                        p18 = new SqlParameter("@sImpfis", ficha.docVenta.ImpFiscalSerial);
                        p19 = new SqlParameter("@sImpfisfac", ficha.docVenta.ImpFiscalDocumento);
                        p20 = new SqlParameter("@sImp_nro_z", ficha.docVenta.ImpFiscalZ);
                        p21 = new SqlParameter("@sco_us_in", ficha.docVenta.co_us_in);
                        var x22 = new SqlParameter("@sco_sucu_in",ficha.docVenta.co_sucu_in);
                        var p23 = new SqlParameter("@fe_us_in", _fechaServ);
                        var p24 = new SqlParameter("@sco_us_mo", ficha.docVenta.co_us_in);
                        var p25 = new SqlParameter("@sco_sucu_mo", ficha.docVenta.co_sucu_in);
                        var p26 = new SqlParameter("@fe_us_mo", _fechaServ);
                        sql = @"INSERT  INTO saDocumentoVenta( 
                                co_tipo_doc, 
                                nro_doc, 
                                co_cli, 
                                co_ven, 
                                co_mone, 
                                mov_ban, 
                                tasa, 
                                observa, 
                                fec_reg, 
                                fec_emis, 
                                fec_venc,
                                anulado, 
                                aut, 
                                contrib, 
                                doc_orig, 
                                Tipo_Origen,
                                nro_orig, 
                                nro_che, 
                                saldo, 
                                total_bruto, 
                                porc_desc_glob, 
                                monto_desc_glob,
                                porc_reca, 
                                monto_reca, 
                                total_neto, 
                                monto_imp, 
                                monto_imp2, 
                                monto_imp3, 
                                tipo_imp, 
                                tipo_imp2, 
                                tipo_imp3, 
                                porc_imp, 
                                porc_imp2,
                                porc_imp3,
                                num_comprobante, 
                                feccom,
                                numcom,
                                n_control, 
                                dis_cen, 
                                comis1, 
                                comis2, 
                                comis3, 
                                comis4,
                                comis5, 
                                comis6, 
                                adicional, 
                                salestax, 
                                ven_ter, 
                                impfis, 
                                impfisfac, 
                                imp_nro_z, 
                                otros1, 
                                otros2, 
                                otros3,
                                campo1, 
                                campo2, 
                                campo3, 
                                campo4, 
                                campo5, 
                                campo6, 
                                campo7, 
                                campo8, 
                                co_us_in, 
                                co_sucu_in, 
                                fe_us_in,
                                co_us_mo, 
                                co_sucu_mo, 
                                fe_us_mo, 
                                revisado, 
                                trasnfe,
                                co_cta_ingr_egr 
                                )
                            VALUES(
                                @sCo_Tipo_Doc, 
                                @sNro_Doc, 
                                @sCo_Cli, 
                                @sCo_Ven, 
                                @sCo_Mone, 
                                null,
                                @deTasa, 
                                @sObserva, 
                                @sdFec_Reg,
                                @sdFec_Emis, 
                                @sdFec_Venc, 
                                0,
                                1,
                                @bContrib, 
                                @sDoc_Orig,
                                0,
                                @sNro_Orig,
                                null,
                                0,
                                @deTotal_Bruto, 
                                null,
                                0,
                                null,
                                0,
                                @deTotal_Neto,
                                @deMonto_Imp,
                                0,
                                0,
                                1,
                                null,
                                null,
                                0,
                                0,
                                0,
                                null,
                                null,
                                null,
                                @sN_Control, 
                                null,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                null,
                                0,
                                @sImpfis,
                                @sImpfisfac,
                                @sImp_nro_z,
                                0,
                                0,
                                0,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                @sco_us_in, 
                                @sco_sucu_in, 
                                @fe_us_in,
                                @sco_us_mo,
                                @sco_sucu_mo, 
                                @fe_us_mo,
                                null,
                                null,
                                null
                                )";
                        var t4 = ctx.Database.ExecuteSqlCommand(sql, 
                                                            p1, p2, p3, p4, p5, p6, p7, p8, p9, p10,
                                                            p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, 
                                                            p21, x22, p23, p24, p25, p26);
                        ctx.SaveChanges();

                        //CONSULTO REGISTRO RECIEN INSERTADO
                        p1 = new SqlParameter("@sDoc_Num", nDocumentoStr);
                        p2 = new SqlParameter("@sco_tipo_doc", ficha.docVenta.co_tipo_doc);
                        sql = @"select validador, fe_us_in, fe_us_mo, rowguid 
                                    from saDocumentoVenta 
                                    where co_tipo_doc=@sco_tipo_doc and nro_doc=@sDoc_Num";
                        var t5 = ctx.Database.SqlQuery<DTO.Venta.Insertar.regDocVentaResult>(sql, p1, p2).FirstOrDefault();
                        _rowGuid = t5.rowguid;
                        result.Entidad = new DTO.Venta.Insertar.regInsertResult()
                        {
                            docNumeroPed = nControlStr,
                            docNumeroFact = nDocumentoStr,
                            fecha = _fechaServ.Date,
                            hora = _fechaServ.ToShortTimeString(),
                        };

                        //INSERTAR PISTA
                        p1 = new SqlParameter("@sUsuario_Id", ficha.encabezado.coUsu);
                        p2 = new SqlParameter("@dtFecha", _fechaServ);
                        p3 = new SqlParameter("@sCo_Sucu", ficha.encabezado.coSuc);
                        p4 = new SqlParameter("@sTablaOri", "saDocumentoVenta");
                        p5 = new SqlParameter("@rowguidOri", _rowGuid);
                        p6 = new SqlParameter("@sTipo_Op", "I");
                        p7 = new SqlParameter("@sMaquin", ficha.NombreEquipo);
                        p8 = new SqlParameter("@sCampos", nDocumentoStr);
                        sql = @"INSERT INTO saPista (
                                                usuario_id, 
                                                fecha, 
                                                co_sucu, 
                                                tablaOri,
                                                rowguidOri,
                                                tipo_op, 
                                                maquina, 
                                                campos)
                                            VALUES (
                                                @sUsuario_Id,
                                                @dtFecha,
                                                @sCo_Sucu,
                                                @sTablaOri,
                                                @rowguidOri,
                                                @sTipo_Op, 
                                                @sMaquin, 
                                                @sCampos)";
                        var t6 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8);


                        ///
                        ///
                        ///
                        ///
                        ///
                        //
                        // COBRO
                        //
                        ///
                        ///
                        ///
                        ///


                        var cobro = ficha.docCobro;
                        //PROXIMO CONSECUTIVO DE COBRO
                        p1 = new SqlParameter("@sCo_Consecutivo", "COBRO");
                        p2 = new SqlParameter("@sCo_Sucur", "");
                        sql = @" SELECT
                                        saSerieTipo.tipo as intTipoConsecutivo,
			                            saSerie.desde_n as intDesdeN, 
			                            saSerie.hasta_n as intHastaN ,
                                        saSerie.prox_n as intProximoN, 
			                            saSerieTipo.longitud as intLongitud,
			                            saSerieTipo.reiniciar as bReiniciar,
                                        saConsecutivo.co_serie as coSerie,
			                            saConsecutivoTipo.Tabla as strTabla,
			                            saSerieTipo.prefijo as strPrefijo,
                                        saSerieTipo.sufijo as strSufijo,
			                            saSerie.desde_a as strDesdeA, 
			                            saSerie.hasta_a as strHastaA,
                                        saSerie.prox_a as strProximoA 
                                    FROM
                                        saConsecutivo
                                    INNER JOIN saSerie ON saConsecutivo.co_serie = saSerie.co_serie
                                    INNER JOIN saSerieTipo ON saSerieTipo.co_tipo_serie = saSerie.co_tipo_serie
                                    INNER JOIN saConsecutivoTipo ON saConsecutivoTipo.co_consecutivo = saConsecutivo.co_consecutivo
                                    WHERE
                                        saConsecutivo.co_consecutivo = @sCo_Consecutivo";
                        var tc0 = ctx.Database.SqlQuery<DTO.Venta.Insertar.consecutivoProximoResult>(sql, p1, p2).FirstOrDefault();
                        var nCobro = (tc0.intProximoN + 1);
                        var nCobroStr = nCobro.ToString().Trim().PadLeft(tc0.intLongitud, '0');

                        //ACTUALIZAR CONTADOR 
                        p1 = new SqlParameter("@coSerie", tc0.coSerie);
                        p2 = new SqlParameter("@intNext", nCobro);
                        sql = @"UPDATE
                                saSerie
                                SET prox_n = @intNext
                                WHERE co_serie = @coSerie";
                        var h0 = ctx.Database.ExecuteSqlCommand(sql, p1, p2);



                        var nAjusteStr = "";
                        if (ficha.docCobro.ActivarAjustePorCambioVuelto)
                        {
                            //CONSULTO ULTI CORRELATIVO PARA AJUSTE POR CAMBIO/VUELTO A DAR
                            p1 = new SqlParameter("@sCo_Consecutivo", "DOC_VEN_AJPA");
                            p2 = new SqlParameter("@sCo_Sucur", "");
                            sql = @" SELECT
                                        saSerieTipo.tipo as intTipoConsecutivo,
			                            saSerie.desde_n as intDesdeN, 
			                            saSerie.hasta_n as intHastaN ,
                                        saSerie.prox_n as intProximoN, 
			                            saSerieTipo.longitud as intLongitud,
			                            saSerieTipo.reiniciar as bReiniciar,
                                        saConsecutivo.co_serie as coSerie,
			                            saConsecutivoTipo.Tabla as strTabla,
			                            saSerieTipo.prefijo as strPrefijo,
                                        saSerieTipo.sufijo as strSufijo,
			                            saSerie.desde_a as strDesdeA, 
			                            saSerie.hasta_a as strHastaA,
                                        saSerie.prox_a as strProximoA 
                                    FROM
                                        saConsecutivo
                                    INNER JOIN saSerie ON saConsecutivo.co_serie = saSerie.co_serie
                                    INNER JOIN saSerieTipo ON saSerieTipo.co_tipo_serie = saSerie.co_tipo_serie
                                    INNER JOIN saConsecutivoTipo ON saConsecutivoTipo.co_consecutivo = saConsecutivo.co_consecutivo
                                    WHERE
                                        saConsecutivo.co_consecutivo = @sCo_Consecutivo";
                            var eAj = ctx.Database.SqlQuery<DTO.Venta.Insertar.consecutivoProximoResult>(sql, p1, p2).FirstOrDefault();
                            var nAjuste = (eAj.intProximoN + 1);
                            nAjusteStr = nAjuste.ToString().Trim().PadLeft(eAj.intLongitud, '0');

                            //ACTUALIZAR CONTADOR NUMERO CONTROL
                            p1 = new SqlParameter("@coSerie", eAj.coSerie);
                            p2 = new SqlParameter("@intNext", nAjuste);
                            sql = @"UPDATE
                                saSerie
                                SET prox_n = @intNext
                                WHERE co_serie = @coSerie";
                            var Aj1 = ctx.Database.ExecuteSqlCommand(sql, p1, p2);


                            //INSERTAR DOCUMENTO DE VENTA TIPO AJUSTE EN CASO DE HABER UN CAMBIO/VUELTO A DAR
                            p1 = new SqlParameter("@sCo_Tipo_Doc", "AJPA");
                            p2 = new SqlParameter("@sNro_Doc", nAjusteStr);
                            p3 = new SqlParameter("@sCo_Cli", ficha.docVenta.co_cli);
                            p4 = new SqlParameter("@sCo_Ven", ficha.docVenta.co_ven);
                            p5 = new SqlParameter("@sCo_Mone", ficha.docVenta.co_mone);
                            p6 = new SqlParameter("@deTasa", ficha.docVenta.tasa);
                            p7 = new SqlParameter("@sObserva", "COBRO N° " + nCobroStr);
                            p8 = new SqlParameter("@sdFec_Reg", _fechaServ);
                            p9 = new SqlParameter("@sdFec_Emis", _fechaServ);
                            p10 = new SqlParameter("@sdFec_Venc", _fechaServ);
                            p11 = new SqlParameter("@bContrib", false);
                            p12 = new SqlParameter("@sDoc_Orig", "COBRO");
                            p13 = new SqlParameter("@sNro_Orig", nAjusteStr);
                            p14 = new SqlParameter("@deTotal_Bruto", ficha.docCobro.CambioVuelto);
                            p15 = new SqlParameter("@deTotal_Neto", ficha.docCobro.CambioVuelto);
                            p21 = new SqlParameter("@sco_us_in", ficha.docVenta.co_us_in);
                            x22 = new SqlParameter("@sco_sucu_in", ficha.docVenta.co_sucu_in);
                            p23 = new SqlParameter("@fe_us_in", _fechaServ);
                            p24 = new SqlParameter("@sco_us_mo", ficha.docVenta.co_us_in);
                            p25 = new SqlParameter("@sco_sucu_mo", ficha.docVenta.co_sucu_in);
                            p26 = new SqlParameter("@fe_us_mo", _fechaServ);
                            sql = @"INSERT  INTO saDocumentoVenta( 
                                co_tipo_doc, 
                                nro_doc, 
                                co_cli, 
                                co_ven, 
                                co_mone, 
                                mov_ban, 
                                tasa, 
                                observa, 
                                fec_reg, 
                                fec_emis, 
                                fec_venc,
                                anulado, 
                                aut, 
                                contrib, 
                                doc_orig, 
                                Tipo_Origen,
                                nro_orig, 
                                nro_che, 
                                saldo, 
                                total_bruto, 
                                porc_desc_glob, 
                                monto_desc_glob,
                                porc_reca, 
                                monto_reca, 
                                total_neto, 
                                monto_imp, 
                                monto_imp2, 
                                monto_imp3, 
                                tipo_imp, 
                                tipo_imp2, 
                                tipo_imp3, 
                                porc_imp, 
                                porc_imp2,
                                porc_imp3,
                                num_comprobante, 
                                feccom,
                                numcom,
                                n_control, 
                                dis_cen, 
                                comis1, 
                                comis2, 
                                comis3, 
                                comis4,
                                comis5, 
                                comis6, 
                                adicional, 
                                salestax, 
                                ven_ter, 
                                impfis, 
                                impfisfac, 
                                imp_nro_z, 
                                otros1, 
                                otros2, 
                                otros3,
                                campo1, 
                                campo2, 
                                campo3, 
                                campo4, 
                                campo5, 
                                campo6, 
                                campo7, 
                                campo8, 
                                co_us_in, 
                                co_sucu_in, 
                                fe_us_in,
                                co_us_mo, 
                                co_sucu_mo, 
                                fe_us_mo, 
                                revisado, 
                                trasnfe,
                                co_cta_ingr_egr 
                                )
                            VALUES(
                                @sCo_Tipo_Doc, 
                                @sNro_Doc, 
                                @sCo_Cli, 
                                @sCo_Ven, 
                                @sCo_Mone, 
                                null,
                                @deTasa, 
                                @sObserva, 
                                @sdFec_Reg,
                                @sdFec_Emis, 
                                @sdFec_Venc, 
                                0,
                                1,
                                @bContrib, 
                                @sDoc_Orig,
                                0,
                                @sNro_Orig,
                                null,
                                0,
                                @deTotal_Bruto, 
                                null,
                                0,
                                null,
                                0,
                                @deTotal_Neto,
                                0,
                                0,
                                0,
                                7,
                                null,
                                null,
                                0,
                                0,
                                0,
                                null,
                                null,
                                null,
                                null,
                                null,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                null,
                                0,
                                null,
                                null,
                                null,
                                0,
                                0,
                                0,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                @sco_us_in, 
                                @sco_sucu_in, 
                                @fe_us_in,
                                @sco_us_mo,
                                @sco_sucu_mo, 
                                @fe_us_mo,
                                null,
                                null,
                                null
                                )";
                            var aj1 = ctx.Database.ExecuteSqlCommand(sql,
                                                                p1, p2, p3, p4, p5, p6, p7, p8, p9, p10,
                                                                p11, p12, p13, p14, p15, 
                                                                p21, x22, p23, p24, p25, p26);
                            ctx.SaveChanges();
                        }


                        foreach (var rg in cobro.mediosCobro)
                        {
                            //VERIFICACION, QUE EXISTA LA CAJA DESITNO
                            p1 = new SqlParameter("@sCodigo", rg.coCajaDestino);
                            sql = @"select cod_caja 
                                        FROM saCaja 
                                        WHERE cod_caja = @sCodigo";
                            var entCaja = ctx.Database.SqlQuery< DTO.Venta.Insertar.regCajaResult>(sql, p1).FirstOrDefault();
                            if (entCaja == null)
                            {
                                throw new Exception("CAJA NO EXISTE");
                            }

                            //VERIFICACION, QUE EXISTA LA CAJA TIPO SALDO EF
                            p1 = new SqlParameter("@sCodigo", rg.coCajaDestino);
                            p2 = new SqlParameter("@sTipoSaldo", rg.tipoSaldo);
                            sql = @"select cod_caja
                                        FROM saSaldoCaja
                                        WHERE saSaldoCaja.cod_caja = @sCodigo
                                                AND saSaldoCaja.tipo = @sTipoSaldo";
                            var entSaldoCaja = ctx.Database.SqlQuery<DTO.Venta.Insertar.regSaldoCajaResult>(sql, p1, p2).FirstOrDefault();
                            if (entSaldoCaja == null) 
                            {
                                p1 = new SqlParameter("@sCodigo", rg.coCajaDestino);
                                p2 = new SqlParameter("@sTipoSaldo", rg.tipoSaldo);
                                sql = @" INSERT  INTO saSaldoCaja
                                            ( [cod_caja], [tipo], [saldo], [revisado], [trasnfe] )
                                        VALUES
                                            ( @sCodigo, @sTipoSaldo, 0, NULL, NULL )";
                                var tc1 = ctx.Database.ExecuteSqlCommand(sql, p1, p2);
                            }

                            //VERIFICACION, QUE EXISTA LA CAJA TIPO SALDO TF
                            p1 = new SqlParameter("@sCodigo", rg.coCajaDestino);
                            sql = @"select cod_caja
                                        FROM saSaldoCaja
                                        WHERE saSaldoCaja.cod_caja = @sCodigo
                                                AND saSaldoCaja.tipo = 'TF'";
                            entSaldoCaja = ctx.Database.SqlQuery<DTO.Venta.Insertar.regSaldoCajaResult>(sql, p1).FirstOrDefault();
                            if (entSaldoCaja == null)
                            {
                                p1 = new SqlParameter("@sCodigo", rg.coCajaDestino);
                                p2 = new SqlParameter("@sTipoSaldo", rg.tipoSaldo);
                                sql = @" INSERT  INTO saSaldoCaja
                                            ( [cod_caja], [tipo], [saldo], [revisado], [trasnfe] )
                                        VALUES
                                            ( @sCodigo, 'TF', 0, NULL, NULL )";
                                var tc2 = ctx.Database.ExecuteSqlCommand(sql, p1, p2);
                            }

                            //ACTUALIZAR CAJAS
                            p1 = new SqlParameter("@sCodigo", rg.coCajaDestino);
                            p2 = new SqlParameter("@sTipoSaldo", rg.tipoSaldo);
                            p3 = new SqlParameter("@deMonto", rg.monto);
                            sql = @"update
                                  saSaldoCaja
                              SET saSaldoCaja.saldo = saSaldoCaja.saldo + @deMonto
                              WHERE
                                  saSaldoCaja.cod_caja = @sCodigo
                                  AND saSaldoCaja.tipo = @sTipoSaldo 
                                  AND @sTipoSaldo = 'EF'";
                            var ct1 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3);

                            p1 = new SqlParameter("@sCodigo", rg.coCajaDestino);
                            p2 = new SqlParameter("@deMonto", rg.monto);
                            sql = @"update
                                    saSaldoCaja
                                SET saSaldoCaja.saldo = saSaldoCaja.saldo + @deMonto
                                WHERE
                                    saSaldoCaja.cod_caja = @sCodigo
                                    AND saSaldoCaja.tipo = 'TF'";
                            var ct2 = ctx.Database.ExecuteSqlCommand(sql, p1, p2);

                            //PROXIMOS CONSECUTIVO MOV CAJA
                            p1 = new SqlParameter("@sCo_Consecutivo", "MOVC_NUM");
                            p2 = new SqlParameter("@sCo_Sucur", "");
                            sql = @" SELECT
                                        saSerieTipo.tipo as intTipoConsecutivo,
			                            saSerie.desde_n as intDesdeN, 
			                            saSerie.hasta_n as intHastaN ,
                                        saSerie.prox_n as intProximoN, 
			                            saSerieTipo.longitud as intLongitud,
			                            saSerieTipo.reiniciar as bReiniciar,
                                        saConsecutivo.co_serie as coSerie,
			                            saConsecutivoTipo.Tabla as strTabla,
			                            saSerieTipo.prefijo as strPrefijo,
                                        saSerieTipo.sufijo as strSufijo,
			                            saSerie.desde_a as strDesdeA, 
			                            saSerie.hasta_a as strHastaA,
                                        saSerie.prox_a as strProximoA 
                                    FROM
                                        saConsecutivo
                                    INNER JOIN saSerie ON saConsecutivo.co_serie = saSerie.co_serie
                                    INNER JOIN saSerieTipo ON saSerieTipo.co_tipo_serie = saSerie.co_tipo_serie
                                    INNER JOIN saConsecutivoTipo ON saConsecutivoTipo.co_consecutivo = saConsecutivo.co_consecutivo
                                    WHERE
                                        saConsecutivo.co_consecutivo = @sCo_Consecutivo";
                            var tc3 = ctx.Database.SqlQuery<DTO.Venta.Insertar.consecutivoProximoResult>(sql, p1, p2).FirstOrDefault();
                            var nMovCobro = (tc3.intProximoN + 1);
                            var nMovCobroStr = nMovCobro.ToString().Trim().PadLeft(tc3.intLongitud, '0');

                            //ACTUALIZAR CONTADOR 
                            p1 = new SqlParameter("@coSerie", tc3.coSerie);
                            p2 = new SqlParameter("@intNext", nMovCobro);
                            sql = @"UPDATE
                                saSerie
                                SET prox_n = @intNext
                                WHERE co_serie = @coSerie";
                            var h1 = ctx.Database.ExecuteSqlCommand(sql, p1, p2);

                            var monto= rg.monto / rg.tasaCambio;
                            //INSERTAR MOV CAJA
                            p1 = new SqlParameter("@sMov_Num", nMovCobroStr);
                            p2 = new SqlParameter("@sdFecha", _fechaServ);
                            p3 = new SqlParameter("@sDescrip", "Cobro " + nCobroStr);
                            p4 = new SqlParameter("@sCod_Caja", rg.coCajaDestino);
                            p5 = new SqlParameter("@sCo_Cta_Ingr_Egr", rg.coCtaIngreso);
                            p6 = new SqlParameter("@deTasa", rg.tasaCambio);
                            p7 = new SqlParameter("@sTipo_Mov", "I");
                            p8 = new SqlParameter("@sForma_Pag", rg.formaPago);
                            p9 = new SqlParameter("@deMonto_h", monto);
                            p10 = new SqlParameter("@sDoc_Num", nCobroStr);
                            p11 = new SqlParameter("@sCo_Us_In", rg.coUsuario);
                            p12 = new SqlParameter("@sCo_Sucu_In", rg.coSucursal);
                            p13 = new SqlParameter("@fe_us_in", _fechaServ);
                            p14 = new SqlParameter("@sCo_Us_mo", rg.coUsuario);
                            p15 = new SqlParameter("@sCo_Sucu_mo", rg.coSucursal);
                            p16 = new SqlParameter("@fe_us_mo", _fechaServ);
                            var x17 = new SqlParameter("@fecha_che", _fechaServ);
                            var x18 = new SqlParameter("@sOrigen", "COB");
                            sql = @"INSERT  INTO saMovimientoCaja
                                    ( 
                                        mov_num, 
                                        fecha, 
                                        descrip, 
                                        cod_caja,
                                        co_ban,
                                        co_tar, 
                                        co_vale, 
                                        co_cta_ingr_egr, 
                                        tasa, 
                                        tipo_mov, 
                                        forma_pag,
                                        num_pago, 
                                        saldo_ini, 
                                        monto_d, 
                                        monto_h, 
                                        dep_num,
                                        origen, 
                                        doc_num, 
                                        anulado,
                                        depositado, 
                                        transferido,
                                        mov_nro, 
                                        aux01, 
                                        aux02, 
                                        campo1, 
                                        campo2, 
                                        campo3, 
                                        campo4, 
                                        campo5, 
                                        campo6, 
                                        campo7, 
                                        campo8, 
                                        co_us_in,
                                        co_sucu_in, 
                                        fe_us_in, 
                                        co_us_mo, 
                                        co_sucu_mo, 
                                        fe_us_mo,   
                                        revisado, 
                                        trasnfe,
                                        feccom, 
                                        numcom,
                                        dis_cen,    
                                        fecha_che 
                                    )
                                    VALUES
                                    (
                                        @sMov_Num, 
                                        @sdFecha, 
                                        @sDescrip, 
                                        @sCod_Caja, 
                                        null,
                                        null,
                                        null,
                                        @sCo_Cta_Ingr_Egr, 
                                        @deTasa, 
                                        @sTipo_Mov, 
                                        @sForma_Pag, 
                                        null,
                                        0,
                                        0,
                                        @deMonto_h,
                                        null,
                                        @sOrigen,
                                        @sDoc_Num, 
                                        0,
                                        0,
                                        0,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        @sCo_Us_In, 
                                        @sCo_Sucu_In, 
                                        @fe_us_in,
                                        @sCo_Us_mo, 
                                        @sCo_Sucu_mo,
                                        @fe_us_mo,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        @fecha_che
                                    )";
                            var cc0 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10,
                                                            p11, p12, p13, p14, p15, p16, x17, x18);

                            rg.movCajaGeneradoPorSist = nMovCobroStr;
                        }

                        //INSERTAR DOCUMENTO DE COBRO
                        p1 = new SqlParameter("@sCob_Num", nCobroStr);
                        p2 = new SqlParameter("@sCo_cli", cobro.docCobro.coCliente);
                        p3 = new SqlParameter("@sCo_ven", cobro.docCobro.coVendedor);
                        p4 = new SqlParameter("@sCo_Mone", cobro.docCobro.coMoneda);
                        p5 = new SqlParameter("@deTasa", cobro.docCobro.tasaCambio);
                        p6 = new SqlParameter("@sdFecha", _fechaServ);
                        p7 = new SqlParameter("@sCo_Us_In", cobro.docCobro.coUsuario);
                        p8 = new SqlParameter("@sCo_Sucu_In", cobro.docCobro.coSucursal);
                        p9 = new SqlParameter("@fe_usu_in", _fechaServ);
                        p10 = new SqlParameter("@sCo_Us_mo", cobro.docCobro.coUsuario);
                        p11 = new SqlParameter("@sCo_Sucu_mo", cobro.docCobro.coSucursal);
                        p12 = new SqlParameter("@fe_usu_mo",_fechaServ);
                        sql = @"INSERT  INTO saCobro
                                (
                                    cob_num, 
                                    recibo, 
                                    descrip, 
                                    co_cli, 
                                    co_ven, 
                                    co_mone, 
                                    tasa, 
                                    fecha, 
                                    anulado, 
                                    monto,
                                    dis_cen, 
                                    feccom, 
                                    numcom, 
                                    campo1, 
                                    campo2, 
                                    campo3, 
                                    campo4, 
                                    campo5, 
                                    campo6, 
                                    campo7, 
                                    campo8, 
                                    co_us_in,
                                    co_sucu_in,
                                    fe_us_in, 
                                    co_us_mo, 
                                    co_sucu_mo, 
                                    fe_us_mo, 
                                    revisado, 
                                    trasnfe
                                )
                                VALUES
                                ( 
                                    @sCob_Num, 
                                    null,
                                    null,
                                    @sCo_cli, 
                                    @sCo_ven, 
                                    @sCo_Mone, 
                                    @deTasa, 
                                    @sdFecha, 
                                    0,
                                    0,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    @sCo_Us_In,
                                    @sCo_Sucu_In, 
                                    @fe_usu_in,
                                    @sCo_Us_mo, 
                                    @sCo_Sucu_mo, 
                                    @fe_usu_mo,
                                    null,
                                    null
                                )";
                        var cc1 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
                        ctx.SaveChanges();


                        //BUSCO REGISTRO INSERTADO
                        p1 = new SqlParameter("@sCob_Num", nCobroStr);
                        sql = "select rowguid from saCobro where cob_num=@sCob_Num";
                        var vc1 = ctx.Database.SqlQuery<DTO.Venta.Insertar.regCobroResult>(sql, p1).FirstOrDefault();
                        Guid _rowGuidCobro= vc1.rowguid;

                        //INSERTAR PISTA
                        p1 = new SqlParameter("@sUsuario_Id", ficha.encabezado.coUsu);
                        p2 = new SqlParameter("@dtFecha", _fechaServ);
                        p3 = new SqlParameter("@sCo_Sucu", ficha.encabezado.coSuc);
                        p4 = new SqlParameter("@sTablaOri", "saCobro");
                        p5 = new SqlParameter("@rowguidOri", _rowGuidCobro);
                        p6 = new SqlParameter("@sTipo_Op", "I");
                        p7 = new SqlParameter("@sMaquin", ficha.NombreEquipo);
                        p8 = new SqlParameter("@sCampos", nCobroStr);
                        sql = @"INSERT INTO saPista (
                                                usuario_id, 
                                                fecha, 
                                                co_sucu, 
                                                tablaOri,
                                                rowguidOri,
                                                tipo_op, 
                                                maquina, 
                                                campos)
                                            VALUES (
                                                @sUsuario_Id,
                                                @dtFecha,
                                                @sCo_Sucu,
                                                @sTablaOri,
                                                @rowguidOri,
                                                @sTipo_Op, 
                                                @sMaquin, 
                                                @sCampos)";
                        var xvc1 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8);


                        //INSERT COBRO DOC RENGLON 
                        p1 = new SqlParameter("@iReng_Num", 1);
                        p2 = new SqlParameter("@sCob_Num", nCobroStr);
                        p3 = new SqlParameter("@sCo_Tipo_Doc", "FACT");
                        p4 = new SqlParameter("@sNro_Doc", nDocumentoStr);
                        p5 = new SqlParameter("@deMont_Cob", ficha.encabezado.totalNeto);
                        p6 = new SqlParameter("@sCo_Sucu_In", ficha.encabezado.coSuc);
                        p7 = new SqlParameter("@sCo_Us_In", ficha.encabezado.coUsu);
                        p8 = new SqlParameter("@fe_us_in", _fechaServ);
                        p9 = new SqlParameter("@sCo_Sucu_mo", ficha.encabezado.coSuc);
                        p10 = new SqlParameter("@sCo_Us_mo", ficha.encabezado.coUsu);
                        p11 = new SqlParameter("@fe_us_mo", _fechaServ);
                        sql = @"INSERT INTO saCobroDocReng
                                    ( 
                                        reng_num, 
                                        cob_num, 
                                        co_tipo_doc, 
                                        nro_doc, 
                                        mont_cob,
                                        dpCobro_porc_desc, 
                                        dpCobro_monto,
                                        monto_retencion_iva, 
                                        monto_retencion, 
                                        reten_tercero_rowguid_ori, 
                                        tipo_doc, 
                                        num_doc, 
                                        rowguid_reng_ori,
                                        tipo_origen, 
                                        gen_origen, 
                                        co_sucu_in, 
                                        co_us_in, 
                                        fe_us_in, 
                                        co_sucu_mo, 
                                        co_us_mo,
                                        fe_us_mo, 
                                        trasnfe, 
                                        revisado
                                    )
                                VALUES
                                    ( 
                                        @iReng_Num, 
                                        @sCob_Num, 
                                        @sCo_Tipo_Doc, 
                                        @sNro_Doc, 
                                        @deMont_Cob, 
                                        0,
                                        0,
                                        0,
                                        0,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        @sCo_Sucu_In, 
                                        @sCo_Us_In, 
                                        @fe_us_in,
                                        @sCo_Sucu_mo, 
                                        @sCo_Us_mo, 
                                        @fe_us_mo,
                                        null,
                                        null
                                    )";
                        var cc2 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
                        ctx.SaveChanges();


                        //BUSCO REGISTRO INSERTADO
                        p1 = new SqlParameter("@sCob_Num", nCobroStr);
                        p2 = new SqlParameter("@iReng_Num", 1);
                        sql = "select rowguid from saCobroDocReng where cob_num=@sCob_Num and reng_num=@iReng_Num";
                        var vc2 = ctx.Database.SqlQuery<DTO.Venta.Insertar.regCobroDocRengResult>(sql, p1, p2).FirstOrDefault();
                        Guid _rowGuidCobroDocReng = vc2.rowguid;

                        //INSERTAR PISTA
                        p1 = new SqlParameter("@sUsuario_Id", ficha.encabezado.coUsu);
                        p2 = new SqlParameter("@dtFecha", _fechaServ);
                        p3 = new SqlParameter("@sCo_Sucu", ficha.encabezado.coSuc);
                        p4 = new SqlParameter("@sTablaOri", "saCobroDocReng");
                        p5 = new SqlParameter("@rowguidOri", _rowGuidCobroDocReng);
                        p6 = new SqlParameter("@sTipo_Op", "I");
                        p7 = new SqlParameter("@sMaquin", ficha.NombreEquipo);
                        p8 = new SqlParameter("@sCampos", nCobroStr);
                        sql = @"INSERT INTO saPista (
                                                usuario_id, 
                                                fecha, 
                                                co_sucu, 
                                                tablaOri,
                                                rowguidOri,
                                                tipo_op, 
                                                maquina, 
                                                campos)
                                            VALUES (
                                                @sUsuario_Id,
                                                @dtFecha,
                                                @sCo_Sucu,
                                                @sTablaOri,
                                                @rowguidOri,
                                                @sTipo_Op, 
                                                @sMaquin, 
                                                @sCampos)";
                        var xvc2 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8);


                        if (ficha.docCobro.ActivarAjustePorCambioVuelto)
                        {
                            //INSERT COBRO DOC RENGLON AJUSTE
                            p1 = new SqlParameter("@iReng_Num", 2);
                            p2 = new SqlParameter("@sCob_Num", nCobroStr);
                            p3 = new SqlParameter("@sCo_Tipo_Doc", "AJPA");
                            p4 = new SqlParameter("@sNro_Doc", nAjusteStr);
                            p5 = new SqlParameter("@deMont_Cob", ficha.docCobro.CambioVuelto);
                            p6 = new SqlParameter("@sCo_Sucu_In", ficha.encabezado.coSuc);
                            p7 = new SqlParameter("@sCo_Us_In", ficha.encabezado.coUsu);
                            p8 = new SqlParameter("@fe_us_in", _fechaServ);
                            p9 = new SqlParameter("@sCo_Sucu_mo", ficha.encabezado.coSuc);
                            p10 = new SqlParameter("@sCo_Us_mo", ficha.encabezado.coUsu);
                            p11 = new SqlParameter("@fe_us_mo", _fechaServ);
                            sql = @"INSERT INTO saCobroDocReng
                                    ( 
                                        reng_num, 
                                        cob_num, 
                                        co_tipo_doc, 
                                        nro_doc, 
                                        mont_cob,
                                        dpCobro_porc_desc, 
                                        dpCobro_monto,
                                        monto_retencion_iva, 
                                        monto_retencion, 
                                        reten_tercero_rowguid_ori, 
                                        tipo_doc, 
                                        num_doc, 
                                        rowguid_reng_ori,
                                        tipo_origen, 
                                        gen_origen, 
                                        co_sucu_in, 
                                        co_us_in, 
                                        fe_us_in, 
                                        co_sucu_mo, 
                                        co_us_mo,
                                        fe_us_mo, 
                                        trasnfe, 
                                        revisado
                                    )
                                VALUES
                                    ( 
                                        @iReng_Num, 
                                        @sCob_Num, 
                                        @sCo_Tipo_Doc, 
                                        @sNro_Doc, 
                                        @deMont_Cob, 
                                        0,
                                        0,
                                        0,
                                        0,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        @sCo_Sucu_In, 
                                        @sCo_Us_In, 
                                        @fe_us_in,
                                        @sCo_Sucu_mo, 
                                        @sCo_Us_mo, 
                                        @fe_us_mo,
                                        null,
                                        null
                                    )";
                            var aj3 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
                            ctx.SaveChanges();
                        }


                        var ireng = 0;
                        foreach (var rg in cobro.mediosCobro)
                        {
                            ireng += 1;
                            //INSERTA LOS METODOS DE COBRO PARA ESA FACTURA EN ESA COBRANZA
                            p1 = new SqlParameter("@iReng_Num",ireng);
                            p2 = new SqlParameter("@sCob_Num", nCobroStr);
                            p3 = new SqlParameter("@sForma_Pag", rg.formaPago);
                            p4 = new SqlParameter("@sCod_Caja", rg.coCajaDestino);
                            p5 = new SqlParameter("@sMov_Num_C", rg.movCajaGeneradoPorSist);
                            p6 = new SqlParameter("@deMont_Doc", rg.monto);
                            p7 = new SqlParameter("@sdFecha_Che", _fechaServ);
                            p8 = new SqlParameter("@sCo_Sucu_In", rg.coSucursal);
                            p9 = new SqlParameter("@sCo_Us_In", rg.coUsuario);
                            p10 = new SqlParameter("@fe_us_in", _fechaServ);
                            p11 = new SqlParameter("@sCo_Sucu_mo", rg.coSucursal);
                            p12 = new SqlParameter("@sCo_Us_mo", rg.coUsuario);
                            p13 = new SqlParameter("@fe_us_mo", _fechaServ);
                            sql = @"INSERT INTO saCobroTPReng
                                    ( 
                                        reng_num, 
                                        cob_num, 
                                        co_tar, 
                                        co_ban, 
                                        forma_pag, 
                                        cod_cta, 
                                        cod_caja, 
                                        co_vale,
                                        mov_num_c,
                                        mov_num_b, 
                                        num_doc, 
                                        devuelto,
                                        mont_doc, 
                                        fecha_che, 
                                        co_sucu_in, 
                                        co_us_in, 
                                        fe_us_in,
                                        co_sucu_mo, 
                                        co_us_mo, 
                                        fe_us_mo, 
                                        trasnfe, 
                                        revisado
                                    )
                              VALUES
                                    ( 
                                        @iReng_Num, 
                                        @sCob_Num, 
                                        null,
                                        null,
                                        @sForma_Pag, 
                                        null,
                                        @sCod_Caja, 
                                        null,
                                        @sMov_Num_C,
                                        null,
                                        null,
                                        0,
                                        @deMont_Doc, 
                                        @sdFecha_Che,   
                                        @sCo_Sucu_In, 
                                        @sCo_Us_In, 
                                        @fe_us_in,
                                        @sCo_Sucu_mo, 
                                        @sCo_Us_mo, 
                                        @fe_us_mo,
                                        null,
                                        null
                                    )";
                            var cc3 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);


                            //BUSCO REGISTRO INSERTADO
                            p1 = new SqlParameter("@sCob_Num", nCobroStr);
                            p2 = new SqlParameter("@iReng_Num", 1);
                            sql = "select rowguid from saCobroTPReng where cob_num=@sCob_Num and reng_num=@iReng_Num";
                            var vc3 = ctx.Database.SqlQuery<DTO.Venta.Insertar.regCobroTPRengResult>(sql, p1, p2).FirstOrDefault();
                            Guid _rowGuidCobroTPReng = vc3.rowguid;

                            //INSERTAR PISTA
                            p1 = new SqlParameter("@sUsuario_Id", ficha.encabezado.coUsu);
                            p2 = new SqlParameter("@dtFecha", _fechaServ);
                            p3 = new SqlParameter("@sCo_Sucu", ficha.encabezado.coSuc);
                            p4 = new SqlParameter("@sTablaOri", "saCobroTPReng");
                            p5 = new SqlParameter("@rowguidOri", _rowGuidCobroTPReng);
                            p6 = new SqlParameter("@sTipo_Op", "I");
                            p7 = new SqlParameter("@sMaquin", ficha.NombreEquipo);
                            p8 = new SqlParameter("@sCampos", nCobroStr);
                            sql = @"INSERT INTO saPista (
                                                usuario_id, 
                                                fecha, 
                                                co_sucu, 
                                                tablaOri,
                                                rowguidOri,
                                                tipo_op, 
                                                maquina, 
                                                campos)
                                            VALUES (
                                                @sUsuario_Id,
                                                @dtFecha,
                                                @sCo_Sucu,
                                                @sTablaOri,
                                                @rowguidOri,
                                                @sTipo_Op, 
                                                @sMaquin, 
                                                @sCampos)";
                            var xvc3 = ctx.Database.ExecuteSqlCommand(sql, p1, p2, p3, p4, p5, p6, p7, p8);
                        }
                        
                        //TRANSACCION FINALIZADA CON EXITO
                        ts.Complete();
                    }
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