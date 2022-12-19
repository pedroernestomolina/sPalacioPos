using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Producto.Buscar.Seleccionar
{
    
    public interface ISelecciona: IBuscar
    {
        bool SeleccionIsOk { get; }
        void ItemSeleccionado();
        bool ItemSeleccionadoIsOk { get; }
        string GetIdItemSeleccionado { get; }
    }

}