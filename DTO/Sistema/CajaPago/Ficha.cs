using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Sistema.CajaPago
{
    
    public class Ficha
    {
        public string cod_caja { get; set; }
        public string descrip { get; set; }
        public string co_mone { get; set; }
        public bool inactivo { get; set; }
        public Guid rowguid { get; set; }
    }

}
