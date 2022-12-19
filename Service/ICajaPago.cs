using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{

    public interface ICajaPago
    {
        DTO.ResultadoLista<DTO.Sistema.CajaPago.Lista>
            cjPago_Lista();
        DTO.ResultadoEntidad<DTO.Sistema.CajaPago.Ficha>
            cjPago_GetCajaPagoById(string codCjaPago);
    }

}