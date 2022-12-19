using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Venta.Insertar
{
    
    public class docVentaAgregar
    {
        public string co_tipo_doc { get; set; }
        public string co_cli { get; set; }
        public string co_ven { get; set; }
        public string co_mone { get; set; }
        public decimal tasa { get; set; }
        public string observa { get; set; }
        public bool contrib { get; set; }
        public string doc_orig { get; set; }
        public int tipo_orig { get; set; }
        public decimal saldo { get; set; }
        public decimal total_bruto { get; set; }
        public decimal total_neto { get; set; }
        public decimal monto_imp { get; set; }
        public string tipo_imp { get; set; }
        public decimal porc_imp { get; set; }
        public decimal porc_imp2 { get; set; }
        public decimal porc_imp3 { get; set; }
        public string co_us_in { get; set; }
        public string co_sucu_in { get; set; }
        //
        public string ImpFiscalSerial { get; set; }
        public string ImpFiscalDocumento { get; set; }
        public string ImpFiscalZ { get; set; }
    }

}