using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contrato
{

    public interface IProfit
    {

        DTO.ResultadoEntidad<DateTime>
            Test_2();

        DTO.ResultadoEntidad<DTO.GESTION.PAR_EMP>
            SeleccionarParametrosEmpresa(string codEmpresa);


        DTO.ResultadoLista<DTO.GESTION.SucursalLista>
            Get_Sucursales();
        DTO.ResultadoEntidad<DTO.GESTION.Sucursal>
            Get_SucursalById(string codSuc);

    }

}