using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Venta.FormaPago
{
    
    public class dataMedioCobro
    {
        public int id { get; set; }
        public dataAgregar data { get; set; }
        public string CajaPago { get { return data.cajaCobro.descrip; } }
        public decimal Importe { get { return data.total; } }
        public string Cant 
        { 
            get 
            {
                if (data.cajaCobro.co_mone.Trim().ToUpper() == "US$")
                {
                    return ((int)data.montoCobrar).ToString();
                }
                else
                {
                    return "";
                }
            } 
        }
    }

}