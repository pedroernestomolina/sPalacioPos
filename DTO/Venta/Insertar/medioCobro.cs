using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Venta.Insertar
{
    
    public class medioCobro
    {
        public decimal monto { get; set; } 
        public string coCajaDestino { get; set; }
        public string formaPago { get; set; }
        public string tipoSaldo { get; set; }
        public string coCtaIngreso { get; set; }
        public decimal tasaCambio { get; set; } //1 si es bs 
        public string coUsuario { get; set; }
        public string coSucursal { get; set; }
        //
        public string movCajaGeneradoPorSist { get; set; }
    }

}