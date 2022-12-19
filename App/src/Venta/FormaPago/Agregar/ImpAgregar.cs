using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta.FormaPago.Agregar
{
    
    public class ImpAgregar: IAgregar
    {

        private hlp.Opcion.IOpcion _gMetodo;
        private decimal _montoPend;
        private decimal _montoPendDivisa;
        private decimal _tasaCambio;
        private decimal _montoCobrar;
        private decimal _total;
        private decimal _tasaCalcular;
        private OOB.Sistema.CajaPago.Ficha _cajaCobro;


        public decimal GetMontoPend { get { return _montoPend; } }
        public string GetMedioPago_Id { get { return _gMetodo.GetId; } }
        public BindingSource GetMedioPago_Source { get { return _gMetodo.Source; } }
        public decimal GetTasaCalculo { get { return _tasaCalcular; } }
        public decimal GetMonto { get { return _montoCobrar; } }
        public decimal GetTotal { get { return _total; } }
        public bool GetMedioPago_IsDivisa { get { return _cajaCobro.isDivisa; } }
        public string GetMontoPendStr { get { return "Bs "+_montoPend.ToString("n2") + "/ $ " + _montoPendDivisa.ToString("n2"); } }
        public dataAgregar GetDataExportar
        {
            get 
            {
                var nr = new dataAgregar()
                {
                    cajaCobro = _cajaCobro,
                    montoCobrar = _montoCobrar,
                    montoPend = _montoPend,
                    tasaCalcular = _tasaCalcular,
                    tasaCambio = _tasaCambio,
                    total = _total,
                };
                return nr;
            }
        }


        public ImpAgregar()
        {
            _montoPend = 0m;
            _montoPendDivisa = 0m;
            _montoCobrar = 0m;
            _tasaCambio = 0m;
            _tasaCalcular = 0m;
            _total = 0m;
            _aceptar = false;
            _abandonar=false;
            _cajaCobro = null;
            _gMetodo = new hlp.Opcion.ImpOpcion();
        }


        public void Inicializa()
        {
            _montoPend = 0m;
            _montoPendDivisa = 0m;
            _montoCobrar = 0m;
            _tasaCambio = 0m;
            _aceptar = false;
            _abandonar = false;
            _cajaCobro = null;
            _tasaCalcular = 0m;
            _total = 0m;
            _gMetodo.Inicializa();

        }
        AgregarFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new AgregarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        private bool _abandonar;
        public bool AbandonarIsOk { get { return _abandonar; } }
        public void AbandonarFicha()
        {
            _abandonar = Helpers.Msg.Abandonar();
        }


        private bool _aceptar;
        public bool AceptarProcesarIsOk { get { return _aceptar; } }
        public void AceptarProcesar()
        {
            _aceptar = false;
            if (_gMetodo.GetId=="")
            {
                Helpers.Msg.Alerta("NO SE HA SELECCIONADO LA CAJA DE COBRO");
                return;
            }
            if (_montoCobrar == 0m) 
            {
                Helpers.Msg.Alerta("EL MONTO A COBRAR DEBE SER MAYOR A CERO(0)");
                return;
            }
            var xmsg = "Procesar Medio de Pago ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _aceptar = true;
            }
        }

        public void setMontoPendiente(decimal monto)
        {
            _montoPend = monto;
        }
        public void setMontoPendienteDivisa(decimal monto)
        {
            _montoPendDivisa = monto;
        }
        public void setTasaCambio(decimal monto)
        {
            _tasaCambio = monto;
        }
        public void setMetodoPago(string id)
        {
            if (id.Trim() == "") 
            {
                _gMetodo.setFicha("");
                _cajaCobro = null;
                Recalcula();
                return;
            }

            try
            {
                var r01 = Sistema.MyData.cjPago_GetCajaPagoById(id);
                _gMetodo.setFicha(id);
                _cajaCobro= r01.Entidad;
                Recalcula();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void setMontoCobrar(decimal monto)
        {
            _montoCobrar = monto;
            Recalcula();
        }


        private bool CargarData()
        {
            try
            {
                var _lst = new List<hlp.ficha>();
                var r01 = Sistema.MyData.cjPago_Lista();
                foreach (var rg in r01.Lista)
                {
                    var nr = new hlp.ficha()
                    {
                        id = rg.cod_caja,
                        desc = rg.descrip,
                    };
                    _lst.Add(nr);
                }
                _gMetodo.setData(_lst);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void Recalcula()
        {
            _tasaCalcular = _tasaCambio;
            if (_cajaCobro != null)
            {
                if (_cajaCobro.co_mone.Trim().ToUpper() == "BSS")
                {
                    _tasaCalcular = 1;
                }
            }
            _total = _montoCobrar * _tasaCalcular;
        }

    }

}