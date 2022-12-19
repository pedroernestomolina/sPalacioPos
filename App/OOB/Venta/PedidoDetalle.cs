using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.OOB.Venta
{
    
    public class PedidoDetalle
    {
        public int reng_num { get; set; }
        public string doc_num { get; set; }
        public string co_art { get; set; }
        public string des_art { get; set; }
        public string co_alma { get; set; }
        public decimal total_art { get; set; }
        public decimal stotal_art { get; set; }
        public string co_uni { get; set; }
        public string sco_uni { get; set; }
        public string co_precio { get; set; }
        public decimal prec_vta { get; set; }
        public decimal? prec_vta_om { get; set; }
        public decimal? porc_desc { get; set; }
        public decimal? monto_desc { get; set; }
        public string tipo_imp { get; set; }
        public string tipo_imp2 { get; set; }
        public string tipo_imp3 { get; set; }
        public decimal porc_imp { get; set; }
        public decimal porc_imp2 { get; set; }
        public decimal porc_imp3 { get; set; }
        public decimal monto_imp { get; set; }
        public decimal monto_imp2 { get; set; }
        public decimal monto_imp3 { get; set; }
        public decimal reng_neto { get; set; }
        public decimal pendiente { get; set; }
        public decimal pendiente2 { get; set; }
        public bool lote_asignado { get; set; }
        public string tipo_doc { get; set; }
        public string num_doc { get; set; }
        public decimal monto_desc_glob { get; set; }
        public decimal monto_reca_glob { get; set; }
        public decimal otros1_glob { get; set; }
        public decimal otros2_glob { get; set; }
        public decimal otros3_glob { get; set; }
        public decimal monto_imp_afec_glob { get; set; }
        public decimal monto_imp2_afec_glob { get; set; }
        public decimal monto_imp3_afec_glob { get; set; }
        public decimal total_dev { get; set; }
        public decimal monto_dev { get; set; }
        public decimal otros { get; set; }
        public decimal tasa { get; set; }
        public string art_des { get; set; }
        public string modelo { get; set; }
        public int relac_unidad { get; set; }
        public string co_lin { get; set; }
        public string co_cat { get; set; }
        public bool maneja_lote { get; set; }
        public bool maneja_lote_venc { get; set; }
        public bool maneja_serial { get; set; }
        public string tipo_imp_art { get; set; }
        public Guid rowguid { get; set; }
        public Guid? rowguid_doc { get; set; }
        public Guid rowguid_articulo { get; set; }
        public bool esPesado { get { return co_uni.Trim().ToUpper() == "KG"; } }
    }

}