using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.SeleccionarEmpresaSucursal
{
    
    public interface ISelEmpresaSuc: hlp.IGestion, hlp.IAbandonar
    {
        bool SelEmpresaSucIsOk { get; }
        BindingSource GetEmpresa_Source { get; }
        BindingSource GetSucursal_Source { get; }
        string GetEmpresa_ID { get; }
        string GetSucursal_ID { get; }
        void setEmpresa(string id);
        void setSucursal(string id);
        void AceptarDatos();
        bool AcepTarDatosIsOk { get; }

        bool GetEmpresa_Habilitar { get; }
        bool GetSucursal_Habilitar { get; }
    }

}
