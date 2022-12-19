using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.OOB.Venta
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
        public bool anulado { get; set; }
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
        public int plaz_pag { get; set; }
        public decimal desc_glob { get; set; }
        public string tip_cli { get; set; }


        public void ActualizarSaldo(decimal montoNeto, decimal montoImp)
        {
            total_bruto = montoNeto;
            monto_imp = montoImp;
            total_neto = montoNeto + montoImp;
            saldo = montoNeto + montoImp;
        }

        public void ValoresPorDefecto(string _codCli, string _codVend, string _codCondPag, string _codtrans, string _codMone, DateTime _fechaServ, decimal _tasaDiv, string _tipoCli)
        {
            this.doc_num = "";
            this.descrip = "";
            this.co_cli = _codCli;
            this.co_ven = _codVend;
            this.co_cond = _codCondPag;
            this.co_tran=_codtrans;
            this.co_mone = _codMone;
            this.anulado = false;
            this.fec_emis = _fechaServ;
            this.fec_venc = _fechaServ;
            this.fec_reg = _fechaServ;
            this.anulado = false;
            this.status = "1";
            this.n_control = "";
            this.ven_ter = false;
            this.tasa = _tasaDiv;
            this.porc_desc_glob = 0m;
            this.monto_desc_glob = 0m;
            this.porc_reca = 0m;
            this.monto_reca = 0m;
            this.total_bruto = 0m;
            this.monto_imp = 0m;
            this.monto_im2 = 0m;
            this.monto_im3 = 0m;
            this.otros1 = 0m;
            this.otros2 = 0m;
            this.otros3 = 0m;
            this.total_neto = 0m;
            this.saldo = 0m;
            this.contrib = true;
            this.impresa = false;
            this.dir_ent2 = "";
            this.plaz_pag = 0;
            this.desc_glob = 0m;
            this.tip_cli = _tipoCli;
        }

    }

}