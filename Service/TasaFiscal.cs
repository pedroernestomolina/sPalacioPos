using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    
    public partial class ServImpContrato: IServContrato
    {
        
        public DTO.ResultadoLista<DTO.TasaFiscal.Tipo> 
            tasa_ObtenerTipoTasaFiscal()
        {
            return ServiceProv.tasa_ObtenerTipoTasaFiscal();
        }
        public DTO.ResultadoLista<DTO.TasaFiscal.TipoValor> 
            tasa_ObtenerTasaPorTipoValor(DateTime fecha)
        {
            return ServiceProv.tasa_ObtenerTasaPorTipoValor(fecha);
        }

    }

}