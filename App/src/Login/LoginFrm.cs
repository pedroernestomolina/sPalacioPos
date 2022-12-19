using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Login
{

    public partial class LoginFrm : Form
    {

        private ILogin _controlador;


        public LoginFrm()
        {
            InitializeComponent();
        }


        public void setControlador(ILogin ctr)
        {
            _controlador = ctr;
        }


        private void LoginFrm_Load(object sender, EventArgs e)
        {
            TB_CODIGO.Text = "";
            TB_CLAVE.Text = "";
            TB_CODIGO.Focus();
        }
        private void LoginFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.LoginIsOk || _controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }


        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            _controlador.setCodigoUsu(TB_CODIGO.Text.Trim());
        }
        private void TB_CLAVE_Leave(object sender, EventArgs e)
        {
            _controlador.setPswUsu(TB_CLAVE.Text.Trim());
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private void Aceptar()
        {
            _controlador.VerificarUsuario();
            if (_controlador.LoginIsOk)
            {
                Salir();
            }
        }
        private void Abandonar()
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