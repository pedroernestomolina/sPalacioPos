using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Articulo
{
    
    public class ObtenerUltimoCosto
    {
        public Guid cod_costo_historico_entrada { get; set; }
        public Guid cod_articulo_rowguid { get; set; }
        public string cod_almacen { get; set; }
        public decimal costo { get; set; }
    }

}