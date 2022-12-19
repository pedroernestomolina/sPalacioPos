using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.MASTER
{

    public class EstatusFechaServidor
    {
        public DateTime FechaServidor { get; set; }
        public string mensaje { get; set; }
        public bool vencimiento { get; set; }
        public int Nro_intentos { get; set; }
        public int Lapso { get; set; }
        public int Dias_inact { get; set; }
        public bool Inactividad { get; set; }
        public int espera { get; set; }
    }

}