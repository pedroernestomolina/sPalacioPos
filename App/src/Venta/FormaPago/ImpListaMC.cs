using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta.FormaPago
{
    
    public class ImpListaMC:IListaMC
    {

        private List<dataMedioCobro> _lst;
        private BindingList<dataMedioCobro> _bl;
        private BindingSource _bs;


        public decimal GetTotalCobrado { get { return _bl.Sum(s => s.data.total); } }


        public ImpListaMC()
        {
            _lst= new List<dataMedioCobro>();
            _bl = new BindingList<dataMedioCobro>(_lst);
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
        }
        public void LimpiarLista()
        {
        }


        public void InsertarItem(dataAgregar xdata)
        {
            var nr = new dataMedioCobro()
            {
                data = xdata,
                id = 1,
            };
            if (_bl.Count > 0)
            {
                var id = _bl.Max(m => m.id)+1;
                nr.id = id;
            }
            _bl.Add(nr);
        }
        public void EliminarItem(int id)
        {
            var it = _bl.FirstOrDefault(f => f.id == id);
            if (it != null)
            {
                _bl.Remove(it);
            }
        }
        public void LimpiarItems()
        {
            _bl.Clear();
        }
    }

}