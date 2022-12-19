using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.OOB.Sistema.Vendedor
{
    
    public class Ficha
    {
        public string co_ven { get; set; }
        public string tipo { get; set; }
        public string ven_des { get; set; }
        public string cedula { get; set; }
        public string direc1 { get; set; }
        public string direc2 { get; set; }
        public string telefonos { get; set; }
        public DateTime fecha_reg { get; set; }
        public bool inactivo { get; set; }
        public string comentario { get; set; }
        public decimal comision { get; set; }
        public bool fun_cob { get; set; }
        public bool fun_ven { get; set; }
        public decimal comissionv { get; set; }
        public string co_zon { get; set; }
    }

}