using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{
    
    public interface ICajaPago
    {
        OOB.ResultadoLista<OOB.Sistema.CajaPago.Ficha>
            cjPago_Lista();
        OOB.ResultadoEntidad<OOB.Sistema.CajaPago.Ficha>
            cjPago_GetCajaPagoById(string codCjaPago);
    }

}