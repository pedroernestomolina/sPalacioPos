using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Producto.BuscarListar
{
    
    public class ListaPrd: IListaPrd
    {

        private List<data> _lst;
        private BindingSource _bs;
        private BindingList<data> _bl;


        public BindingSource GetSource { get { return _bs; } }
        public int GetCtnItems { get { return _bs.Count; } }
        public object ItemActual { get { return _bs.Current; } }
        public IEnumerable<object> GetListaItems { get { return _bl.ToList(); } }


        public ListaPrd()
        {
            _lst = new List<data>();
            _bs = new BindingSource();
            _bl = new BindingList<data>(_lst);
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _bl.Clear();
            _bs.DataSource = _bl;
        }


        public void setLista(List<OOB.Articulo.ListaResumen> lst)
        {
            _bl.Clear();
            foreach (var rg in lst)
            {
                var nr = new data()
                {
                    codPrd = rg.co_art.Trim(),
                    desPrd = rg.art_des.Trim(),
                };
                _bl.Add(nr);
            }
            _bs.CurrencyManager.Refresh();
        }
        public void LimpiarLista()
        {
            setLimpiar();
        }


        private void setLimpiar()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }

    }

}