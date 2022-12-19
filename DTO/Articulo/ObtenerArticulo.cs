using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Articulo
{
    
    public class ObtenerArticulo
    {
        public string co_art { get; set; }
        public DateTime fecha_reg { get; set; }
        public string art_des { get; set; }
        public string tipo { get; set; }
        public bool anulado { get; set; }
        public DateTime? fecha_inac { get; set; }
        public string co_lin { get; set; }
        public string co_subl { get; set; }
        public string co_cat { get; set; }
        public string co_color { get; set; }
        public string co_ubicacion { get; set; }
        public string cod_proc { get; set; }
        public string item { get; set; }
        public string modelo { get; set; }
        public string r_f { get; set; }
        public bool generico { get; set; }
        public bool maneja_serial { get; set; }
        public bool maneja_lote { get; set; }
        public bool maneja_lote_venc { get; set; }
        public decimal margen_min { get; set; }
        public decimal margen_max { get; set; }
        public string tipo_imp { get; set; }
        public string tipo_imp2 { get; set; }
        public string tipo_imp3 { get; set; }
        public string co_reten { get; set; }
        public string garantia { get; set; }
        public decimal volumen { get; set; }
        public decimal peso{ get; set; }
        public decimal stock_min { get; set; }
        public decimal stock_max { get; set; }
        public decimal stock_pedido { get; set; }
        public int relac_unidad { get; set; }
        public decimal punt_ven { get; set; }
        public decimal punt_clie { get; set; }
        public decimal lic_mon_ilc { get; set; }
        public decimal lic_capacidad { get; set; }
        public decimal lic_grado_al { get; set; }
        public string lic_tipo { get; set; }
        public bool precio_om { get; set; }
        public string comentario { get; set; }
        public string tipo_cos { get; set; }
        public decimal porc_margen_minimo { get; set; }
        public decimal porc_margen_maximo { get; set; }
        public decimal mont_comi { get; set; }
        public decimal porc_arancel { get; set; }
        public string co_uni { get; set; }
        public bool uni_principal { get; set; }
        public string des_uni { get; set; } 
        public bool relacion { get; set; }
        public decimal equivalencia { get; set; }
        public bool uso_principal { get; set; }
        public Guid rowguid { get; set; }
    }

}