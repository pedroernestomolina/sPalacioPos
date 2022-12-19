using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{
    
    public interface ISistema: ICajaPago
    {

        OOB.ResultadoEntidad<OOB.Sistema.Vendedor.Ficha>
            sist_vend_ObtenerFicha(string codVen);
        OOB.ResultadoEntidad<OOB.Sistema.CondPago.Ficha>
            sist_condPago_ObtenerFicha(string codCond);
        OOB.ResultadoEntidad<OOB.Sistema.Transporte.Ficha>
            sist_transporte_ObtenerFicha(string codTrans);
        OOB.ResultadoEntidad<OOB.Sistema.Moneda.Ficha>
            sist_moneda_ObtenerFicha(string codMone);
        OOB.ResultadoEntidad<decimal>
            sist_TasaCambio_ObtenerFicha(string codMoneda, DateTime fecha);

    }

}