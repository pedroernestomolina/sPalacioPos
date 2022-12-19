using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    
    public interface IArticulo
    {

        DTO.ResultadoLista<DTO.Articulo.BusquedaArticuloUnidad>
            art_ListaArticulos(string codBuscar, DTO.Articulo.Enumerados.enumTipoBusqueda modoBusq);
        DTO.ResultadoEntidad<DTO.Articulo.ObtenerArticulo>
            art_GetArticuloById(string codArt);
        DTO.ResultadoEntidad<decimal>
            art_GetPrecioArt(string codArt, DateTime fecha, string codPrecio, string codAlmacen, string coddMonedaBase, bool conIva, string codUnidad);
        DTO.ResultadoLista<DTO.Articulo.SeleccionarUnidadArticulo>
            art_SeleccionarUnidadArticulo(string codArt);
        DTO.ResultadoEntidad<DTO.Articulo.ObtenerUltimoCosto>
            art_pObtenerUltimoCosto(Guid art, string codAlm, DateTime fecha);

    }

}