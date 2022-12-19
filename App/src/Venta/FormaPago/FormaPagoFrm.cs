using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta.FormaPago
{

    public partial class FormaPagoFrm : Form
    {

        private ICobro _controlador;


        public FormaPagoFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }
        private void InicializarGrid()
        {
            var f = new Font("Serif", 9, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);

            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CajaPago";
            c1.HeaderText = "Descripcion";
            c1.Visible = true;
            c1.Width = 200;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Importe";
            c2.HeaderText = "Importe";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c2.DefaultCellStyle.Format = "n2";

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Cant";
            c3.HeaderText = "Cant";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c2);
        }



        private bool _modoInicializa;
        private void FormaPagoFrm_Load(object sender, EventArgs e)
        {
            _modoInicializa = true;
            DGV.DataSource = _controlador.GetData_Source;
            _modoInicializa = false; 
            ActualizarTotales();
            AgregarMetCobro();
        }
        private void FormaPagoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk || _controlador.IsOk)
            {
                e.Cancel = false;
            }
        }


        public void setControlador(ICobro ctr)
        {
            _controlador = ctr;
        }


        private void BT_AGREGAR_MET_COBRO_Click(object sender, EventArgs e)
        {
            AgregarMetCobro();
        }
        private void BT_ELIMINAR_MET_COBRO_Click(object sender, EventArgs e)
        {
            EliminarMetCobro();
        }
        private void BT_LIMPIAR_MET_COBRO_Click(object sender, EventArgs e)
        {
            LimpiarMetCobro();
        }


        private void AgregarMetCobro()
        {
            _controlador.AgregarMetCobro();
            if (_controlador.AgregarMetCobroIsOk) 
            {
                ActualizarTotales();
            }
        }
        private void EliminarMetCobro()
        {
            _controlador.EliminarMetCobro();
            ActualizarTotales();
        }
        private void LimpiarMetCobro()
        {
            _controlador.LimpiarMetCobro();
            ActualizarTotales();
        }


        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            ProcesarMetodos();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            AbandonarFicha();
        }


        private void ActualizarTotales()
        {
            L_MONTO_COBRAR.Text = "(BSS) "+_controlador.GetMontoCobrar.ToString("n2");
            L_MONTO_COBRAR_DIV.Text = "(US$) "+_controlador.GetMontoCobrarDiv.ToString("n2");
            L_MONTO_ABONADO.Text = _controlador.GetMontoAbonado.ToString("n2");
            L_MONTO_PEND_CAMBIO_DAR.Text = _controlador.GetMontoPend.ToString("n2");
            L_MONTO_PEND_CAMBIO_DAR_DIV.Text = _controlador.GetMontoPendDiv.ToString("n2");
            if (_controlador.GetCambiosVueltoIsActivo)
            {
                BT_ACEPTAR.Focus();
                P_PEND_CAMBIO.BackColor = Color.DarkBlue;
                L_RESTA_PENDIENTE.Text = "Cambio/Vuelto Dar:";
                L_MONTO_PEND_CAMBIO_DAR.Text = _controlador.GetMontoCambio.ToString("n2");
                L_MONTO_PEND_CAMBIO_DAR_DIV.Text = "0.00";
            }
            else 
            {
                P_PEND_CAMBIO.BackColor = Color.DarkRed;
                L_RESTA_PENDIENTE.Text = "Resta/Pendiente:";
            }
        }
        private void ProcesarMetodos()
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