using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contrato
{
    
    public interface IProvider: IMaster, IProfit, IVenta, ICliente, ITasa, ISistema, IArticulo
    {
        DTO.ResultadoEntidad<DateTime>
           Get_FechaServidor();
    }

}