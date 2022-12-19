using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    
    public partial class ServImpContrato: IServContrato
    {

        public DTO.ResultadoLista<DTO.Articulo.BusquedaArticuloUnidad> 
            art_ListaArticulos(string codBuscar, DTO.Articulo.Enumerados.enumTipoBusqueda modoBusq)
        {
            return ServiceProv.art_BusquedaArticuloUnidad(codBuscar, modoBusq);
        }
        public DTO.ResultadoEntidad<DTO.Articulo.ObtenerArticulo> 
            art_GetArticuloById(string codArt)
        {
            return ServiceProv.art_GetArticuloById(codArt);
        }
        public DTO.ResultadoEntidad<decimal> 
            art_GetPrecioArt(string codArt, DateTime fecha, string codPrecio, string codAlmacen, string coddMonedaBase, bool conIva, string codUnidad)
        {
            return ServiceProv.art_ObtenerPrecioxArtAlma(codArt, fecha, codPrecio, codAlmacen, coddMonedaBase, conIva, codUnidad);
        }
        public DTO.ResultadoLista<DTO.Articulo.SeleccionarUnidadArticulo> 
            art_SeleccionarUnidadArticulo(string codArt)
        {
            return ServiceProv.art_pSeleccionarUnidadArticulo (codArt);
        }
        public DTO.ResultadoEntidad<DTO.Articulo.ObtenerUltimoCosto> 
            art_pObtenerUltimoCosto(Guid art, string codAlm, DateTime fecha)
        {
            return ServiceProv.art_pObtenerUltimoCosto(art, codAlm, fecha);
        }

    }

}