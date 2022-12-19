using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Venta.SerieProceso
{
    
    public class data
    {

        private OOB.Venta.SerieProceso rg;


        public string id { get { return rg.co_consecutivo; } }
        public string descripcion { get { return rg.Consecutivo; } }
        public string serie { get { return rg.Serie; } }
        public OOB.Venta.SerieProceso Item { get { return this.rg; } }


        public data(OOB.Venta.SerieProceso rg)
        {
            this.rg = rg;
        }


    }

}