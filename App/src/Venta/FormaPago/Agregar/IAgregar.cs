using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta.FormaPago.Agregar
{
    
    public interface IAgregar: hlp.IGestion, hlp.IAbandonar, hlp.IAceptarProcesar
    {

        decimal GetMontoPend { get; }
        string GetMedioPago_Id { get; }
        BindingSource GetMedioPago_Source { get; }
        decimal  GetTasaCalculo { get; }
        decimal GetTotal { get; }
        decimal GetMonto { get; }
        dataAgregar GetDataExportar { get; }
        bool GetMedioPago_IsDivisa { get; }
        string GetMontoPendStr { get; }

        void setMontoPendiente(decimal monto);
        void setTasaCambio(decimal monto);
        void setMetodoPago(string id);
        void setMontoCobrar(decimal monto);
        void setMontoPendienteDivisa(decimal _montoPend);
    }

}