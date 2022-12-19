using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.OOB
{

    public class Usuario
    {
        public string CodUsuario { get; set; }
        public string DescUsuario { get; set; }
        public decimal Prioridad { get; set; }
        public string IdGrupo { get; set; }
        public Boolean CambSucu { get; set; }
        public Boolean PideSucu { get; set; }
        public string Sucursal { get; set; }
        public string Estado { get; set; }
        public string CodEmpresaAdmi { get; set; }
        public Boolean SelEmpresaAdmi { get; set; }
        public string CoMapaAdmi { get; set; }
        public Boolean AccesoTodasEmpresaAdmi { get; set; }
        public DateTime FecProx { get; set; }
        public DateTime FecUlt { get; set; }
        public DateTime FecUltFA { get; set; }
    }

}