using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.OOB.Venta.Insertar
{
    
    public class docCobroAgregar
    {
        public cobroAgregar docCobro { get; set; }
        public List<medioCobroAgregar> mediosCobro { get; set; }
        //
        public bool ActivarAjustePorCambioVuelto { get; set; }
        public decimal CambioVuelto { get; set; }
    }

}