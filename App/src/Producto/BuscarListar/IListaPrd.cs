using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Producto.BuscarListar
{
    
    public interface IListaPrd: hlp.ILista
    {

        void setLista(List<OOB.Articulo.ListaResumen> lst);

    }

}