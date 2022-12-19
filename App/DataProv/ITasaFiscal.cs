using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{
    
    public interface ITasaFiscal
    {

        OOB.ResultadoLista<OOB.TasaFiscal.Tipo>
            tasa_ObtenerTipoTasaFiscal();
        OOB.ResultadoLista<OOB.TasaFiscal.TipoValor>
            tasa_ObtenerTasaPorTipoValor(DateTime fecha);

    }

}
