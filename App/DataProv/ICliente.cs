using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{
    
    public interface ICliente
    {

        OOB.ResultadoEntidad<OOB.Cliente.Ficha>
            cli_ObtenerFichaById(string _idTarjeta);

    }

}
