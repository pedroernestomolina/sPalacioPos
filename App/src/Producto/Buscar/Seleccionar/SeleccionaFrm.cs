using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Producto.Buscar.Seleccionar
{

    public partial class SeleccionaFrm : Form
    {

        private ISelecciona _controlador;


        public SeleccionaFrm()
        {
            InitializeComponent();
            InicializarGrid_1();
        }
        private void InicializarGrid_1()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            var f2 = new Font("Serif", 10, FontStyle.Bold);

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
            c1.DataPropertyName = "CodPrd";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.Width = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DesPrd";
            c2.HeaderText = "Descripción";
            c2.Visible = true;
            c2.MinimumWidth = 200;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
        }


        public void setControlador(ISelecciona ctr)
        {
            _controlador = ctr;
        }


        private bool _modoInicializar;
        private BindingSource _bs;
        private void BuscarListarFrm_Load(object sender, EventArgs e)
        {
            _modoInicializar = true;
            DGV.DataSource = _controlador.GetData_Source;
            DGV.Refresh();
            _modoInicializar = false;
            TB_CADENA.Focus();
            Actualizar();
        }
        private void BuscarListarFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                TB_CADENA.Focus();
            }
        }


        private void Actualizar()
        {
            TB_CADENA.Focus();
            TB_CADENA.Text = "";
            L_ITEMS.Text = "Items Encontrados: " + _controlador.GetCntItems.ToString();
        }


        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            TB_CADENA.Focus();
            Buscar();
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarBusqueda();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }


        private void TB_CADENA_Leave(object sender, EventArgs e)
        {
            _controlador.setCadenaBus(TB_CADENA.Text.Trim());
        }
        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void DGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1) 
            {
                //ItemSeleccionado();
            }
        }
        private void DGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                TB_CADENA.Focus();
                ItemSeleccionado();
            }
        }


        private void Buscar()
        {
            _controlador.Buscar();
            Actualizar();
        }
        private void ItemSeleccionado()
        {
            _controlador.ItemSeleccionado();
            if (_controlador.ItemSeleccionadoIsOk)
            {
                Salir();
            }
        }
        private void LimpiarBusqueda()
        {
            _controlador.LimpiarBusqueda();
            Actualizar();
            DGV.Refresh();
        }
        private void Salir()
        {
            TB_CADENA.Focus();
            this.Close();
        }

    }

}