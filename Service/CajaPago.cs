using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{

    public partial class ServImpContrato: IServContrato
    {
        public DTO.ResultadoLista<DTO.Sistema.CajaPago.Lista> 
            cjPago_Lista()
        {
            return ServiceProv.cjPago_Lista();
        }
        public DTO.ResultadoEntidad<DTO.Sistema.CajaPago.Ficha> 
            cjPago_GetCajaPagoById(string codCjaPago)
        {
            return ServiceProv.cjPago_GetCajaPagoById(codCjaPago);
        }
    }

}