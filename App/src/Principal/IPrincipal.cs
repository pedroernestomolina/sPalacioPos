using App.src.hlp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Principal
{
    
    public interface IPrincipal: IGestion, IAbandonar
    {
        void BuscarProductos();
        void CargarCuenta();
    }

}
