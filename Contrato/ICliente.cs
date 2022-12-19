using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contrato
{
    
    public interface ICliente
    {

        DTO.ResultadoEntidad<DTO.Cliente.Ficha>
            cli_ObtenerFicha(string codCli);

    }

}
