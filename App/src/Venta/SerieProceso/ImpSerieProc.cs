using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta.SerieProceso
{
    
    public class ImpSerieProc: ISerieProc, hlp.ILista
    {

        private List<data> _lst;
        private OOB.Venta.SerieProceso _serieSeleccionada; 
        private BindingSource _bs;


        public ImpSerieProc()
        {
            _abandonarIsOk=false;
            _seleccionaOpcionIsOk = false;
            _lst = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
            _serieSeleccionada = null;
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _seleccionaOpcionIsOk = false;
            _lst.Clear();
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
            _serieSeleccionada = null;
        }
        private SerieFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new SerieFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _seleccionaOpcionIsOk = false;
            _abandonarIsOk= Helpers.Msg.Abandonar("Salir Sin Seleccionar Ficha ? ");
        }

        public BindingSource GetSource { get { return _bs; } }
        public int GetCtnItems { get { return _bs.Count; } }
        public IEnumerable<object> GetListaItems { get { return _lst; } }
        public object ItemActual { get { return _bs.Current; } }
        public void LimpiarLista()
        {
        }


        private bool CargarData()
        {
            try
            {
                var _codConsecutivo = "DOC_VEN_FACT";
                var _codSuc = Sistema.MyConfiguracion.codSucursal;
                var _codEmp = Sistema.MyConfiguracion.codEmpresa;
                var lst= Sistema.MyData.vta_ObtenerSerieProceso(_codConsecutivo, _codSuc, _codEmp);
                setData(lst.Lista);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void setData(List<OOB.Venta.SerieProceso> list)
        {
            _lst.Clear();
            foreach (var rg in list)
            {
                var nr = new data(rg);
                _lst.Add(nr);
            }
            _bs.DataSource = _lst;
            _bs.CurrencyManager.Refresh();
        }


        private bool _seleccionaOpcionIsOk;
        public bool SeleccionaOpcionIsOk { get { return _seleccionaOpcionIsOk; } }
        public bool SerieProcesarIsOk { get { return _seleccionaOpcionIsOk; } }
        public OOB.Venta.SerieProceso SerieSeleccion { get { return _serieSeleccionada; } }
        public void SeleccionarOpcion()
        {
            _seleccionaOpcionIsOk = false;
            if (ItemActual != null)
            {
                var it= (data)ItemActual;
                var msg = "Seleccionar Ficha ?";
                var r = MessageBox.Show(msg, "** ALERTA **", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (r == DialogResult.Yes)
                {
                    _seleccionaOpcionIsOk = true;
                    _serieSeleccionada = _lst.Find(f => f.id == it.id).Item;
                }
            }
        }
    }

}