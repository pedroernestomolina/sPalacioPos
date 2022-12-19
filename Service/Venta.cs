using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    
    public partial class ServImpContrato: IServContrato
    {

        public DTO.ResultadoEntidad<string> 
            vta_ObtenerUltimoDocPedidoByCodCli(string codCli)
        {
            return ServiceProv.vta_ObtenerUltimoDocPedidoByCodCli(codCli);
        }
        public DTO.ResultadoEntidad<DTO.Venta.Pedido> 
            vta_ObtenerPedido(string codDoc)
        {
            return ServiceProv.vta_ObtenerPedido(codDoc);
        }
        public DTO.ResultadoLista<DTO.Venta.PedidoDetalle> 
            vta_ObtenerPedidoRenglones(string codDoc)
        {
            return ServiceProv.vta_ObtenerPedidoRenglones(codDoc);
        }
        public DTO.ResultadoLista<DTO.Venta.SerieProceso> 
            vta_ObtenerSerieProceso(string codConsecutivo, string coSuc, string codEmp)
        {
            return ServiceProv.vta_ObtenerSerieProceso(codConsecutivo, coSuc, codEmp);
        }
        public DTO.Resultado 
            vta_pValidarClienteProcesoVenta(string codCli)
        {
            return ServiceProv.vta_pValidarClienteProcesoVenta(codCli); 
        }
        public DTO.ResultadoEntidad<DTO.Venta.Insertar.regInsertResult>
            vta_Insertar(DTO.Venta.Insertar.FichaAgregar ficha)
        {
            var r01 = ServiceProv.vta_pValidarClienteProcesoVenta(ficha.encabezado.coCli);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                var rt = new DTO.ResultadoEntidad<DTO.Venta.Insertar.regInsertResult>
                {
                    Mensaje = r01.Mensaje,
                    Result = DTO.Enumerados.EnumResult.isError,
                };
                return rt;
            }
            return ServiceProv.vta_Insertar(ficha);
        }

    }

}