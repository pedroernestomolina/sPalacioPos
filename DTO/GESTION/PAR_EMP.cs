using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.GESTION
{
 
    public class PAR_EMP
    {
        public string cod_emp { get; set; }
        public string g_moneda{ get; set; }
        public string v_tip_cli { get; set; }
        public string v_co_ven { get; set; }
        public string v_cond_pago { get; set; }
        public string i_moneda_articulo{ get; set; }
        public bool v_maneja_sucursales { get; set; }
    }

}