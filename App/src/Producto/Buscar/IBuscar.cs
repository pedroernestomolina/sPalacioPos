using App.src.hlp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Producto.Buscar
{
    
    public interface IBuscar: IGestion
    {

        BindingSource GetData_Source { get; }
        int GetCntItems { get; }

        void setCadenaBus(string cad);
        void Buscar();
        void LimpiarBusqueda();

    }

}