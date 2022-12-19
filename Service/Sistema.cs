using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    
    public partial class ServImpContrato: IServContrato
    {

        public DTO.ResultadoEntidad<DTO.Sistema.Vendedor.Ficha>
            sist_vend_ObtenerFicha(string codVen)
        {
            return ServiceProv.sist_vend_ObtenerFicha(codVen);
        }
        public DTO.ResultadoEntidad<DTO.Sistema.CondPago.Ficha> 
            sist_condPago_ObtenerFicha(string codCond)
        {
            return ServiceProv.sist_condPago_ObtenerFicha(codCond);
        }
        public DTO.ResultadoEntidad<DTO.Sistema.Transporte.Ficha> 
            sist_transporte_ObtenerFicha(string codTrans)
        {
            return ServiceProv.sist_transporte_ObtenerFicha(codTrans);
        }
        public DTO.ResultadoEntidad<DTO.Sistema.Moneda.Ficha> 
            sist_moneda_ObtenerFicha(string codMone)
        {
            return ServiceProv.sist_moneda_ObtenerFicha (codMone);
        }
        public DTO.ResultadoEntidad<DTO.Sistema.TasaCambio.ObtenerFechaTasa> 
            sist_ObtenerTasaCambio(string codMoneda, DateTime fecha)
        {
            return ServiceProv.sist_ObtenerFechaTasa(codMoneda, fecha);
        }

    }

}