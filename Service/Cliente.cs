using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{

    public partial class ServImpContrato: IServContrato
    {

        public DTO.ResultadoEntidad<DTO.Cliente.Ficha> 
            cli_ObtenerFicha(string codCli)
        {
            return ServiceProv.cli_ObtenerFicha(codCli);
        }

    }

}