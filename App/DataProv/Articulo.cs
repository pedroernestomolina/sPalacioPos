using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{

    public partial class ImpDataProv: IDataProv
    {
        public OOB.ResultadoLista<OOB.Articulo.ListaResumen>
            art_ObtenerLista(string codBuscar, OOB.Articulo.Enumerados.enumTipoBusqueda modoBusqued)
        {
            var rt = new OOB.ResultadoLista<OOB.Articulo.ListaResumen>();
            var r01 = ServiceProv.art_ListaArticulos(codBuscar, (DTO.Articulo.Enumerados.enumTipoBusqueda)modoBusqued);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.Articulo.ListaResumen>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Articulo.ListaResumen()
                        {
                            anulado = s.anulado,
                            art_des = s.art_des,
                            co_art = s.co_art,
                            tipo = s.tipo,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;
            return rt;
        }
        public OOB.ResultadoEntidad<decimal>
            art_ObtenerPrecio(string codArt, DateTime fecha, string codPrecio, string codAlmacen, string coddMonedaBase, bool conIva, string codUnidad)
        {
            var rt = new OOB.ResultadoEntidad<decimal>();
            var r01 = ServiceProv.art_GetPrecioArt(codArt, fecha, codPrecio, codAlmacen, coddMonedaBase, conIva, codUnidad);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            rt.Entidad = r01.Entidad;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.Articulo.Ficha>
            art_ObtenerFichaById(string codArt)
        {
            var rt = new OOB.ResultadoEntidad<OOB.Articulo.Ficha>();
            var r01 = ServiceProv.art_GetArticuloById(codArt);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            if (r01.Entidad != null)
            {
                var s = r01.Entidad;
                rt.Entidad = new OOB.Articulo.Ficha()
                {
                    anulado = s.anulado,
                    art_des = s.art_des,
                    co_art = s.co_art,
                    co_cat = s.co_cat,
                    co_color = s.co_color,
                    co_lin = s.co_lin,
                    co_reten = s.co_reten,
                    co_subl = s.co_subl,
                    co_ubicacion = s.co_ubicacion,
                    co_uni = s.co_uni,
                    cod_proc = s.cod_proc,
                    comentario = s.comentario,
                    des_uni = s.des_uni,
                    equivalencia = s.equivalencia,
                    fecha_inac = s.fecha_inac,
                    fecha_reg = s.fecha_reg,
                    garantia = s.garantia,
                    generico = s.generico,
                    item = s.item,
                    lic_capacidad = s.lic_capacidad,
                    lic_grado_al = s.lic_grado_al,
                    lic_mon_ilc = s.lic_mon_ilc,
                    lic_tipo = s.lic_tipo,
                    maneja_lote = s.maneja_lote,
                    maneja_lote_venc = s.maneja_lote_venc,
                    maneja_serial = s.maneja_serial,
                    margen_max = s.margen_max,
                    margen_min = s.margen_min,
                    modelo = s.modelo,
                    mont_comi = s.mont_comi,
                    peso = s.peso,
                    porc_arancel = s.porc_arancel,
                    porc_margen_minimo = s.porc_margen_minimo,
                    precio_om = s.precio_om,
                    punt_clie = s.punt_clie,
                    punt_ven = s.punt_ven,
                    r_f = s.r_f,
                    relac_unidad = s.relac_unidad,
                    relacion = s.relacion,
                    stock_max = s.stock_max,
                    stock_min = s.stock_min,
                    stock_pedido = s.stock_pedido,
                    tipo = s.tipo,
                    tipo_cos = s.tipo_cos,
                    tipo_imp = s.tipo_imp,
                    uni_principal = s.uni_principal,
                    uso_principal = s.uso_principal,
                    volumen = s.volumen,
                    //
                    porc_margen_maximo = s.porc_margen_maximo,
                    rowguid = s.rowguid,
                    tipo_imp2 = s.tipo_imp2,
                    tipo_imp3 = s.tipo_imp3,
                };
            }
            return rt;
        }
        public OOB.ResultadoLista<OOB.Articulo.SeleccionarUnidadArticulo> 
            art_SeleccionarUnidadArticulo(string codArt)
        {
            var rt = new OOB.ResultadoLista<OOB.Articulo.SeleccionarUnidadArticulo>();
            var r01 = ServiceProv.art_SeleccionarUnidadArticulo(codArt);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.Articulo.SeleccionarUnidadArticulo>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Articulo.SeleccionarUnidadArticulo()
                        {
                            co_art = s.co_art,
                            co_uni = s.co_uni,
                            Des_Uni = s.Des_Uni,
                            equivalencia = s.equivalencia,
                            num_decimales = s.num_decimales,
                            relacion = s.relacion,
                            rowguid = s.rowguid,
                            uni_principal = s.uni_principal,
                            uni_secundaria = s.uni_secundaria,
                            uso_compra = s.uso_compra,
                            uso_numDecimales = s.uso_numDecimales,
                            uso_venta = s.uso_venta,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;
            return rt;
        }
    }

}