using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{
    
    public interface IVenta
    {
        OOB.ResultadoEntidad<string>
            vta_ObtenerUltimoDocPedidoByCodCli(string codCli);
        OOB.ResultadoEntidad<OOB.Venta.Pedido>
            vta_ObtenerPedido(string codDoc);
        OOB.ResultadoLista<OOB.Venta.PedidoDetalle>
            vta_ObtenerPedidoRenglones(string codDoc);
        OOB.ResultadoLista<OOB.Venta.SerieProceso>
            vta_ObtenerSerieProceso(string codConsecutivo, string coSuc, string codEmp);
        OOB.ResultadoEntidad<OOB.Venta.Insertar.regInsertResult>
            vta_Insertar(OOB.Venta.Insertar.FichaAgregar ficha);
    }

}