using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.OOB.Venta.Insertar
{
    
    public class medioCobroAgregar
    {
        public decimal monto { get; set; }
        public string coCajaDestino { get; set; }
        public string formaPago { get; set; }
        public string tipoSaldo { get; set; }
        public string coCtaIngreso { get; set; }
        public decimal tasaCambio { get; set; } //1 si es bs 
        public string coUsuario { get; set; }
        public string coSucursal { get; set; }
    }

}