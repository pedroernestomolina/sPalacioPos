using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.src.Principal
{

    public partial class PrincipalFrm : Form
    {

        private IPrincipal _controlador;


        public PrincipalFrm()
        {
            InitializeComponent();
        }

        public void setControlador(IPrincipal ctr)
        {
            _controlador = ctr;
        }


        private void PrincipalFrm_Load(object sender, EventArgs e)
        {
        }
        private void PrincipalFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk) 
            {
                e.Cancel = false;
            }
        }


        private void BT_BUSCAR_PRD_Click(object sender, EventArgs e)
        {
            BuscarProductos();
        }
        private void BT_CARGAR_CUENTA_Click(object sender, EventArgs e)
        {
            CargarCuenta();
        }
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void BuscarProductos()
        {
            _controlador.BuscarProductos();
        }
        private void CargarCuenta()
        {
            _controlador.CargarCuenta();
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