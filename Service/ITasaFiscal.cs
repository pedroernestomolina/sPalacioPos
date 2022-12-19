using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    
    public interface ITasaFiscal
    {

        DTO.ResultadoLista<DTO.TasaFiscal.Tipo>
            tasa_ObtenerTipoTasaFiscal();
        DTO.ResultadoLista<DTO.TasaFiscal.TipoValor>
            tasa_ObtenerTasaPorTipoValor(DateTime fecha);

    }

}