using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Producto.Buscar
{
    
    abstract public class baseBuscar: IBuscar
    {

        protected IListaPrd _listaPrd;


        public BindingSource GetData_Source { get { return _listaPrd.GetSource; } }
        public int GetCntItems { get { return _listaPrd.GetCtnItems; } }
        public data ItemActual { get { return (data)_listaPrd.ItemActual; } }


        abstract public void Inicializa();
        abstract public void Inicia();


        private string _cadenaBus;
        public void setCadenaBus(string cad)
        {
            _cadenaBus = cad;
        }
        public void Buscar()
        {
            if (_cadenaBus.Trim() == "") { return; }
            try
            {
                var r01 = Sistema.MyData.art_ObtenerLista(_cadenaBus, OOB.Articulo.Enumerados.enumTipoBusqueda.PorCodigo);
                _listaPrd.setLista(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void LimpiarBusqueda()
        {
            _listaPrd.LimpiarLista();
            _cadenaBus = "";
        }

    }

}