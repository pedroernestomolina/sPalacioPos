using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.MASTER
{
    
    public class EstatusUsuario
    {
        public DateTime Fec_Prox { get; set; }
        public DateTime Fec_Ult { get; set; }
        public int Veces { get; set; }
        public DateTime Fec_Ult_FA {get;set;}
        public string Estado { get; set; }
        public DateTime fechaServidor { get; set; }
        public string Ad_Login { get; set; }
    }

}