using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Venta
{
    
    public class dataItem
    {
        public int Renglon { get; set; }
        public string Articulo { get; set; }
        public string Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public decimal TasaIva { get; set; }
        public string Iva { get { return TasaIva > 0 ? TasaIva.ToString("n2") + "%" : "Ex"; } }
        public bool esPesado { get; set; }
        public string CantidadStr 
        {
            get 
            {
                var _cnt = "";
                _cnt = esPesado ? Cantidad.ToString("n3") : Cantidad.ToString("n0");
                return _cnt;
            } 
        }
    }

}