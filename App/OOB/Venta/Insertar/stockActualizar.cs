using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.OOB.Venta.Insertar
{
    
    public class stockActualizar
    {
        public string codAlm { get; set; }
        public string codArt { get; set; }
        public string  codUnd { get; set; }
        public decimal cnt { get; set; }
        public string tipoStock { get; set; }
        public bool sumarStock { get; set; }
        public bool permiteStockNegativo { get; set; }
    }

}