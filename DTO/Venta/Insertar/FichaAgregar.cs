using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Venta.Insertar
{
    
    public class FichaAgregar
    {
        public string nroDocPedido { get; set; }
        public string coSerieControl { get; set; }
        public string coSerieDocumento { get; set; }
        public string NombreEquipo { get; set; }
        public List<stockActualizar> stockAct { get; set; }
        public List<stockPendActualizar> stockPendAct { get; set; }
        public encabezadoAgregar encabezado { get; set; }
        public List<cuerpoAgregar> cuerpo { get; set; }
        public docVentaAgregar docVenta { get; set; }
        public docCobroAgregar docCobro { get; set; }
    }

}
