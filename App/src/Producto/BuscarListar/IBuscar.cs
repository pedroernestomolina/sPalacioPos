using App.src.hlp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Producto.BuscarListar
{
    
    public interface IBuscar: IGestion
    {

        BindingSource GetData_Source { get; }
        int GetCntItems { get; }

        void setCadenaBus(string cad);
        void Buscar();
        void VerPrecio();
        void LimpiarBusqueda();

        string GetTipoBusqueda_Id { get; }
        BindingSource GetTipoBusqueda_Source { get; }
        void setTipoBusqueda(string id);
        void ProcesarArticulo();
        bool ProcesarItemIsOk { get; }
        string GetItemProcesar_Id { get; }
    }

}
