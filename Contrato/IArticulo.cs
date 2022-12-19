using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contrato
{
    
    public interface IArticulo
    {

        DTO.ResultadoLista<DTO.Articulo.BusquedaArticuloUnidad>
            art_BusquedaArticuloUnidad(string codBuscar, DTO.Articulo.Enumerados.enumTipoBusqueda modoBusq);
        DTO.ResultadoEntidad<DTO.Articulo.ObtenerArticulo>
            art_GetArticuloById(string codArt);
        DTO.ResultadoEntidad<decimal>
            art_ObtenerPrecioxArtAlma(string codArt, DateTime fecha, string codPrecio, string codAlmacen, string coddMonedaBase, bool conIva, string codUnidad);
        DTO.ResultadoLista<DTO.Articulo.SeleccionarUnidadArticulo>
            art_pSeleccionarUnidadArticulo(string codArt);
        DTO.ResultadoEntidad<DTO.Articulo.ObtenerUltimoCosto>
            art_pObtenerUltimoCosto(Guid art, string codAlm, DateTime fecha);
        DTO.ResultadoEntidad<decimal>
            art_pStockActualizar(string codAlm, string codArt, string codUnd, decimal cnt, string tipoStock, bool sumarStock, bool permiteStockNegativo);
        DTO.ResultadoEntidad<DTO.Articulo.StockPendienteActualizar>
            art_pStockPendienteActualizar(Guid renglonDoc, decimal cnt, string tipoDoc);

    }

}