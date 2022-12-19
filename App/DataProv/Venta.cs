using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{
    
    public partial class ImpDataProv: IDataProv
    {
        public OOB.ResultadoEntidad<string> 
            vta_ObtenerUltimoDocPedidoByCodCli(string codCli)
        {
            var rt = new OOB.ResultadoEntidad<string>();
            var r01 = ServiceProv.vta_ObtenerUltimoDocPedidoByCodCli (codCli);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            rt.Entidad=r01.Entidad;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.Venta.Pedido> 
            vta_ObtenerPedido(string numDoc)
        {
            var rt = new OOB.ResultadoEntidad<OOB.Venta.Pedido>();
            var r01 = ServiceProv.vta_ObtenerPedido(numDoc);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var ent = new OOB.Venta.Pedido()
            {
                anulado = s.anulado,
                co_cli = s.co_cli,
                co_cond = s.co_cond,
                co_mone = s.co_mone,
                co_tran = s.co_tran,
                co_ven = s.co_ven,
                contrib = s.contrib,
                desc_glob = s.desc_glob,
                descrip = s.descrip,
                dir_ent2 = s.dir_ent2,
                doc_num = s.doc_num,
                fec_emis = s.fec_emis,
                fec_reg = s.fec_reg,
                fec_venc = s.fec_venc,
                impresa = s.impresa,
                monto_desc_glob = s.monto_desc_glob,
                monto_im2 = s.monto_im2,
                monto_im3 = s.monto_im3,
                monto_imp = s.monto_imp,
                monto_reca = s.monto_reca,
                n_control = s.n_control,
                otros1 = s.otros1,
                otros2 = s.otros2,
                otros3 = s.otros3,
                plaz_pag = s.plaz_pag,
                porc_desc_glob = s.porc_desc_glob,
                porc_reca = s.porc_reca,
                saldo = s.saldo,
                sincredito = s.sincredito,
                status = s.status,
                tasa = s.tasa,
                tip_cli = s.tip_cli,
                total_bruto = s.total_bruto,
                total_neto = s.total_neto,
                ven_ter = s.ven_ter,
            };
            rt.Entidad = ent;
            return rt;
        }
        public OOB.ResultadoLista<OOB.Venta.PedidoDetalle> 
            vta_ObtenerPedidoRenglones(string numDoc)
        {
            var rt = new OOB.ResultadoLista<OOB.Venta.PedidoDetalle>();
            var r01 = ServiceProv.vta_ObtenerPedidoRenglones(numDoc);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.Venta.PedidoDetalle>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Venta.PedidoDetalle()
                        {
                            art_des = s.art_des,
                            co_alma = s.co_alma,
                            co_art = s.co_art,
                            co_cat = s.co_cat,
                            co_lin = s.co_lin,
                            co_precio = s.co_precio,
                            co_uni = s.co_uni,
                            des_art = s.des_art,
                            doc_num = s.doc_num,
                            lote_asignado = s.lote_asignado,
                            maneja_lote = s.maneja_lote,
                            maneja_lote_venc = s.maneja_lote_venc,
                            maneja_serial = s.maneja_serial,
                            modelo = s.modelo,
                            monto_desc = s.monto_desc,
                            monto_desc_glob = s.monto_desc_glob,
                            monto_dev = s.monto_dev,
                            monto_imp = s.monto_imp,
                            monto_imp_afec_glob = s.monto_imp_afec_glob,
                            monto_imp2 = s.monto_imp2,
                            monto_imp2_afec_glob = s.monto_imp2_afec_glob,
                            monto_imp3 = s.monto_imp3,
                            monto_imp3_afec_glob = s.monto_imp3_afec_glob,
                            monto_reca_glob = s.monto_reca_glob,
                            num_doc = s.num_doc,
                            otros = s.otros,
                            otros1_glob = s.otros1_glob,
                            otros2_glob = s.otros2_glob,
                            otros3_glob = s.otros3_glob,
                            pendiente = s.pendiente,
                            pendiente2 = s.pendiente2,
                            porc_desc = s.porc_desc,
                            porc_imp = s.porc_imp,
                            porc_imp2 = s.porc_imp2,
                            porc_imp3 = s.porc_imp3,
                            prec_vta = s.prec_vta,
                            prec_vta_om = s.prec_vta_om,
                            relac_unidad = s.relac_unidad,
                            reng_neto = s.reng_neto,
                            reng_num = s.reng_num,
                            sco_uni = s.sco_uni,
                            stotal_art = s.stotal_art,
                            tasa = s.tasa,
                            tipo_doc = s.tipo_doc,
                            tipo_imp = s.tipo_imp,
                            tipo_imp_art = s.tipo_imp_art,
                            tipo_imp2 = s.tipo_imp2,
                            tipo_imp3 = s.tipo_imp3,
                            total_art = s.total_art,
                            total_dev = s.total_dev,
                            rowguid = s.rowguid,
                            rowguid_doc = s.rowguid_doc,
                            rowguid_articulo = s.rowguid_articulo,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;
            return rt;
        }
        public OOB.ResultadoLista<OOB.Venta.SerieProceso> 
            vta_ObtenerSerieProceso(string codConsecutivo, string coSuc, string codEmp)
        {
            var rt = new OOB.ResultadoLista<OOB.Venta.SerieProceso>();
            var r01 = ServiceProv.vta_ObtenerSerieProceso(codConsecutivo, coSuc, codEmp);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.Venta.SerieProceso>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Venta.SerieProceso()
                        {
                            co_consecutivo = s.co_consecutivo,
                            Consecutivo = s.Consecutivo,
                            Serie = s.Serie,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.Venta.Insertar.regInsertResult>
            vta_Insertar(OOB.Venta.Insertar.FichaAgregar ficha)
        {
            var rt = new OOB.ResultadoEntidad<OOB.Venta.Insertar.regInsertResult>();
            var stockActDTO = new List<DTO.Venta.Insertar.stockActualizar>();
            var stockPendActDTO = new List<DTO.Venta.Insertar.stockPendActualizar>();
            var cuerpoDTO = new List<DTO.Venta.Insertar.cuerpoAgregar>();
            //STOCK
            foreach (var rg in ficha.stockAct) 
            {
                var nr = new DTO.Venta.Insertar.stockActualizar()
                {
                    cnt = rg.cnt,
                    codAlm = rg.codAlm,
                    codArt = rg.codArt,
                    codUnd = rg.codUnd,
                    permiteStockNegativo = rg.permiteStockNegativo,
                    sumarStock = rg.sumarStock,
                    tipoStock = rg.tipoStock,
                };
                stockActDTO.Add(nr);
            }
            //STOCK PEND
            foreach (var rg in ficha.stockPendAct)
            {
                var nr = new DTO.Venta.Insertar.stockPendActualizar()
                {
                    cnt = rg.cnt,
                    rowguid = rg.rowguid,
                    tipoDoc = rg.tipoDoc,
                };
                stockPendActDTO.Add(nr);
            }
            //CUERPO
            foreach (var rg in ficha.cuerpo) 
            {
                var nr = new DTO.Venta.Insertar.cuerpoAgregar()
                {
                    coAlma = rg.coAlma,
                    coArt = rg.coArt,
                    coPrecio = rg.coPrecio,
                    coSucIn = rg.coSucIn,
                    coUni = rg.coUni,
                    coUsIn = rg.coUsIn,
                    montoImp = rg.montoImp,
                    pendiente = rg.pendiente,
                    porcImp = rg.porcImp,
                    precVta = rg.precVta,
                    rengNeto = rg.rengNeto,
                    tipoDoc = rg.tipoDoc,
                    tipoImp = rg.tipoImp,
                    totalArt = rg.totalArt,
                };
                cuerpoDTO.Add(nr);
            }
            //ENCABEZADO
            var enc=ficha.encabezado;
            var encabezadoDTO = new DTO.Venta.Insertar.encabezadoAgregar()
            {
                coCli = enc.coCli,
                coCond = enc.coCond,
                coMone = enc.coMone,
                contrib = enc.contrib,
                coSuc = enc.coSuc,
                coTran = enc.coTran,
                coUsu = enc.coUsu,
                coVen = enc.coVen,
                montoImp = enc.montoImp,
                saldo = enc.saldo,
                tasaCambio = enc.tasaCambio,
                totalBruto = enc.totalBruto,
                totalNeto = enc.totalNeto,
            };
            //DOCUMENTO VENTA
            var doc = ficha.docVenta;
            var docVentaDTO = new DTO.Venta.Insertar.docVentaAgregar()
            {
                co_cli = doc.co_cli,
                co_mone = doc.co_mone,
                co_sucu_in = doc.co_sucu_in,
                co_tipo_doc = doc.co_tipo_doc,
                co_us_in = doc.co_us_in,
                co_ven = doc.co_ven,
                contrib = doc.contrib,
                doc_orig = doc.doc_orig,
                monto_imp = doc.monto_imp,
                observa = doc.observa,
                porc_imp = doc.porc_imp,
                porc_imp2 = doc.porc_imp2,
                porc_imp3 = doc.porc_imp3,
                saldo = doc.saldo,
                tasa = doc.tasa,
                tipo_imp = doc.tipo_imp,
                tipo_orig = doc.tipo_orig,
                total_bruto = doc.total_bruto,
                total_neto = doc.total_neto,
                ImpFiscalDocumento = doc.ImpFiscalDocumento,
                ImpFiscalSerial = doc.ImpFiscalSerial,
                ImpFiscalZ = doc.ImpFiscalZ,
            };
            var docCobroDTO = new DTO.Venta.Insertar.docCobroAgregar()
            {
                ActivarAjustePorCambioVuelto = ficha.docCobro.ActivarAjustePorCambioVuelto,
                CambioVuelto = ficha.docCobro.CambioVuelto,
                docCobro = new DTO.Venta.Insertar.cobroAgregar()
                {
                    coCliente = ficha.docCobro.docCobro.coCliente,
                    coMoneda = ficha.docCobro.docCobro.coMoneda,
                    coSucursal = ficha.docCobro.docCobro.coSucursal,
                    coUsuario = ficha.docCobro.docCobro.coUsuario,
                    coVendedor = ficha.docCobro.docCobro.coVendedor,
                    tasaCambio = ficha.docCobro.docCobro.tasaCambio,
                },
                mediosCobro = ficha.docCobro.mediosCobro.Select(s =>
                {
                    var nr = new DTO.Venta.Insertar.medioCobro()
                    {
                        coCajaDestino = s.coCajaDestino,
                        formaPago = s.formaPago,
                        monto = s.monto,
                        tipoSaldo = s.tipoSaldo,
                        coCtaIngreso = s.coCtaIngreso,
                        coSucursal = doc.co_sucu_in,
                        coUsuario = doc.co_us_in,
                        tasaCambio = s.tasaCambio,
                    };
                    return nr;
                }).ToList(),
            };
            var fichaDTO = new DTO.Venta.Insertar.FichaAgregar()
            {
                nroDocPedido = ficha.nroDocPedido,
                coSerieControl = ficha.coSerieControl,
                coSerieDocumento = ficha.coSerieDocumento,
                NombreEquipo = ficha.NombreEquipo,
                encabezado = encabezadoDTO,
                cuerpo = cuerpoDTO,
                stockAct = stockActDTO,
                stockPendAct = stockPendActDTO,
                docVenta = docVentaDTO,
                docCobro = docCobroDTO,
            };
            var r01 = ServiceProv.vta_Insertar(fichaDTO);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            rt.Entidad = new OOB.Venta.Insertar.regInsertResult()
            {
                fecha = r01.Entidad.fecha,
                hora = r01.Entidad.hora,
                nroDocFact = r01.Entidad.docNumeroFact,
                nroDocPed = r01.Entidad.docNumeroPed,
            };
            return rt;
        }
    }

}