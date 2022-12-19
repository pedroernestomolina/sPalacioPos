using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Articulo
{
    
    public class SeleccionarUnidadArticulo
    {
        public string co_art { get; set; }
        public string co_uni { get; set; }
        public bool relacion { get; set; }
        public decimal equivalencia { get; set; }
        public bool uso_venta { get; set; }
        public bool uso_compra { get; set; }
        public bool uni_principal { get; set; }
        public bool uni_secundaria { get; set; }
        public bool uso_numDecimales { get; set; }
        public int num_decimales { get; set; }
        public Guid rowguid { get; set; }
        public string Des_Uni { get; set; }
    }

}
