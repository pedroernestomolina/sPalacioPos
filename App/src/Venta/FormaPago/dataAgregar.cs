using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Venta.FormaPago
{
    
    public class dataAgregar
    {
        public decimal montoPend { get; set; }
        public decimal tasaCambio { get; set; }
        public decimal montoCobrar { get; set; }
        public decimal total { get; set; }
        public decimal tasaCalcular { get; set; }
        public OOB.Sistema.CajaPago.Ficha cajaCobro { get; set; }
    }

}