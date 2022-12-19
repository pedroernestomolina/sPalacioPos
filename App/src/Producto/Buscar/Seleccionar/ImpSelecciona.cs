using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Producto.Buscar.Seleccionar
{

    public class ImpSelecciona: baseBuscar, ISelecciona
    {

        public ImpSelecciona()
        {
            _listaPrd = new ImpListaPrd();
        }


        public override void Inicializa()
        {
            _idItemSeleccionado = "";
            _itemSeleccionadoIsOk = false;
            _listaPrd.Inicializa();
        }
        SeleccionaFrm frm;
        public override void Inicia()
        {
            if (frm == null)
            {
                frm = new SeleccionaFrm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }


        private bool _itemSeleccionadoIsOk;
        private string _idItemSeleccionado;
        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionadoIsOk; } }
        public bool SeleccionIsOk { get { return _itemSeleccionadoIsOk; } }
        public string GetIdItemSeleccionado { get { return _idItemSeleccionado; } }
        public void ItemSeleccionado()
        {
            if (ItemActual != null)
            {
                _itemSeleccionadoIsOk = true;
                _idItemSeleccionado = ItemActual.codPrd;
            }
        }
    }

}