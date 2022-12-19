using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta
{
    
    public class ImpCajaItem: ICajaItem
    {

        private List<dataItem> _lst;
        private BindingSource _bs;
        private BindingList<dataItem> _bl;


        public ImpCajaItem()
        {
            _lst = new List<dataItem>();
            _bl = new BindingList<dataItem>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public BindingSource GetSource { get { return _bs; } }
        public int GetCtnItems { get { return _bs.Count; } }
        public IEnumerable<object> GetListaItems { get { return _bl.ToList(); } }
        public object ItemActual { get { return _bs.Current; } }


        public void Inicializa()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }
        public void LimpiarLista()
        {
        }
        public void setData(List<dataItem> list)
        {
            _bl.Clear();
            foreach(var rg in list)
            {
                _bl.Add(rg);
            }
            _bs.CurrencyManager.Refresh();
        }

    }

}