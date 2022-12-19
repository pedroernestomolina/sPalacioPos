using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.hlp
{
    
    public interface ILista
    {
        BindingSource GetSource { get; }
        int GetCtnItems { get; }
        IEnumerable<object> GetListaItems { get; }
        object ItemActual { get; }


        void Inicializa();
        void LimpiarLista();
    }

}