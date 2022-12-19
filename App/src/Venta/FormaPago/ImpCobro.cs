using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta.FormaPago
{
    
    public class ImpCobro: ICobro
    {


        private decimal _montoCobrar;
        private decimal _montoCobrarDiv;
        private decimal _montoAbonado;
        private decimal _montoPend;
        private decimal _tasaCambio;
        private Agregar.IAgregar _gAgregarMC;
        private IListaMC _gLista;


        public decimal GetMontoCobrar { get { return _montoCobrar; } }
        public decimal GetMontoAbonado { get { return _montoAbonado; } }
        public decimal GetMontoCobrarDiv { get { return _montoCobrarDiv; } }
        public decimal GetMontoPend { get { return _montoPend; } }
        public decimal GetMontoPendDiv { get { return _montoPend / _tasaCambio; } }
        public dataMedioCobro ItemActual { get { return (dataMedioCobro)_gLista.ItemActual; } }
        public BindingSource GetData_Source { get { return _gLista.GetSource; } }
        public bool GetCambiosVueltoIsActivo { get { return _montoAbonado >= _montoCobrar; } }
        public decimal GetMontoCambio { get { return _montoAbonado - _montoCobrar; } }
        public List<dataMedioCobro> GetDataExportar { get { return (List<dataMedioCobro>)_gLista.GetListaItems; } }


        public ImpCobro()
        {
            _montoCobrar = 0m;
            _montoPend = 0m;
            _tasaCambio = 0m;
            _gLista = new ImpListaMC();
            _gAgregarMC = new Agregar.ImpAgregar();
        }


        public void Inicializa()
        {
            _aceptarProcesarIsOk = false;
            _montoCobrar = 0m;
            _montoCobrarDiv = 0m;
            _montoPend = 0m;
            _tasaCambio = 0m;
            _gLista.Inicializa();
        }
        private FormaPagoFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new FormaPagoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        private bool _abandonar;
        public bool AbandonarIsOk { get { return _abandonar; } }
        public void AbandonarFicha()
        {
            var xmsg="Abandonar Gestión De Cobro ?";
            _abandonar = Helpers.Msg.Abandonar(xmsg);
        }

        private bool _aceptarProcesarIsOk;
        public bool IsOk { get { return _aceptarProcesarIsOk; } }
        public bool AceptarProcesarIsOk { get { return _aceptarProcesarIsOk; } }
        public void AceptarProcesar()
        {
            _aceptarProcesarIsOk = false;
            if (_montoAbonado >= _montoCobrar)
            {
                var xmsg = "Procesar Cobro ?";
                var xr = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (xr == DialogResult.Yes) 
                {
                    _aceptarProcesarIsOk = true;
                }
            }
        }


        public bool AgregarMetCobroIsOk { get { return _gAgregarMC.AceptarProcesarIsOk; } }
        public void AgregarMetCobro()
        {
            if (_montoPend > 0)
            {
                _gAgregarMC.Inicializa();
                _gAgregarMC.setMontoPendiente(_montoPend);
                _gAgregarMC.setMontoPendienteDivisa(_montoCobrarDiv);
                _gAgregarMC.setTasaCambio(_tasaCambio);
                _gAgregarMC.Inicia();
                if (_gAgregarMC.AceptarProcesarIsOk)
                {
                    _gLista.InsertarItem(_gAgregarMC.GetDataExportar);
                    ActualizarSaldoPend();
                }
            }
        }


        public void setMontoCobrar(decimal montoCob)
        {
            _montoCobrar = montoCob;
            ActualizarSaldoPend();
        }
        public void setMontoCobrarDivisa(decimal montoCobDivisa)
        {
            _montoCobrarDiv = montoCobDivisa;
            ActualizarSaldoPend();
        }
        public void setTasaCambio(decimal tasa)
        {
            _tasaCambio = tasa;
        }

        public void EliminarMetCobro()
        {
            if (ItemActual != null) 
            {
                var xmsg = "Estas seguro de eliminar este Método de Pago ?";
                var xr = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (xr == DialogResult.Yes)
                {
                    _gLista.EliminarItem(ItemActual.id);
                    ActualizarSaldoPend();
                }
            }
        }
        public void LimpiarMetCobro()
        {
            if (_gLista.GetCtnItems > 0) 
            {
                var xmsg="Estas seguro de limpiar los Métodos de Pagos Definidos ?";
                var xr= MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (xr == DialogResult.Yes) 
                {
                    _gLista.LimpiarItems();
                    ActualizarSaldoPend();
                }
            }
        }


        private bool CargarData()
        {
            return true;
        }
        private void ActualizarSaldoPend()
        {
            _montoAbonado = _gLista.GetTotalCobrado;
            _montoPend = _montoCobrar - _gLista.GetTotalCobrado;
        }

    }

}