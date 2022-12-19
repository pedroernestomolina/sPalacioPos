using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contrato
{
    
    public interface ISistema: ICajaPago
    {

        DTO.ResultadoEntidad<DTO.Sistema.Vendedor.Ficha>
            sist_vend_ObtenerFicha(string codVen);
        DTO.ResultadoEntidad<DTO.Sistema.CondPago.Ficha>
            sist_condPago_ObtenerFicha(string codCond);
        DTO.ResultadoEntidad<DTO.Sistema.Transporte.Ficha>
            sist_transporte_ObtenerFicha(string codTrans);
        DTO.ResultadoEntidad<DTO.Sistema.Moneda.Ficha>
            sist_moneda_ObtenerFicha(string codMone);
        DTO.ResultadoEntidad<DTO.Sistema.TasaCambio.ObtenerFechaTasa>
            sist_ObtenerFechaTasa(string codMoneda, DateTime fecha); //RETORNA TABLA CON TASA CAMBIO ACTUAL 

    }

}