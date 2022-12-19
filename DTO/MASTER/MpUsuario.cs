using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.MASTER
{
    
    public class MpUsuario
    {
        public string Cod_Usuario { get; set; }
        public string Desc_Usuario { get; set; }
        public decimal Prioridad { get; set; }
        public string Id_Grupo { get; set; }
        public Boolean Camb_Sucu { get; set; }
        public Boolean Pide_Sucu { get; set; }
        public string Sucursal { get; set; }
        public string Estado { get; set; }
        public string Cod_Empresa_Admi { get; set; }
        public Boolean Sel_Emp_Admi { get; set; }
        public string co_mapa_admi { get; set; }
        public Boolean Acceso_Todas_Empresa_Admi { get; set; }
        public DateTime Fec_Prox { get; set; }
        public DateTime Fec_Ult { get; set; }
        public DateTime Fec_Ult_FA { get; set; }
    }

}
