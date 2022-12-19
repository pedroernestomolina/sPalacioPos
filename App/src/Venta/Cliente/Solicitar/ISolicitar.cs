using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Venta.Cliente.Solicitar
{
    
    public interface ISolicitar: hlp.IGestion, hlp.IAbandonar, hlp.IAceptarProcesar
    {
        string GetClienteSolcitar { get; }
        void setClienteBuscar(string ciRif);
        bool ClientSeleccionadoIsOk { get; }
        OOB.Cliente.Ficha ClientSeleccionado { get; }
    }
}
