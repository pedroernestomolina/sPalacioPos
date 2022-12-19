using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.src.Venta.FormaPago.Agregar
{
    public partial class AgregarFrm : Form
    {

        private IAgregar _controlador;


        public AgregarFrm()
        {
            InitializeComponent();
            InicializaCombo();
        }

        private void InicializaCombo()
        {
            CB_MEDIO_PAGO.DisplayMember = "desc";
            CB_MEDIO_PAGO.ValueMember = "id";
        }

        public void setControlador(IAgregar ctr)
        {
            _controlador = ctr;
        }

        private bool _modoInicializa;
        private void AgregarFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            //L_MONTO_PEND.Text = _controlador.GetMontoPend.ToString("n2");
            L_MONTO_PEND.Text = _controlador.GetMontoPendStr;
            CB_MEDIO_PAGO.DataSource = _controlador.GetMedioPago_Source;
            CB_MEDIO_PAGO.SelectedValue= _controlador.GetMedioPago_Id;
            TB_MONTO.Text = _controlador.GetMonto.ToString();
            TB_MONTO.Enabled = false;
            _modoInicializa = false;
            ActualizarTotal();
        }
        private void AgregarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AceptarProcesarIsOk || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }


        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            AceptarMetodo();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void CB_MEDIO_PAGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializa) { return; }

            _controlador.setMetodoPago("");
            if (CB_MEDIO_PAGO.SelectedIndex != -1)
            {
                _controlador.setMetodoPago(CB_MEDIO_PAGO.SelectedValue.ToString());
                TB_MONTO.Enabled = true;
                if (!_controlador.GetMedioPago_IsDivisa)
                {
                    TB_MONTO.Text = Math.Round(_controlador.GetMontoPend, 2, MidpointRounding.AwayFromZero).ToString();
                }
                else 
                {
                    TB_MONTO.Text = "0";
                }
                TB_MONTO.SelectAll();
                TB_MONTO.Focus();
            }
            ActualizarTotal();
        }
        private void TB_MONTO_Leave(object sender, EventArgs e)
        {
            var _monto= decimal.Parse(TB_MONTO.Text);
            _controlador.setMontoCobrar(_monto);
            ActualizarTotal();
        }


        private void AceptarMetodo()
        {
            CB_MEDIO_PAGO.Focus();
            _controlador.AceptarProcesar();
            if (_controlador.AceptarProcesarIsOk) 
            {
                Salir();
            }
        }
        private void AbandonarFicha()
        {
            CB_MEDIO_PAGO.Focus();
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarIsOk)
            {
                Salir();
            }
        }
        private void Salir()
        {
            this.Close();
        }
        private void ActualizarTotal()
        {
            L_TASA_CALCULO.Text = _controlador.GetTasaCalculo.ToString("n2");
            L_TOTAL.Text = _controlador.GetTotal.ToString("n2");
        }

    }

}
