using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.OOB.Venta.Insertar
{
    
    public class encabezadoAgregar
    {
        public string coCli { get; set; }
        public string coTran { get; set; }
        public string coMone { get; set; }
        public string coVen { get; set; }
        public string coCond { get; set; }
        public decimal tasaCambio { get; set; }
        public decimal saldo { get; set; }
        public decimal totalBruto { get; set; }
        public decimal montoImp { get; set; }
        public decimal totalNeto { get; set; }
        public bool contrib { get; set; }
        public string coUsu { get; set; }
        public string coSuc { get; set; }
    }

}