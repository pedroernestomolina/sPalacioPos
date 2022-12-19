using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Venta.Insertar
{
    
    public class docCobroAgregar
    {
        public cobroAgregar docCobro { get; set; }
        public List<medioCobro> mediosCobro { get; set; }
        // PARA EL MOV DE AJUSTE
        public decimal CambioVuelto { get; set; }
        public bool ActivarAjustePorCambioVuelto { get; set; }
    }

}