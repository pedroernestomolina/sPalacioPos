using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta.FormaPago
{
    
    public interface ICobro: hlp.IGestion, hlp.IAbandonar, hlp.IAceptarProcesar
    {
        BindingSource GetData_Source { get; }
        decimal GetMontoCobrar { get; }
        decimal GetMontoCobrarDiv { get; }
        decimal GetMontoAbonado { get; }
        decimal GetMontoPend { get; }
        decimal GetMontoPendDiv { get; }
        bool GetCambiosVueltoIsActivo { get; }
        decimal GetMontoCambio { get; }
        List<dataMedioCobro> GetDataExportar { get; }
        
        bool IsOk { get; }

        void setMontoCobrar(decimal montoCob);
        void setMontoCobrarDivisa(decimal montoCobDivisa);
        void setTasaCambio(decimal tasa);

        bool AgregarMetCobroIsOk { get; }
        void AgregarMetCobro();
        void EliminarMetCobro();
        void LimpiarMetCobro();
    }

}