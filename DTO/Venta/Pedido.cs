using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Venta
{
    
    public class Pedido
    {
        public string doc_num { get; set; }
        public string descrip { get; set; }
        public string co_cli { get; set; }
        public string co_tran { get; set; }
        public string co_mone { get; set; }
        public string co_ven { get; set; }
        public string co_cond { get; set; }
        public DateTime fec_emis { get; set; }
        public DateTime fec_venc { get; set; }
        public DateTime fec_reg { get; set; }
        public bool anulado {get; set; }
        public string status { get; set; }
        public string n_control { get; set; }
        public bool ven_ter { get; set; }
        public decimal tasa { get; set; }
        public decimal? porc_desc_glob { get; set; }
        public decimal monto_desc_glob { get; set; }
        public decimal? porc_reca { get; set; }
        public decimal monto_reca { get; set; }
        public decimal total_bruto { get; set; }
        public decimal monto_imp { get; set; }
        public decimal monto_im2 { get; set; }
        public decimal monto_im3 { get; set; }
        public decimal otros1 { get; set; }
        public decimal otros2 { get; set; }
        public decimal otros3 { get; set; }
        public decimal total_neto { get; set; }
        public decimal saldo { get; set; }
        public bool contrib { get; set; }
        public bool impresa { get; set; }
        public bool sincredito { get; set; }
        public string dir_ent2 { get; set; }
        public int plaz_pag{ get; set; }
        public decimal desc_glob { get; set; }
        public string tip_cli { get; set; }
    }

}