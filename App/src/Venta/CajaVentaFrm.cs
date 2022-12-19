using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta
{

    public partial class CajaVentaFrm : Form
    {

        private ICajaVenta _controlador;


        public CajaVentaFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }
        private void InicializarGrid()
        {
            var f = new Font("Serif", 9, FontStyle.Bold);
            var f1 = new Font("Serif",9, FontStyle.Regular);

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
            c1.DataPropertyName = "Renglon";
            c1.HeaderText = "Reng";
            c1.Visible = true;
            c1.Width = 60;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Articulo";
            c2.HeaderText = "Articulo";
            c2.Visible = true;
            c2.MinimumWidth = 160;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Unidad";
            c3.HeaderText = "Unidad";
            c3.Visible = true;
            c3.Width = 60;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "CantidadStr";
            c4.HeaderText = "Cant";
            c4.Visible = true;
            c4.Width = 60;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Format = "n3";
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Precio";
            c5.HeaderText = "Precio";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Format = "n2";
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Iva";
            c6.HeaderText = "Iva";
            c6.Visible = true;
            c6.Width= 60;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Importe";
            c7.HeaderText = "Importe";
            c7.Visible = true;
            c7.Width = 90;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
        }


        private bool _modoInicializar; 
        private void CajaVentaFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            DGV.DataSource = _controlador.GetData_Source;
            DGV.Refresh();
            L_VER.Text = _controlador.GetVersion;
            _modoInicializar = false;

            ActualizarTotales();
       }
        private void CajaVentaFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarIsOk)
            {
                e.Cancel = false;
            }
        }


        private void ActualizarTotales()
        {
            L_TARJETA_ID_TIPO.Text = _controlador.GetTarjeta_ID_TIPO;
            L_SUBTOTAL.Text = _controlador.GetSubTotalMonto.ToString("n2");
            L_IVA.Text = _controlador.GetIvaMonto.ToString("n2");
            L_TOTAL.Text = _controlador.GetTotalMonto.ToString("n2");
            L_TOTAL_DIVISA.Text = _controlador.GetTotalDivisaMonto.ToString("n2");
            L_TASA_CAMBIO_ACTUAL.Text = _controlador.GetTasaCambioActual.ToString("n6");
            //
            L_DOC_FECHA_EMISION.Text = _controlador.GetDoc_FechaEmision.ToShortDateString();
            L_DOC_RIF_CLIENTE.Text = _controlador.GetDoc_RifCliente;
            L_DOC_NOMBRE_CLIENTE.Text = _controlador.GetDoc_NombreCliente;
            L_DOC_VENDEDOR.Text = _controlador.GetDoc_Vendedor;
            L_DOC_COND_PAGO.Text = _controlador.GetDoc_CondPago;
            L_DOC_TRANSPORTE.Text = _controlador.GetDoc_Transporte;
        }


        public void setControlador(ICajaVenta ctr)
        {
            _controlador = ctr;
        }


        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void TB_TARJETA_Leave(object sender, EventArgs e)
        {
            _controlador.setTarjeta(TB_TARJETA.Text);
        }


        private void BT_BUSCAR_TARJETA_Click(object sender, EventArgs e)
        {
            BuscarTarjeta();
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            PedirTarjetaNueva();
        }
        private void BT_CONSULTA_Click(object sender, EventArgs e)
        {
            ConsultarPrecioArticulo();
        }
        private void BT_FACTURAR_Click(object sender, EventArgs e)
        {
            Facturar();
        }
        private void BT_SUMAR_Click(object sender, EventArgs e)
        {
            TB_TARJETA.Focus();
            AgregarArticulo();
        }
        private void BT_RESTAR_Click(object sender, EventArgs e)
        {
            TB_TARJETA.Focus();
            EliminarArticulo();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            TB_TARJETA.Focus();
            AbandonarProceso();
        }
        private void BT_CLIENTE_Click(object sender, EventArgs e)
        {
            TB_TARJETA.Focus();
            BuscarCliente();
        }
        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            TB_TARJETA.Focus();
            EditarItem();
        }

        
        private void BuscarTarjeta()
        {
            _controlador.BuscarTarjeta();
            if (_controlador.BuscarTarjetaIsOk) 
            {
                P_TARJETA.Enabled = false;
            }
            RefrescarVista();
        }
        private void PedirTarjetaNueva()
        {
            _controlador.PedirTarjetaNueva();
            if (_controlador.PedirTarjetaNuevaIsOk) 
            {
                P_TARJETA.Enabled = true;
            }
            RefrescarVista();
        }
        private void AgregarArticulo()
        {
            _controlador.AgregarArticulo();
            if (_controlador.AgregarArticuloIsOk)
            {
                RefrescarVista();
            }
        }
        private void EliminarArticulo()
        {
            _controlador.EliminarArticulo();
            if (_controlador.EliminarArticuloIsOk)
            {
                RefrescarVista();
            }
        }
        private void ConsultarPrecioArticulo()
        {
            _controlador.ConsultarPrecioArticulo();
            RefrescarVista();
        }
        private void BuscarCliente()
        {
            _controlador.BuscarCliente();
            if (_controlador.BuscarClienteIsOk || _controlador.BuscarTarjetaIsOk)
            {
                if (_controlador.BuscarTarjetaIsOk)
                {
                    P_TARJETA.Enabled = false;
                }
                RefrescarVista();
            }
        }
        private void EditarItem()
        {
            _controlador.EditarItem();
            if (_controlador.EditarItemIsOk)
            {
                RefrescarVista();
            }
        }
        private void Facturar()
        {
            TB_TARJETA.Focus();
            _controlador.Facturar();
            if (_controlador.FacturarIsOk)
            {
                _controlador.TarjetaNueva();
                if (_controlador.PedirTarjetaNuevaIsOk)
                {
                    this.Activate();
                    P_TARJETA.Enabled = true;
                }
            }
            RefrescarVista();
        }
        private void AbandonarProceso()
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

        void RefrescarVista()
        {
            var _tid = _controlador.GetTarjeta_ID;
            if (_tid == "00") { _tid = ""; }
            DGV.Refresh();
            ActualizarTotales();
            TB_TARJETA.Text = _tid;
            TB_TARJETA.Focus();
        }

    }

}