using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Cliente
{
    
    public class Ficha
    {
        public string co_cli { get; set; }
        public string tip_cli { get; set; }
        public string cli_des { get; set; }
        public string direc1 { get; set; }
        public string direc2 { get; set; }
        public string telefonos { get; set; }
        public string fax { get; set; }
        public bool inactivo { get; set; }
        public string comentario { get; set; }
        public string respons { get; set; }
        public DateTime fecha_reg { get; set; }
        public int puntaje { get; set; }
        public decimal mont_cre { get; set; }
        public string co_mone { get; set; }
        public string cond_pag { get; set; }
        public int plaz_pag { get; set; }
        public decimal desc_ppago { get; set; }
        public string co_zon { get; set; }
        public string co_seg { get; set; }
        public string co_ven { get; set; }
        public decimal desc_glob { get; set; }
        public string horar_caja { get; set; }
        public string frecu_vist { get; set; }
        public bool lunes { get; set; }
        public bool martes { get; set; }
        public bool miercoles { get; set; }
        public bool jueves { get; set; }
        public bool viernes { get; set; }
        public bool sabado { get; set; }
        public bool domingo { get; set; }
        public string dir_ent2 { get; set; }
        public string rif { get; set; }
        public bool contrib { get; set; }
        public string nit { get; set; }
        public string email { get; set; }
        public string co_cta_ing_egr { get; set; }
        public bool juridico { get; set; }
        public int tipo_adi { get; set; }
        public string matriz { get; set; }
        public string co_tab { get; set; }
        public string tipo_per { get; set; }
        public string serialp { get; set; }
        public bool valido { get; set; }
        public string estado { get; set; }
        public int id { get; set; }
        public string co_pais { get; set; }
        public string ciudad { get; set; }
        public string zip { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string website { get; set; }
        public string salestax { get; set; }
        public bool sincredito { get; set; }
        public bool contribu_e { get; set; }
        public decimal porc_esp { get; set; }
        public string co_precio { get; set; }
        public bool ven_inactivo { get; set; }
    }

}