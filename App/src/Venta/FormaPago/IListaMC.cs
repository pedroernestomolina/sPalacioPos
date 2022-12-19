using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Venta.FormaPago
{
    
    public interface IListaMC: hlp.ILista
    {
        decimal GetTotalCobrado { get; }
        void InsertarItem(dataAgregar data);
        void EliminarItem(int id);
        void LimpiarItems();
    }

}
