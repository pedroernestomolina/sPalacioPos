using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta.Cliente.Solicitar
{

    public partial class SolicitarFrm : Form
    {

        private ISolicitar _controlador;

        
        public SolicitarFrm()
        {
            InitializeComponent();
        }


        public void setControlador(ISolicitar ctr)
        {
            _controlador = ctr;
        }


        private void SolicitarFrm_Load(object sender, EventArgs e)
        {
            TB_SOLICITAR.Text = _controlador.GetClienteSolcitar;
            TB_SOLICITAR.SelectAll();
            TB_SOLICITAR.Focus();
        }
        private void SolicitarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.AceptarProcesarIsOk)
            {
                e.Cancel = false;
            }
        }


        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            TB_SOLICITAR.Focus();
            AceptarSolicitud();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            TB_SOLICITAR.Focus();
            AbandonarFicha();
        }


        private void TB_SOLICITAR_Leave(object sender, EventArgs e)
        {
            _controlador.setClienteBuscar(TB_SOLICITAR.Text.Trim());
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void AceptarSolicitud()
        {
            _controlador.AceptarProcesar();
            if (_controlador.AceptarProcesarIsOk)
            {
                Salir();
            }
        }
        private void AbandonarFicha()
        {
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

    }

}