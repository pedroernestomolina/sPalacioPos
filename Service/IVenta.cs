using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    
    public interface IVenta
    {

        DTO.ResultadoEntidad<string>
            vta_ObtenerUltimoDocPedidoByCodCli(string codCli);
        DTO.ResultadoEntidad<DTO.Venta.Pedido>
            vta_ObtenerPedido(string codDoc);
        DTO.ResultadoLista<DTO.Venta.PedidoDetalle>
            vta_ObtenerPedidoRenglones(string codDoc);
        DTO.ResultadoLista<DTO.Venta.SerieProceso>
            vta_ObtenerSerieProceso(string codConsecutivo, string coSuc, string codEmp);
        DTO.Resultado
            vta_pValidarClienteProcesoVenta(string codCli);
        DTO.ResultadoEntidad<DTO.Venta.Insertar.regInsertResult>
            vta_Insertar(DTO.Venta.Insertar.FichaAgregar ficha);

    }

}