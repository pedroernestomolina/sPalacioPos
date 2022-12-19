using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta.CantSolicitar.NoPesado
{

    public partial class CantFrm : Form
    {

        private ICantSolicitar _controlador;


        public CantFrm()
        {
            InitializeComponent();
        }


        public void setControlador(ICantSolicitar ctr)
        {
            _controlador = ctr;
        }


        private void CantFrm_Load(object sender, EventArgs e)
        {
            TB_CNT.Text = _controlador.GetCntSolicitada.ToString("n0");
            TB_CNT.SelectAll();
            TB_CNT.Focus();
        }
        private void CantFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controlador.Abandonar();
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.AceptarSolicitudIsOk)
            {
                e.Cancel = false;
            }
        }


        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            TB_CNT.Focus();
            AceptarSolicitud();
        }


        private void TB_CNT_Leave(object sender, EventArgs e)
        {
            var cnt = decimal.Parse(TB_CNT.Text);
            _controlador.setCant(cnt);
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
            _controlador.AceptarSolicitud();
            if (_controlador.CantSolicitarIsOk)
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