using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.SeleccionarEmpresaSucursal
{

    public partial class SelEmpSucFrm : Form
    {

        private ISelEmpresaSuc _controlador;


        public SelEmpSucFrm()
        {
            InitializeComponent();
            InicializaComobs();
        }
        private void InicializaComobs()
        {
            CB_EMPRESA.DisplayMember = "c";
            CB_EMPRESA.ValueMember= "id";
            CB_SUCURSAL.DisplayMember = "Desc";
            CB_SUCURSAL.ValueMember = "id";
        }


        private bool _modoInicializar;
        private void SelEmpSucFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            CB_EMPRESA.DataSource = _controlador.GetEmpresa_Source;
            CB_SUCURSAL.DataSource = _controlador.GetSucursal_Source;
            CB_EMPRESA.SelectedValue = _controlador.GetEmpresa_ID;
            CB_SUCURSAL.SelectedValue = _controlador.GetSucursal_ID;
            CB_EMPRESA.Enabled = _controlador.GetEmpresa_Habilitar;
            CB_SUCURSAL.Enabled = _controlador.GetSucursal_Habilitar;
            _modoInicializar = false;
        }
        private void SelEmpSucFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.AcepTarDatosIsOk)
            {
                e.Cancel = false;
            }
        }


        public void setControlador(ISelEmpresaSuc ctr)
        {
            _controlador = ctr;
        }


        private void CB_EMPRESA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setEmpresa("");
            if (CB_EMPRESA.SelectedIndex != -1) 
            {
                _controlador.setEmpresa(CB_EMPRESA.SelectedValue.ToString());
            }
        }
        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar) { return; }
            _controlador.setSucursal("");
            if (CB_SUCURSAL.SelectedIndex != -1) 
            {
                _controlador.setSucursal(CB_SUCURSAL.SelectedValue.ToString());
            }
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }
        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }


        private void Aceptar()
        {
            _controlador.AceptarDatos();
            if (_controlador.AcepTarDatosIsOk)
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