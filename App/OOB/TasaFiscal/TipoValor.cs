using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.OOB.TasaFiscal
{
    
    public class TipoValor
    {
        public DateTime fecha { get; set; }
        public string tipo_imp { get; set; }
        public decimal porc_tasa { get; set; }
        public decimal porc_suntuario { get; set; }
    }

}