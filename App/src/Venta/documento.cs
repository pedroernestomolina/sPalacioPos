using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Venta
{
    
    public class documento
    {

        private string _idTarjeta;
        private bool _isTarjetaIdCiRif; 
        private OOB.Cliente.Ficha _cliente;
        private List<OOB.TasaFiscal.Tipo> _tasaFiscalTipo;
        private List<OOB.TasaFiscal.TipoValor> _tasaFiscalValor;
        private OOB.Venta.Pedido _encabezado;
        private List<OOB.Venta.PedidoDetalle> _cuerpo;
        private OOB.Sistema.Vendedor.Ficha _vendedor;
        private OOB.Sistema.CondPago.Ficha _condPago;
        private OOB.Sistema.Transporte.Ficha _transporte;
        private OOB.Sistema.Moneda.Ficha _moneda;
        private decimal _tasaCambio;


        public documento()
        {
            _idTarjeta = "";
            _isTarjetaIdCiRif = false; 
            _tasaCambio = 0m;
            _cliente = null;
            _tasaFiscalTipo = null;
            _tasaFiscalValor = null;
            _encabezado = null;
            _cuerpo = null;
            _vendedor = null;
            _condPago = null;
            _transporte = null;
            _moneda = null;
        }


        public void Inicializa()
        {
            _idTarjeta = "";
            _isTarjetaIdCiRif = false;
            _tasaCambio = 0m;
            _cliente = null;
            _tasaFiscalTipo = null;
            _tasaFiscalValor = null;
            _encabezado = null;
            _cuerpo = null;
            _vendedor = null;
            _condPago = null;
            _transporte = null;
            _moneda = null;
        }


        public void setTarjetaId(string idTarjeta)
        {
            _idTarjeta = idTarjeta;
        }
        public void setTarjetaIdPorCiRif(bool isTarjetaIdCiRif)
        {
            _isTarjetaIdCiRif = isTarjetaIdCiRif;
        }
        public void setCliente(OOB.Cliente.Ficha ficha)
        {
            _cliente = ficha;
        }
        public void setTasaFiscalTipo(List<OOB.TasaFiscal.Tipo> list)
        {
            _tasaFiscalTipo = list;
        }
        public void setTasaFiscalValor(List<OOB.TasaFiscal.TipoValor> list)
        {
            _tasaFiscalValor = list;
        }
        public void setEncabezado(OOB.Venta.Pedido pedido)
        {
            _encabezado = pedido;
        }
        public void setCuerpo(List<OOB.Venta.PedidoDetalle> list)
        {
            _cuerpo = list;
        }
        public void setVendedor(OOB.Sistema.Vendedor.Ficha ficha)
        {
            _vendedor = ficha;
        }
        public void setCondPago(OOB.Sistema.CondPago.Ficha ficha)
        {
            _condPago = ficha;
        }
        public void setTransporte(OOB.Sistema.Transporte.Ficha ficha)
        {
            _transporte = ficha;
        }
        public void setMoneda(OOB.Sistema.Moneda.Ficha ficha)
        {
            _moneda = ficha;
        }
        public void setTasaCambio(decimal tasa)
        {
            _tasaCambio = tasa;
        }
        public List<dataItem> GetItems() 
        {
            return _cuerpo.Select(s =>
            {
                var _tasaIva = 0m;
                var _ent=  _tasaFiscalValor.FirstOrDefault(f => f.tipo_imp == s.tipo_imp);
                if (_ent != null) 
                {
                    _tasaIva = _ent.porc_tasa;
                }
                var nr = new dataItem()
                {
                    Articulo = s.art_des,
                    Cantidad = s.total_art,
                    Renglon = s.reng_num,
                    Unidad = s.co_uni,
                    Precio = s.prec_vta,
                    TasaIva = _tasaIva,
                    Importe = s.reng_neto,
                    esPesado = s.esPesado,
                };
                return nr;
            }).ToList();
        }


        public decimal SubTotalMonto 
        { 
            get 
            {
                var t = 0m;
                if (_encabezado != null) 
                {
                    t = _encabezado.total_bruto;
                }
                return t;
            } 
        }
        public decimal IvaMonto
        {
            get
            {
                var t = 0m;
                if (_encabezado != null)
                {
                    t += _encabezado.monto_imp;
                    t += _encabezado.monto_im2;
                    t += _encabezado.monto_im3;
                }
                return t;
            }
        }
        public decimal TotalMonto
        {
            get
            {
                var t = 0m;
                if (_encabezado != null)
                {
                    t += _encabezado.total_neto;
                }
                return t;
            }
        }
        public decimal TotalDivisaMonto 
        {
            get
            {
                var t = 0m;
                if (_encabezado != null)
                {
                    t += TotalMonto / _tasaCambio;
                }
                return t;
            }
        }
        public decimal TasaCambioActual 
        { 
            get { return _tasaCambio; } 
        }
        public string GetTarjeta_ID 
        {
            get 
            {
                var rt = _idTarjeta;
                return rt;
            }
        }
        public string GetTarjeta_ID_TIPO 
        {
            get 
            {
                var rt = _idTarjeta;
                if (_isTarjetaIdCiRif)
                { rt = "RIF"; }
                return rt;
            }
        }


        public bool HayTarjetaCargada { get { return _idTarjeta != ""; } }  //verificar si hay una tarjeta cargada
        public void InsertarItem(OOB.Articulo.Ficha art, decimal precioNeto , decimal cnt, decimal tasaCambio, string codAlmacen, string codPrecio)
        {
            var _nr = 1;
            if (_cuerpo.Count > 0)
            {
                _nr=_cuerpo.Max(f => f.reng_num) + 1;
            }
            var _rengNeto= cnt*precioNeto;
            var _nuevoItem = new OOB.Venta.PedidoDetalle()
            {
                reng_num = _nr,
                doc_num = _encabezado.doc_num,
                co_art = art.co_art,
                des_art = null,
                co_alma = codAlmacen,
                total_art = cnt,
                stotal_art = 0m,
                co_uni = art.co_uni,
                sco_uni = null,
                co_precio = codPrecio,
                prec_vta = precioNeto,
                prec_vta_om = null,
                porc_desc = null,
                monto_desc = 0m,
                tipo_imp = art.tipo_imp,
                tipo_imp2 = art.tipo_imp2,
                tipo_imp3 = art.tipo_imp3,
                porc_imp = 0m,
                porc_imp2 = 0m,
                porc_imp3 = 0m,
                monto_imp = 0m,
                monto_imp2 = 0m,
                monto_imp3 = 0m,
                reng_neto = _rengNeto,
                pendiente = 0m,
                pendiente2 = 0m,
                lote_asignado = false,
                tipo_doc = null,
                num_doc = null,
                monto_desc_glob = 0m,
                monto_reca_glob = 0m,
                otros1_glob = 0m,
                otros2_glob = 0m,
                otros3_glob = 0m,
                monto_imp_afec_glob = 0m,
                monto_imp2_afec_glob = 0m,
                monto_imp3_afec_glob = 0m,
                total_dev = 0m,
                monto_dev = 0m,
                otros = 0m,
                tasa = tasaCambio,
                art_des = art.art_des,
                modelo = art.modelo,
                relac_unidad = art.relac_unidad,
                co_lin = art.co_lin,
                co_cat = art.co_cat,
                rowguid_articulo = art.rowguid,
                maneja_lote = art.maneja_lote,
                maneja_lote_venc = art.maneja_lote_venc,
                maneja_serial = art.maneja_serial,
                tipo_imp_art = art.tipo_imp,
            };
            _cuerpo.Add(_nuevoItem);
            ActualizarSaldos();
        }
        public void EliminarItem(int id)
        {
            var ent = _cuerpo.FirstOrDefault(f => f.reng_num == id);
            if (ent != null) 
            {
                var _rengNeto = (ent.prec_vta * ent.total_art)*(-1);
                _cuerpo.Remove(ent);
                var _id = 0;
                foreach (var rg in _cuerpo)
                {
                    _id += 1;
                    rg.reng_num = _id;
                }
                ActualizarSaldos();
            }
        }
        private void ActualizarSaldos() 
        {
            var _montoImp = 0m;
            var _montoNeto = 0m;
            var gr = _cuerpo.GroupBy(g => g.tipo_imp).Select(t => new { key = t.Key, res = t.Sum(d => d.total_art * d.prec_vta) }).ToList();
            foreach (var rg in gr)
            {
                _montoNeto += rg.res;
                var _tasaFiscal = 0m;
                var entTasaFiscal = _tasaFiscalValor.FirstOrDefault(f => f.tipo_imp == rg.key);
                if (entTasaFiscal != null)
                {
                    _tasaFiscal = entTasaFiscal.porc_tasa;
                }
                _montoImp += Math.Round((rg.res * _tasaFiscal / 100), 2, MidpointRounding.AwayFromZero);
            }
            _montoNeto = Math.Round(_montoNeto,2);
            _montoImp = Math.Round(_montoImp,2);
            _encabezado.ActualizarSaldo(_montoNeto, _montoImp);
        }

        public void ActualizarCntItem(dataItem _item, decimal cnt)
        {
            var _ent = _cuerpo.FirstOrDefault(f => f.reng_num == _item.Renglon);
            _ent.total_art = cnt;
            _ent.reng_neto = _ent.total_art * _ent.prec_vta;
            ActualizarSaldos();
        }

        public DateTime GetDoc_FechaEmision 
        { 
            get 
            { 
                var rt= DateTime.Now.Date;
                if (_encabezado != null)
                    rt = _encabezado.fec_emis;
                return rt;
            } 
        }
        public string GetDoc_RifCliente
        {
            get
            {
                var rt = "";
                if (_cliente != null)
                    rt = _cliente.rif;
                return rt;
            }
        }
        public string GetDoc_NombreCliente 
        { 
            get 
            {
                var rt = "";
                if (_cliente != null)
                    rt = _cliente.cli_des;
                return rt;
            } 
        }
        public string GetDoc_Vendedor
        {
            get
            {
                var rt = "";
                if (_vendedor != null)
                    rt = _vendedor.ven_des.Trim() + "(" + _vendedor.co_ven.Trim() + ")";
                return rt;
            }
        }
        public string GetDoc_CondPago
        {
            get
            {
                var rt = "";
                if (_condPago != null)
                    rt = _condPago.cond_des.Trim() + "(" + _condPago.co_cond.Trim() + ")";
                return rt;
            }
        }
        public string GetDoc_Transporte
        {
            get
            {
                var rt = "";
                if (_transporte != null)
                    rt = _transporte.des_tran.Trim() + "(" + _transporte.des_tran.Trim() + ")";
                return rt;
            }
        }

        //
        public OOB.Cliente.Ficha GetCliente { get { return _cliente; } }
        public OOB.Sistema.CondPago.Ficha GetCondPago { get { return _condPago; } }
        public OOB.Sistema.Vendedor.Ficha GetVendedor { get { return _vendedor; } }
        public OOB.Sistema.Transporte.Ficha GetTransporte { get { return _transporte; } }
        //
        public string GetCodMoneda { get { return _encabezado.co_mone; } }
        public decimal GetMontoImpuesto { get { return _encabezado.monto_imp; } }
        public decimal GetSaldo { get { return _encabezado.saldo; } }
        public decimal GetTotalBruto { get { return _encabezado.total_bruto; } }
        public decimal GetTotalNeto { get { return _encabezado.total_neto; } }
        //
        public List<OOB.Venta.PedidoDetalle> GetItemsPedido { get { return _cuerpo.ToList(); } }
        //
        public OOB.Venta.Pedido GetEncabezado { get { return _encabezado; } }
    }

}