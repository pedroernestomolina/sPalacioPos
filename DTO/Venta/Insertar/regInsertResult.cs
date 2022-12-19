using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Venta.Insertar
{
    public class regInsertResult
    {
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public string docNumeroFact { get; set; }
        public string docNumeroPed { get; set; }
    }
}
