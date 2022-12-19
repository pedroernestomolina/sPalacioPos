using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta.SerieProceso
{
    
    public interface ISerieProc: hlp.IGestion, hlp.IAbandonar
    {
        BindingSource GetSource { get; }
        bool SeleccionaOpcionIsOk { get; }
        void SeleccionarOpcion();

        bool SerieProcesarIsOk { get; }
        OOB.Venta.SerieProceso SerieSeleccion { get;  }
    }

}