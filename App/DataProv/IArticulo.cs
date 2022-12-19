using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{
    
    public interface IArticulo
    {

        OOB.ResultadoLista<OOB.Articulo.ListaResumen>
            art_ObtenerLista(string codBuscar,  OOB.Articulo.Enumerados.enumTipoBusqueda modoBusqueda);
        OOB.ResultadoEntidad<OOB.Articulo.Ficha>
            art_ObtenerFichaById(string codArt);
        OOB.ResultadoEntidad<decimal>
            art_ObtenerPrecio(string codArt, DateTime fecha, string codPrecio, string codAlmacen, string coddMonedaBase, bool conIva, string codUnidad);
        OOB.ResultadoLista<OOB.Articulo.SeleccionarUnidadArticulo>
            art_SeleccionarUnidadArticulo(string codArt);

    }

}