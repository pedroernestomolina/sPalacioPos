using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Venta.Insertar
{
    
    public class regDocVentaResult
    {
        public byte[] validador { get; set; }
        public DateTime fe_us_in { get; set; }
        public DateTime fe_us_mo { get; set; }
        public Guid rowguid { get; set; }
    }

}