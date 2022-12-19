using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta
{

    public class ImpCajaVenta : ICajaVenta
    {

        private string _idTarjeta;
        private bool _buscarTarjetaIsOk;
        private ICajaItem _gItem;
        //
        private documento _docProceso;
        private Producto.BuscarListar.IBuscar _gBuscarPrd;
        private SerieProceso.ISerieProc _gSerieProcesar;
        private Producto.Buscar.Seleccionar.ISelecciona _gSelArt;
        private CantSolicitar.ICantSolicitar _gCantSolicitarPesado;
        private CantSolicitar.ICantSolicitar _gCantSolicitarNoPesado;
        private Cliente.Solicitar.ISolicitar _gSolicitarCli;
        private FormaPago.ICobro _gCobro;
        //
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;


        BindingSource ICajaVenta.GetData_Source { get { return _gItem.GetSource; } }
        public string GetVersion { get { return "Ver. " + Application.ProductVersion; } }


        public ImpCajaVenta()
        {
            printDialog1 = new PrintDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            printDialog1.Document = printDocument1;

            _idTarjeta = "";
            _pedirTarjetaNueva = true;
            _buscarTarjetaIsOk = false;
            _buscarClienteIsOk = false;
            _editarItemIsOk = false;
            _facturarIsOk = false;
            _abandonarIsOk = false;
            _docProceso = new documento();
            //
            _gItem = new ImpCajaItem();
            _gBuscarPrd = new Producto.BuscarListar.ImpBuscar();
            _gSerieProcesar = new SerieProceso.ImpSerieProc();
            _gSelArt = new Producto.Buscar.Seleccionar.ImpSelecciona();
            _gCantSolicitarPesado = new CantSolicitar.Pesado.ImpPesado();
            _gCantSolicitarNoPesado = new CantSolicitar.NoPesado.ImpNoPesado();
            _gSolicitarCli = new Cliente.Solicitar.ImpSolicitar();
            _gCobro = new FormaPago.ImpCobro();
        }


        public void Inicializa()
        {
            _idTarjeta = "";
            _pedirTarjetaNueva = true;
            _buscarTarjetaIsOk = false;
            _buscarClienteIsOk = false;
            _editarItemIsOk = false;
            _facturarIsOk = false;
            _abandonarIsOk = false;
            _docProceso.Inicializa();
            //
            _gItem.Inicializa();
        }
        CajaVentaFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new CajaVentaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setTarjeta(string idTarjeta)
        {
            _idTarjeta = idTarjeta.Trim().PadLeft(2, '0');
        }
        public void BuscarTarjeta(bool isTarjetaIdCiRif=false)
        {
            if (_idTarjeta.Trim() == "" || _idTarjeta.Trim() == "00")
            {
                _idTarjeta = "";
                return;
            }
            if (_idTarjeta.Trim() == "99")
            {
                CargarTarjetaSinPedido();
            }
            else 
            {
                BuscaTarjetaInf(isTarjetaIdCiRif);
            }
        }


        private bool CargarData()
        {
            return true;
        }
        public string GetTarjeta_ID { get { return _docProceso.GetTarjeta_ID; } }
        public string GetTarjeta_ID_TIPO { get { return _docProceso.GetTarjeta_ID_TIPO; } }

        public bool BuscarTarjetaIsOk { get { return _buscarTarjetaIsOk; } }
        private void BuscaTarjetaInf(bool isTarjetaIdCiRif=false)
        {
            _buscarTarjetaIsOk = false;
            var _codCli = "";
            var _numPed = "";
            var _codVend = "";
            var _codCondPag = "";
            var _codtrans = "";
            var _codMone = "";
            try
            {
                var fechaServ = Sistema.MyConfiguracion.FechaServidor;
                var r01 = Sistema.MyData.cli_ObtenerFichaById(_idTarjeta);
                _codCli = r01.Entidad.co_cli.Trim();
                var r02 = Sistema.MyData.tasa_ObtenerTipoTasaFiscal();
                var r03 = Sistema.MyData.tasa_ObtenerTasaPorTipoValor(fechaServ);
                var v04 = Sistema.MyData.vta_ObtenerUltimoDocPedidoByCodCli(_codCli);
                _numPed = v04.Entidad.Trim();
                var v05 = Sistema.MyData.vta_ObtenerPedido(_numPed);
                var v06 = Sistema.MyData.vta_ObtenerPedidoRenglones(_numPed);
                //
                _codVend = Sistema.Usuario.CodUsuario;
                _codCondPag = v05.Entidad.co_cond;
                _codtrans = v05.Entidad.co_tran;
                _codMone = v05.Entidad.co_mone;
                var v07 = Sistema.MyData.sist_vend_ObtenerFicha(_codVend);
                var v08 = Sistema.MyData.sist_condPago_ObtenerFicha(_codCondPag);
                var v09 = Sistema.MyData.sist_transporte_ObtenerFicha(_codtrans);
                var v0A = Sistema.MyData.sist_moneda_ObtenerFicha(_codMone);
                var v0B = Sistema.MyData.sist_TasaCambio_ObtenerFicha(_codMone, fechaServ);
                _buscarTarjetaIsOk = true;
                //
                _docProceso.setTarjetaId(_idTarjeta);
                _docProceso.setTarjetaIdPorCiRif(isTarjetaIdCiRif);
                _docProceso.setCliente(r01.Entidad);
                _docProceso.setTasaFiscalTipo(r02.Lista);
                _docProceso.setTasaFiscalValor(r03.Lista);
                _docProceso.setEncabezado(v05.Entidad);
                _docProceso.setCuerpo(v06.Lista);
                _docProceso.setVendedor(v07.Entidad);
                _docProceso.setCondPago(v08.Entidad);
                _docProceso.setTransporte(v09.Entidad);
                _docProceso.setMoneda(v0A.Entidad);
                _docProceso.setTasaCambio(v0B.Entidad);
                //
                _gItem.setData(_docProceso.GetItems());
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        //
        public decimal GetSubTotalMonto { get { return _docProceso.SubTotalMonto; } }
        public decimal GetIvaMonto { get { return _docProceso.IvaMonto; } }
        public decimal GetTotalMonto { get { return _docProceso.TotalMonto; } }
        public decimal GetTotalDivisaMonto { get { return _docProceso.TotalDivisaMonto; } }
        public decimal GetTasaCambioActual { get { return _docProceso.TasaCambioActual; } }


        //
        private bool _pedirTarjetaNueva;
        public bool PedirTarjetaNuevaIsOk { get { return _pedirTarjetaNueva; } }
        public void PedirTarjetaNueva()
        {
            _pedirTarjetaNueva = false;
            if (GetTotalMonto > 0 || _gItem.GetCtnItems > 0 || _docProceso.GetTarjeta_ID !="")
            {
                var msg = Helpers.Msg.Abandonar("Perder Cambios Y Cerrar Tarjeta ?");
                if (msg)
                {
                    TarjetaNueva();
                }
            }
        }

        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = false;
            if (GetTotalMonto > 0m || _gItem.GetCtnItems > 0) 
            {
                Helpers.Msg.Error("EXISTE UNA TARJETA EN PROCESO, VERIFIQUE POR FAVOR");
                return;
            }
            if (_idTarjeta != "" && _idTarjeta != "00")
            {
                Helpers.Msg.Error("EXISTE UNA TARJETA EN PROCESO, VERIFIQUE POR FAVOR");
                return;
            }
            _abandonarIsOk = Helpers.Msg.Abandonar("Cerrar y Salir Del Proceso de Cobro ?");
        }

        public void ConsultarPrecioArticulo()
        {
            _gBuscarPrd.Inicializa();
            _gBuscarPrd.Inicia();
            if (_gBuscarPrd.ProcesarItemIsOk) 
            {
                ProcesarItem(_gBuscarPrd.GetItemProcesar_Id);
            }
        }


        private bool _facturarIsOk;
        public bool FacturarIsOk { get { return _facturarIsOk; } }
        public void Facturar()
        {
            _facturarIsOk = false;
            if (GetTotalMonto <= 0)
            {
                return;
            }
            MediosCobro();
        }

        private void MediosCobro()
        {
            _gCobro.Inicializa();
            _gCobro.setMontoCobrar(GetTotalMonto);
            _gCobro.setMontoCobrarDivisa(GetTotalDivisaMonto);
            _gCobro.setTasaCambio(GetTasaCambioActual);
            _gCobro.Inicia();
            if (_gCobro.IsOk) 
            {
                if (Sistema.MyConfiguracion.SerieProcesar == null)
                {
                    _gSerieProcesar.Inicializa();
                    _gSerieProcesar.Inicia();
                    if (_gSerieProcesar.SerieProcesarIsOk)
                    {
                        ProcesarFactura();
                    }
                }
                else
                {
                    ProcesarFactura();
                }
            }
        }

        private void ProcesarFactura()
        {
            try
            {
                var _serieSeleccion = _gSerieProcesar.SerieSeleccion;
                var stockArtOOB = new List<OOB.Venta.Insertar.stockActualizar>();
                var stockPendActOOB = new List<OOB.Venta.Insertar.stockPendActualizar>();
                var cuerpoOOB = new List<OOB.Venta.Insertar.cuerpoAgregar>();

                foreach (var rg in _docProceso.GetItemsPedido.Where(w=>w.pendiente>0))
                {
                    var nr = new OOB.Venta.Insertar.stockPendActualizar()
                    {
                        cnt = rg.pendiente,
                        rowguid = rg.rowguid,
                        tipoDoc = "PCLI",
                    };
                    stockPendActOOB.Add(nr);
                }
                foreach (var rg in _docProceso.GetItemsPedido)
                {
                    var ncom = new OOB.Venta.Insertar.stockActualizar()
                    {
                        cnt = rg.total_art,
                        codAlm = rg.co_alma,
                        codArt = rg.co_art,
                        codUnd = rg.co_uni,
                        permiteStockNegativo = true,
                        sumarStock = false,
                        tipoStock = "COM",
                    };
                    var ndes = new OOB.Venta.Insertar.stockActualizar()
                    {
                        cnt = rg.total_art,
                        codAlm = rg.co_alma,
                        codArt = rg.co_art,
                        codUnd = rg.co_uni,
                        permiteStockNegativo = true,
                        sumarStock = true,
                        tipoStock = "DES",
                    };
                    var nact = new OOB.Venta.Insertar.stockActualizar()
                    {
                        cnt = rg.total_art,
                        codAlm = rg.co_alma,
                        codArt = rg.co_art,
                        codUnd = rg.co_uni,
                        permiteStockNegativo = true,
                        sumarStock = false,
                        tipoStock = "ACT",
                    };
                    if (rg.pendiente > 0)
                    {
                        stockArtOOB.Add(ncom);
                    }
                    stockArtOOB.Add(ndes);
                    stockArtOOB.Add(nact);
                }
                foreach (var rg in _docProceso.GetItemsPedido)
                {
                    var nr = new OOB.Venta.Insertar.cuerpoAgregar()
                    {
                        coAlma = rg.co_alma,
                        coArt = rg.co_art,
                        coPrecio = rg.co_precio,
                        coSucIn = Sistema.MyConfiguracion.codSucursal,
                        coUni = rg.co_uni,
                        coUsIn = Sistema.Usuario.CodUsuario,
                        montoImp = rg.monto_imp,
                        pendiente = rg.pendiente,
                        porcImp = rg.porc_imp,
                        precVta = rg.prec_vta,
                        rengNeto = rg.reng_neto,
                        tipoDoc = "PCLI",
                        tipoImp = rg.tipo_imp,
                        totalArt = rg.total_art,
                    };
                    cuerpoOOB.Add(nr);
                }
                var encabezadoOOB = new OOB.Venta.Insertar.encabezadoAgregar()
                {
                    coCli = _docProceso.GetCliente.co_cli,
                    coCond = _docProceso.GetCondPago.co_cond,
                    coMone = _docProceso.GetCodMoneda,
                    contrib = _docProceso.GetCliente.contrib,
                    coSuc = Sistema.MyConfiguracion.codSucursal,
                    coTran = _docProceso.GetTransporte.co_tran,
                    coUsu = Sistema.Usuario.CodUsuario,
                    coVen = _docProceso.GetVendedor.co_ven,
                    montoImp = _docProceso.GetMontoImpuesto,
                    saldo = _docProceso.GetSaldo,
                    tasaCambio = _docProceso.TasaCambioActual,
                    totalBruto = _docProceso.GetTotalBruto,
                    totalNeto = _docProceso.GetTotalNeto,
                };
                var docVentaOOB = new OOB.Venta.Insertar.docVentaAgregar()
                {
                    co_cli = _docProceso.GetCliente.co_cli,
                    co_mone = _docProceso.GetCodMoneda,
                    co_sucu_in = Sistema.MyConfiguracion.codSucursal,
                    co_tipo_doc = "FACT",
                    co_us_in = Sistema.Usuario.CodUsuario,
                    co_ven = _docProceso.GetVendedor.co_ven,
                    contrib = _docProceso.GetCliente.contrib,
                    doc_orig = "FACT",
                    monto_imp = _docProceso.GetMontoImpuesto,
                    observa = "FACT N°  de Cliente " + _docProceso.GetCliente.co_cli.Trim(),
                    porc_imp = 0m,
                    porc_imp2 = 0m,
                    porc_imp3 = 0m,
                    saldo = _docProceso.GetSaldo,
                    tasa = _docProceso.TasaCambioActual,
                    tipo_imp = "1",
                    tipo_orig = 0,
                    total_bruto = _docProceso.GetTotalBruto,
                    total_neto = _docProceso.GetTotalNeto,
                    ImpFiscalDocumento = "",
                    ImpFiscalSerial = "",
                    ImpFiscalZ = "",
                };
                var mediosCobroOOB = _gCobro.GetDataExportar.Select(s => 
                {
                    var nr = new OOB.Venta.Insertar.medioCobroAgregar()
                    {
                        coCajaDestino = s.data.cajaCobro.cod_caja,
                        formaPago = "EF",
                        monto = s.Importe,
                        tipoSaldo = "EF",
                        coCtaIngreso = "I00001",
                        coSucursal = Sistema.MyConfiguracion.codSucursal,
                        coUsuario = Sistema.Usuario.CodUsuario,
                        tasaCambio = s.data.tasaCalcular,
                    };
                    return nr;
                }).ToList();
                var docCobroOOB = new OOB.Venta.Insertar.docCobroAgregar()
                {
                    ActivarAjustePorCambioVuelto = _gCobro.GetMontoCambio > 0m,
                    CambioVuelto = _gCobro.GetMontoCambio,
                    docCobro = new OOB.Venta.Insertar.cobroAgregar()
                    {
                        coCliente = _docProceso.GetCliente.co_cli,
                        coMoneda = _docProceso.GetCodMoneda,
                        coSucursal = Sistema.MyConfiguracion.codSucursal,
                        coUsuario = Sistema.Usuario.CodUsuario,
                        coVendedor = _docProceso.GetVendedor.co_ven,
                        tasaCambio = _docProceso.TasaCambioActual,
                    },
                    mediosCobro = mediosCobroOOB,
                };
                var fichaOOB = new OOB.Venta.Insertar.FichaAgregar()
                {
                    nroDocPedido = _docProceso.GetEncabezado.doc_num,
                    coSerieControl = "FACT_VTA_N_CON",
                    coSerieDocumento = _serieSeleccion.co_consecutivo,
                    NombreEquipo = Sistema.MyConfiguracion.NombreEquipo,
                    encabezado = encabezadoOOB,
                    cuerpo = cuerpoOOB,
                    stockAct = stockArtOOB,
                    stockPendAct = stockPendActOOB,
                    docVenta = docVentaOOB,
                    docCobro= docCobroOOB,
                };
                var r01 = Sistema.MyData.vta_Insertar(fichaOOB);
                _facturarIsOk = true;
                Sistema.MyConfiguracion.SerieProcesar = _gSerieProcesar.SerieSeleccion;
                var regVenta = r01.Entidad;
                

                //
                //
                //
                var _itemsImprimir = new List<Imprimir.data.Item>();
                foreach (var rg in _docProceso.GetItemsPedido)
                {
                    var nr = new Imprimir.data.Item()
                    {
                        Cantidad = rg.total_art,
                        CodigoPrd = rg.co_art.Trim(),
                        Contenido = 1,
                        DepositoCodigo = "",
                        DepositoDesc = "",
                        Empaque = rg.co_uni.Trim(),
                        Importe = 0m,
                        ImporteDivisa = 0m,
                        ImporteFull = 0m,
                        NombrePrd = rg.art_des,
                        Precio = rg.prec_vta,
                        PrecioDivisa = 0m,
                        TasaIva = rg.porc_imp, 
                        TotalUnd = rg.total_art,
                    };
                    _itemsImprimir.Add(nr);
                }
                var _dirCli = "GUACARA, EDO CARABOBO";
                if (_docProceso.GetCliente !=null) 
                {
                    if (_docProceso.GetCliente.direc1 != null)
                    {
                        _dirCli = _docProceso.GetCliente.direc1.Trim(); 
                    }
                }
                //IMPRIMIR DOCUMENTO
                var xdata = new Imprimir.data()
                {
                    isAnulado = false,
                    encabezado = new Imprimir.data.Encabezado()
                    {
                        CiRifCli = _docProceso.GetDoc_RifCliente,
                        NombreCli = _docProceso.GetDoc_NombreCliente,
                        DireccionCli = _dirCli,
                        DocumentoHora = regVenta.hora,
                        DocumentoFecha = regVenta.fecha,
                        DocumentoNombre = "Nota de Despacho",
                        DocumentoNro = regVenta.nroDocPed,
                        SubTotal = _docProceso.GetTotalBruto,
                        MontoIva = _docProceso.IvaMonto,
                        Total = _docProceso.GetTotalNeto,
                    },
                    item = _itemsImprimir,
                    metodoPago = new List<Imprimir.data.MetodoPago>()
                    {
                    },
                    medidaEmp = new List<Imprimir.data.MedidaEmp>()
                    {
                    },
                };
                var _dirFiscal = "AV. CARABOBO, C.C. CARABOBO LOCAL 6 Y 7";
                Sistema.ImprimirFactura.setDatosEmpresa("J07588059-5", "EL PALACIO DEL PAN, C.A", _dirFiscal, "GUACARA EDO CARABOBO");
                Sistema.ImprimirFactura.setData(xdata);
                if (Sistema.ImprimirFactura.IsModoTicket)
                {
                    printDocument1.Print();
                }

            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void TarjetaNueva()
        {
            _facturarIsOk = false;
            _abandonarIsOk = false;
            _buscarTarjetaIsOk = false;
            _idTarjeta = "";
            _docProceso.Inicializa();
            _gItem.Inicializa();
            _pedirTarjetaNueva = true;
        }


        private bool _agregarArticuloIsOk;
        public bool AgregarArticuloIsOk { get { return _agregarArticuloIsOk; } }
        public void AgregarArticulo()
        {
            _agregarArticuloIsOk = false;
            if (_docProceso.HayTarjetaCargada)
            {
                _gSelArt.Inicializa();
                _gSelArt.Inicia();
                if (_gSelArt.SeleccionIsOk)
                {
                    try
                    {
                        var _cnt = 0m;
                        var r01 = Sistema.MyData.art_ObtenerFichaById(_gSelArt.GetIdItemSeleccionado);
                        var _modo = _gCantSolicitarNoPesado;
                        if (r01.Entidad.esPesado)
                        {
                            _modo = _gCantSolicitarPesado;
                        }
                        _modo.Inicializa();
                        _modo.Inicia();
                        if (_modo.CantSolicitarIsOk)
                        {
                            _cnt = _modo.GetCntSolicitada;
                        }
                        if (_cnt > 0m)
                        {
                            CargarInsertarItem(r01.Entidad.co_art, _cnt);
                        }
                    }
                    catch (Exception e)
                    {
                        Helpers.Msg.Error(e.Message);
                    }
                }
            }
        }

        private void CargarInsertarItem(string idArticulo, decimal cnt)
        {
            try
            {
                var r01 = Sistema.MyData.art_ObtenerFichaById(idArticulo);
                var codUnd = r01.Entidad.UnidadPrincipal;
                var precioConIvaIncluido = false;
                var codMonedaBase = Sistema.MyConfiguracion.codMoneda_Trabajo; //BSS
                var codMonedaManejoPrecio = Sistema.MyConfiguracion.codMoneda_PrecioArticulo;//US$
                var codAlmacen = Sistema.MyConfiguracion.codAlmacen;//01
                var codPrecio = Sistema.MyConfiguracion.codPrecio;//01
                var fecha = Sistema.MyConfiguracion.FechaServidor;//ACTUAL DEL SERVIDOR
                //
                var r02 = Sistema.MyData.art_ObtenerPrecio(idArticulo, fecha, codPrecio, codAlmacen, codMonedaBase, precioConIvaIncluido, codUnd);
                var r03 = Sistema.MyData.sist_TasaCambio_ObtenerFicha(codMonedaManejoPrecio, fecha);
                //
                if (r02.Entidad == 0m)
                {
                    throw new Exception("ARTICULO NO POSEE PRECIO DE VENTA, VERIFIQUE POR FAVOR");
                }
                _docProceso.InsertarItem(r01.Entidad, Math.Round(r02.Entidad, 2, MidpointRounding.AwayFromZero), cnt, r03.Entidad, codAlmacen, codPrecio);
                _gItem.setData(_docProceso.GetItems());
                _agregarArticuloIsOk = true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private bool _eliminarArticuloIsOk;
        public bool EliminarArticuloIsOk { get { return _eliminarArticuloIsOk; } } 
        public void EliminarArticulo()
        {
            _eliminarArticuloIsOk = false;
            if (_docProceso.HayTarjetaCargada)
            {
                if (_gItem.ItemActual != null) 
                {
                    var _item = (dataItem)_gItem.ItemActual;
                    var xmsg = "Estas Seguro de Eliminar este Item ?";
                    var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.Yes) 
                    {
                        EliminarItem(_item);
                    }
                }
            }
        }
        private void EliminarItem(dataItem item)
        {
            _docProceso.EliminarItem(item.Renglon);
            _gItem.setData(_docProceso.GetItems());
            _eliminarArticuloIsOk = true;
        }


        private bool _buscarClienteIsOk;
        public bool BuscarClienteIsOk { get { return _buscarClienteIsOk; } }
        public void BuscarCliente()
        {
            _buscarClienteIsOk = false;
            if (_docProceso.HayTarjetaCargada)
            {
                AsignarCliente();
            }
            else 
            {
                BuscarTarjetaPorCliente();
            }
        }
        private void BuscarTarjetaPorCliente()
        {
            _gSolicitarCli.Inicializa();
            _gSolicitarCli.Inicia();
            if (_gSolicitarCli.ClientSeleccionadoIsOk)
            {
                _idTarjeta = _gSolicitarCli.ClientSeleccionado.co_cli;
                BuscarTarjeta(true);
            }
        }
        private void AsignarCliente()
        {
            _gSolicitarCli.Inicializa();
            _gSolicitarCli.Inicia();
            if (_gSolicitarCli.ClientSeleccionadoIsOk)
            {
                _buscarClienteIsOk = true;
                _docProceso.setCliente(_gSolicitarCli.ClientSeleccionado);
            }
        }

        private bool _editarItemIsOk;
        public bool EditarItemIsOk { get { return _editarItemIsOk; } }
        public void EditarItem()
        {
            _editarItemIsOk = false;
            if (_docProceso.HayTarjetaCargada)
            {
                if (_gItem.ItemActual != null)
                {
                    var _item = (dataItem)_gItem.ItemActual;
                    var _modo = _gCantSolicitarNoPesado;
                    if (_item.esPesado)
                    {
                        _modo =_gCantSolicitarPesado;
                    }
                    _modo.Inicializa();
                    _modo.setCant(_item.Cantidad);
                    _modo.Inicia();
                    if (_modo.CantSolicitarIsOk)
                    {
                        _docProceso.ActualizarCntItem(_item, _modo.GetCntSolicitada);
                        _gItem.setData(_docProceso.GetItems());
                        _editarItemIsOk = true;
                    }
                }
            }
        }

        public DateTime GetDoc_FechaEmision { get { return _docProceso.GetDoc_FechaEmision; } }
        public string GetDoc_RifCliente { get { return _docProceso.GetDoc_RifCliente; } }
        public string GetDoc_NombreCliente { get { return _docProceso.GetDoc_NombreCliente; } }
        public string GetDoc_Vendedor { get { return _docProceso.GetDoc_Vendedor; } }
        public string GetDoc_Transporte { get { return _docProceso.GetDoc_Transporte; } }
        public string GetDoc_CondPago { get { return _docProceso.GetDoc_CondPago; } }


        private void ProcesarItem(string idPrd)
        {
            if (_docProceso.HayTarjetaCargada)
            {
                try
                {
                    var _cnt = 1m;
                    var r01 = Sistema.MyData.art_ObtenerFichaById(idPrd);
                    if (r01.Entidad.esPesado)
                    {
                        var _modo = _gCantSolicitarPesado;
                        _modo.Inicializa();
                        _modo.Inicia();
                        if (_modo.CantSolicitarIsOk)
                        {
                            _cnt = _modo.GetCntSolicitada;
                        }
                    }
                    if (_cnt > 0m)
                    {
                        CargarInsertarItem(idPrd, _cnt);
                    }
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Cancel = false;
            Sistema.ImprimirFactura.setControlador(e);
            Sistema.ImprimirFactura.ImprimirDoc();
        }
        private void CargarTarjetaSinPedido()
        {
            _buscarTarjetaIsOk = false;
            var _codCli = "";
            var _numPed = "";
            var _codVend = "";
            var _codCondPag = "";
            var _codtrans = "";
            var _codMone = "";
            try
            {
                var fechaServ = Sistema.MyConfiguracion.FechaServidor;
                var r01 = Sistema.MyData.cli_ObtenerFichaById("01");
                _codCli = r01.Entidad.co_cli.Trim();
                var r02 = Sistema.MyData.tasa_ObtenerTipoTasaFiscal();
                var r03 = Sistema.MyData.tasa_ObtenerTasaPorTipoValor(fechaServ);
                //
                _codVend = Sistema.Usuario.CodUsuario;
                _codCondPag = "000001";
                _codtrans = "000001";
                _codMone = "US$";
                var v07 = Sistema.MyData.sist_vend_ObtenerFicha(_codVend);
                var v08 = Sistema.MyData.sist_condPago_ObtenerFicha(_codCondPag);
                var v09 = Sistema.MyData.sist_transporte_ObtenerFicha(_codtrans);
                var v0A = Sistema.MyData.sist_moneda_ObtenerFicha(_codMone);
                var v0B = Sistema.MyData.sist_TasaCambio_ObtenerFicha(_codMone, fechaServ);
                _buscarTarjetaIsOk = true;
                //
                var _pedido = new OOB.Venta.Pedido();
                _pedido.ValoresPorDefecto(_codCli, _codVend, _codCondPag, _codtrans, _codMone, fechaServ, v0B.Entidad, "000001");
                _docProceso.setTarjetaId(_idTarjeta);
                _docProceso.setTarjetaIdPorCiRif(false);
                _docProceso.setCliente(r01.Entidad);
                _docProceso.setTasaFiscalTipo(r02.Lista);
                _docProceso.setTasaFiscalValor(r03.Lista);
                _docProceso.setEncabezado(_pedido);
                _docProceso.setCuerpo(new List<OOB.Venta.PedidoDetalle>());
                _docProceso.setVendedor(v07.Entidad);
                _docProceso.setCondPago(v08.Entidad);
                _docProceso.setTransporte(v09.Entidad);
                _docProceso.setMoneda(v0A.Entidad);
                _docProceso.setTasaCambio(v0B.Entidad);
                //
                _gItem.setData(_docProceso.GetItems());
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        //void Imprime()
        //{
        //    var xr1 = Sistema.MyData.Documento_GetById(idDoc);
        //    if (xr1.Result == OOB.Resultado.Enumerados.EnumResult.isError)
        //    {
        //        Helpers.Msg.Error(xr1.Mensaje);
        //        return null;
        //    }

        //    var xr2 = Sistema.MyData.Documento_Get_MetodosPago_ByIdRecibo(xr1.Entidad.AutoReciboCxC);
        //    if (xr2.Result == OOB.Resultado.Enumerados.EnumResult.isError)
        //    {
        //        Helpers.Msg.Error(xr2.Mensaje);
        //        return null;
        //    }

        //    var xdata = new Helpers.Imprimir.data();
        //    xdata.isAnulado = xr1.Entidad.EstatusAnulado == "1";
        //    xdata.negocio = new Helpers.Imprimir.data.Negocio()
        //    {
        //        Nombre = Sistema.DatosEmpresa.Nombre,
        //        CiRif = Sistema.DatosEmpresa.CiRif,
        //        Direccion = Sistema.DatosEmpresa.Direccion,
        //        Telefonos = Sistema.DatosEmpresa.Telefono,
        //    };
        //    var docNombre = "";
        //    switch (xr1.Entidad.Tipo.Trim().ToUpper())
        //    {
        //        case "01":
        //            docNombre = "FACTURA";
        //            break;
        //        case "02":
        //            docNombre = "NOTA DE DEBITO";
        //            break;
        //        case "03":
        //            docNombre = "NOTA DE CREDITO";
        //            break;
        //        case "04":
        //            docNombre = "NOTA DE ENTREGA";
        //            break;
        //    }
        //    xdata.encabezado = new Helpers.Imprimir.data.Encabezado()
        //    {
        //        CiRifCli = xr1.Entidad.CiRif,
        //        DireccionCli = xr1.Entidad.DirFiscal,
        //        DocumentoCondicionPago = xr1.Entidad.CondicionPago,
        //        DocumentoControl = xr1.Entidad.Control,
        //        DocumentoDiasCredito = xr1.Entidad.Dias,
        //        DocumentoFecha = xr1.Entidad.Fecha,
        //        DocumentoFechaVencimiento = xr1.Entidad.FechaVencimiento,
        //        DocumentoNombre = docNombre,
        //        DocumentoNro = xr1.Entidad.DocumentoNro,
        //        DocumentoSerie = xr1.Entidad.Serie,
        //        DocumentoAplica = xr1.Entidad.Aplica,
        //        NombreCli = xr1.Entidad.RazonSocial,
        //        FactorCambio = xr1.Entidad.FactorCambio,
        //        SubTotal = xr1.Entidad.SubTotal,
        //        Descuento = xr1.Entidad.Descuento,
        //        Total = xr1.Entidad.Total,
        //        TotalDivisa = xr1.Entidad.MontoDivisa,
        //        EstacionEquipo = xr1.Entidad.Estacion,
        //        Usuario = xr1.Entidad.Usuario,
        //        CambioDar = xr1.Entidad.Cambio,
        //        DocumentoHora = xr1.Entidad.Hora,
        //        TelefonoCli = xr1.Entidad.Telefono,
        //        CodigoCli = xr1.Entidad.CodigoCliente,
        //        DescuentoPorc = xr1.Entidad.Descuento1p,
        //        Cargo = xr1.Entidad.Cargos,
        //        CargoPorc = xr1.Entidad.Cargosp,
        //        VueltoEfectivo = xr1.Entidad.MontoPorVueltoEnEfectivo,
        //        VueltoDivisa = xr1.Entidad.MontoPorVueltoEnDivisa,
        //        VueltoPagoMovil = xr1.Entidad.MontoPorVueltoEnPagoMovil,
        //        CntDivisaVueltoDivisa = xr1.Entidad.CantDivisaPorVueltoEnDivisa,
        //        //
        //        BonoPorPagoDivisa = xr1.Entidad.BonoPorPagoDivisa,
        //        MontoBonoPorPagoDivisa = xr1.Entidad.MontoBonoPorPagoDivisa,
        //        CntDivisaAplicaBonoPorPagoDivisa = xr1.Entidad.CntDivisaAplicaBonoPorPagoDivisa,
        //    };
        //    xdata.item = new List<Helpers.Imprimir.data.Item>();
        //    foreach (var rg in xr1.Entidad.items)
        //    {
        //        var nr = new Helpers.Imprimir.data.Item()
        //        {
        //            NombrePrd = rg.Nombre,
        //            CodigoPrd = rg.Codigo,
        //            Cantidad = rg.Cantidad,
        //            Contenido = rg.ContenidoEmpaque,
        //            DepositoCodigo = rg.CodigoDeposito,
        //            DepositoDesc = rg.Deposito,
        //            Empaque = rg.Empaque,
        //            Importe = rg.TotalNeto,
        //            ImporteDivisa = rg.TotalNeto,
        //            Precio = rg.PrecioItem,
        //            PrecioDivisa = rg.PrecioItem,
        //            TotalUnd = rg.CantidadUnd,
        //            TasaIva = rg.Tasa,
        //            ImporteFull = rg.Total,
        //        };
        //        xdata.item.Add(nr);
        //    }

        //    xdata.metodoPago = new List<Helpers.Imprimir.data.MetodoPago>();
        //    foreach (var mp in xr2.ListaD)
        //    {
        //        if (Math.Abs(mp.cntDivisa) >= 1)
        //        {
        //            var pag = new Helpers.Imprimir.data.MetodoPago() { descripcion = "Efectivo($" + mp.cntDivisa.ToString() + ")", monto = mp.montoRecibido };
        //            xdata.metodoPago.Add(pag);
        //        }
        //        else
        //        {
        //            var pag = new Helpers.Imprimir.data.MetodoPago() { descripcion = mp.descMedioPago, monto = mp.montoRecibido };
        //            xdata.metodoPago.Add(pag);
        //        }
        //    }
        //    xdata.medidaEmp = xr1.Entidad.medidas.Select(s =>
        //    {
        //        var med = new Helpers.Imprimir.data.MedidaEmp()
        //        {
        //            cant = s.cant,
        //            desc = s.desc,
        //            peso = s.peso,
        //            volumen = s.volumen,
        //        };
        //        return med;
        //    }).ToList();

        //    return xdata;
        //}
    }

}