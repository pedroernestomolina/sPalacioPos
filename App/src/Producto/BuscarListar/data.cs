using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Producto.BuscarListar
{
    
    public class data
    {

        private bool _precioAct;


        public string codPrd { get; set; }
        public string desPrd { get; set; }
        public decimal precioBs { get; set; }
        public decimal precioUs { get; set; }
        public bool PrecioIsActivo { get { return _precioAct; } }


        public void setPrecioBs(decimal prec, decimal tasaCambio)
        {
            _precioAct = true;
            precioBs = prec;
            if (tasaCambio >0)
            {
                precioUs = prec / tasaCambio;
            }
        }

    }
}