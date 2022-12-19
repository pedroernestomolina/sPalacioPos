using PROFIT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImpContrato
{

    public partial class Provider: Contrato.IProvider
    {

        //class hlp_1
        //{
        //    public decimal monto { get; set; }
        //    public string co_mone  { get; set; }
        //    public int precioIncluyeImpuesto { get; set; }
        //    public string  tipo_imp { get; set; }
        //    public int otraMoneda { get; set; }
        //}
        //class hlp_2 
        //{
        //    public decimal tasa_v { get; set; }
        //    public decimal tasa_c { get; set; }
        //    public int relacion { get; set; }
        //}


//        public DTO.ResultadoLista<DTO.GESTION.BusquedaArticuloUnidad>
//            Get_BusquedaArticuloUnidad(string buscar)
//        {
//            var result = new DTO.ResultadoLista<DTO.GESTION.BusquedaArticuloUnidad>();
//            try
//            {
//                using (var ctx = new pPanEntities(_gestion.ConnectionString))
//                {
//                    var p1 = new SqlParameter("@buscar", "");
//                    var cod = buscar.Trim();
//                    if (cod.Length > 0)
//                    {
//                        if (cod.Substring(0, 1) == "*")
//                        {
//                            cod = cod.Substring(1).Trim();
//                            if (cod.Length > 0)
//                            {
//                                p1.Value = "%" + cod + "%";
//                            }
//                            else
//                            {
//                                p1.Value = "";
//                            }
//                        }
//                        else
//                        {
//                            p1.Value = cod + "%";
//                        }
//                    }
//                    var sql = @"SELECT 
//                                    [Extent1].[co_art] AS [co_art], 
//                                    [Extent1].[fecha_reg] AS [fecha_reg], 
//                                    [Extent1].[art_des] AS [art_des], 
//                                    [Extent1].[tipo] AS [tipo], 
//                                    [Extent1].[anulado] AS [anulado], 
//                                    [Extent1].[fecha_inac] AS [fecha_inac], 
//                                    [Extent1].[co_lin] AS [co_lin], 
//                                    [Extent1].[co_subl] AS [co_subl], 
//                                    [Extent1].[co_cat] AS [co_cat], 
//                                    [Extent1].[co_color] AS [co_color], 
//                                    [Extent1].[co_ubicacion] AS [co_ubicacion], 
//                                    [Extent1].[cod_proc] AS [cod_proc], 
//                                    [Extent1].[item] AS [item], 
//                                    [Extent1].[modelo] AS [modelo], 
//                                    [Extent1].[ref] AS [ref], 
//                                    [Extent1].[generico] AS [generico], 
//                                    [Extent1].[maneja_serial] AS [maneja_serial], 
//                                    [Extent1].[maneja_lote] AS [maneja_lote], 
//                                    [Extent1].[maneja_lote_venc] AS [maneja_lote_venc], 
//                                    [Extent1].[margen_min] AS [margen_min], 
//                                    [Extent1].[margen_max] AS [margen_max], 
//                                    [Extent1].[tipo_imp] AS [tipo_imp], 
//                                    [Extent1].[co_reten] AS [co_reten], 
//                                    [Extent1].[garantia] AS [garantia], 
//                                    [Extent1].[volumen] AS [volumen], 
//                                    [Extent1].[peso] AS [peso], 
//                                    [Extent1].[stock_min] AS [stock_min], 
//                                    [Extent1].[stock_max] AS [stock_max], 
//                                    [Extent1].[stock_pedido] AS [stock_pedido], 
//                                    [Extent1].[relac_unidad] AS [relac_unidad], 
//                                    [Extent1].[punt_ven] AS [punt_ven], 
//                                    [Extent1].[punt_cli] AS [punt_cli], 
//                                    [Extent1].[lic_mon_ilc] AS [lic_mon_ilc], 
//                                    [Extent1].[lic_capacidad] AS [lic_capacidad], 
//                                    [Extent1].[lic_grado_al] AS [lic_grado_al], 
//                                    [Extent1].[lic_tipo] AS [lic_tipo], 
//                                    [Extent1].[prec_om] AS [prec_om], 
//                                    [Extent1].[comentario] AS [comentario], 
//                                    [Extent1].[tipo_cos] AS [tipo_cos], 
//                                    [Extent1].[porc_margen_minimo] AS [porc_margen_minimo], 
//                                    [Extent1].[mont_comi] AS [mont_comi], 
//                                    [Extent1].[porc_arancel] AS [porc_arancel], 
//                                    [Extent1].[dis_cen] AS [dis_cen], 
//                                    [Extent1].[campo1] AS [campo1], 
//                                    [Extent1].[campo2] AS [campo2], 
//                                    [Extent1].[campo3] AS [campo3], 
//                                    [Extent1].[campo4] AS [campo4], 
//                                    [Extent1].[campo5] AS [campo5], 
//                                    [Extent1].[campo6] AS [campo6], 
//                                    [Extent1].[campo7] AS [campo7], 
//                                    [Extent1].[campo8] AS [campo8], 
//                                    [Extent1].[co_us_in] AS [co_us_in], 
//                                    [Extent1].[co_sucu_in] AS [co_sucu_in], 
//                                    [Extent1].[fe_us_in] AS [fe_us_in], 
//                                    [Extent1].[co_us_mo] AS [co_us_mo], 
//                                    [Extent1].[co_sucu_mo] AS [co_sucu_mo], 
//                                    [Extent1].[fe_us_mo] AS [fe_us_mo], 
//                                    [Extent1].[revisado] AS [revisado], 
//                                    [Extent1].[trasnfe] AS [trasnfe], 
//                                    [Extent1].[validador] AS [validador], 
//                                    [Extent1].[rowguid] AS [rowguid], 
//                                    [Extent1].[co_uni] AS [co_uni], 
//                                    [Extent1].[uni_principal] AS [uni_principal], 
//                                    [Extent1].[des_uni] AS [des_uni], 
//                                    [Extent1].[relacion] AS [relacion], 
//                                    [Extent1].[equivalencia] AS [equivalencia], 
//                                    [Extent1].[uso_principal] AS [uso_principal]
//                                FROM (SELECT 
//                                            [v_saArticulo_saArtUnidad].[co_art] AS [co_art], 
//                                            [v_saArticulo_saArtUnidad].[fecha_reg] AS [fecha_reg], 
//                                            [v_saArticulo_saArtUnidad].[art_des] AS [art_des], 
//                                            [v_saArticulo_saArtUnidad].[tipo] AS [tipo], 
//                                            [v_saArticulo_saArtUnidad].[anulado] AS [anulado], 
//                                            [v_saArticulo_saArtUnidad].[fecha_inac] AS [fecha_inac], 
//                                            [v_saArticulo_saArtUnidad].[co_lin] AS [co_lin], 
//                                            [v_saArticulo_saArtUnidad].[co_subl] AS [co_subl], 
//                                            [v_saArticulo_saArtUnidad].[co_cat] AS [co_cat], 
//                                            [v_saArticulo_saArtUnidad].[co_color] AS [co_color], 
//                                            [v_saArticulo_saArtUnidad].[co_ubicacion] AS [co_ubicacion], 
//                                            [v_saArticulo_saArtUnidad].[cod_proc] AS [cod_proc], 
//                                            [v_saArticulo_saArtUnidad].[item] AS [item], 
//                                            [v_saArticulo_saArtUnidad].[modelo] AS [modelo], 
//                                            [v_saArticulo_saArtUnidad].[ref] AS [ref], 
//                                            [v_saArticulo_saArtUnidad].[generico] AS [generico], 
//                                            [v_saArticulo_saArtUnidad].[maneja_serial] AS [maneja_serial], 
//                                            [v_saArticulo_saArtUnidad].[maneja_lote] AS [maneja_lote], 
//                                            [v_saArticulo_saArtUnidad].[maneja_lote_venc] AS [maneja_lote_venc], 
//                                            [v_saArticulo_saArtUnidad].[margen_min] AS [margen_min], 
//                                            [v_saArticulo_saArtUnidad].[margen_max] AS [margen_max], 
//                                            [v_saArticulo_saArtUnidad].[tipo_imp] AS [tipo_imp], 
//                                            [v_saArticulo_saArtUnidad].[co_reten] AS [co_reten], 
//                                            [v_saArticulo_saArtUnidad].[garantia] AS [garantia], 
//                                            [v_saArticulo_saArtUnidad].[volumen] AS [volumen], 
//                                            [v_saArticulo_saArtUnidad].[peso] AS [peso], 
//                                            [v_saArticulo_saArtUnidad].[stock_min] AS [stock_min], 
//                                            [v_saArticulo_saArtUnidad].[stock_max] AS [stock_max], 
//                                            [v_saArticulo_saArtUnidad].[stock_pedido] AS [stock_pedido], 
//                                            [v_saArticulo_saArtUnidad].[relac_unidad] AS [relac_unidad], 
//                                            [v_saArticulo_saArtUnidad].[punt_ven] AS [punt_ven], 
//                                            [v_saArticulo_saArtUnidad].[punt_cli] AS [punt_cli], 
//                                            [v_saArticulo_saArtUnidad].[lic_mon_ilc] AS [lic_mon_ilc], 
//                                            [v_saArticulo_saArtUnidad].[lic_capacidad] AS [lic_capacidad], 
//                                            [v_saArticulo_saArtUnidad].[lic_grado_al] AS [lic_grado_al], 
//                                            [v_saArticulo_saArtUnidad].[lic_tipo] AS [lic_tipo], 
//                                            [v_saArticulo_saArtUnidad].[prec_om] AS [prec_om], 
//                                            [v_saArticulo_saArtUnidad].[comentario] AS [comentario], 
//                                            [v_saArticulo_saArtUnidad].[tipo_cos] AS [tipo_cos], 
//                                            [v_saArticulo_saArtUnidad].[porc_margen_minimo] AS [porc_margen_minimo], 
//                                            [v_saArticulo_saArtUnidad].[mont_comi] AS [mont_comi], 
//                                            [v_saArticulo_saArtUnidad].[porc_arancel] AS [porc_arancel], 
//                                            [v_saArticulo_saArtUnidad].[dis_cen] AS [dis_cen], 
//                                            [v_saArticulo_saArtUnidad].[campo1] AS [campo1], 
//                                            [v_saArticulo_saArtUnidad].[campo2] AS [campo2], 
//                                            [v_saArticulo_saArtUnidad].[campo3] AS [campo3], 
//                                            [v_saArticulo_saArtUnidad].[campo4] AS [campo4], 
//                                            [v_saArticulo_saArtUnidad].[campo5] AS [campo5], 
//                                            [v_saArticulo_saArtUnidad].[campo6] AS [campo6], 
//                                            [v_saArticulo_saArtUnidad].[campo7] AS [campo7], 
//                                            [v_saArticulo_saArtUnidad].[campo8] AS [campo8], 
//                                            [v_saArticulo_saArtUnidad].[co_us_in] AS [co_us_in], 
//                                            [v_saArticulo_saArtUnidad].[co_sucu_in] AS [co_sucu_in], 
//                                            [v_saArticulo_saArtUnidad].[fe_us_in] AS [fe_us_in], 
//                                            [v_saArticulo_saArtUnidad].[co_us_mo] AS [co_us_mo], 
//                                            [v_saArticulo_saArtUnidad].[co_sucu_mo] AS [co_sucu_mo], 
//                                            [v_saArticulo_saArtUnidad].[fe_us_mo] AS [fe_us_mo], 
//                                            [v_saArticulo_saArtUnidad].[revisado] AS [revisado], 
//                                            [v_saArticulo_saArtUnidad].[trasnfe] AS [trasnfe], 
//                                            [v_saArticulo_saArtUnidad].[validador] AS [validador], 
//                                            [v_saArticulo_saArtUnidad].[rowguid] AS [rowguid], 
//                                            [v_saArticulo_saArtUnidad].[co_uni] AS [co_uni], 
//                                            [v_saArticulo_saArtUnidad].[uni_principal] AS [uni_principal], 
//                                            [v_saArticulo_saArtUnidad].[des_uni] AS [des_uni], 
//                                            [v_saArticulo_saArtUnidad].[relacion] AS [relacion], 
//                                            [v_saArticulo_saArtUnidad].[equivalencia] AS [equivalencia], 
//                                            [v_saArticulo_saArtUnidad].[uso_principal] AS [uso_principal]
//                                        FROM [dbo].[v_saArticulo_saArtUnidad] AS [v_saArticulo_saArtUnidad]) AS [Extent1]
//                                        WHERE (([Extent1].[co_art] like @buscar)) 
//                                AND ([Extent1].[anulado] <> cast(1 as bit)) 
//                                AND ((N'S' = [Extent1].[tipo]) OR (N'V' = [Extent1].[tipo])) 
//                                AND ([Extent1].[uni_principal] = 1)
//                                ORDER BY [Extent1].[anulado] ASC, [Extent1].[art_des] ASC, 
//                                            [Extent1].[co_art] ASC, [Extent1].[co_cat] ASC, 
//                                            [Extent1].[co_color] ASC, [Extent1].[co_lin] ASC, 
//                                            [Extent1].[co_subl] ASC, [Extent1].[co_ubicacion] ASC, 
//                                            [Extent1].[co_uni] ASC, [Extent1].[co_us_in] ASC, 
//                                            [Extent1].[co_us_mo] ASC, [Extent1].[des_uni] ASC,
//                                            [Extent1].[equivalencia] ASC, [Extent1].[fecha_reg] ASC, 
//                                            [Extent1].[fe_us_in] ASC, [Extent1].[fe_us_mo] ASC, 
//                                            [Extent1].[garantia] ASC, [Extent1].[generico] ASC, 
//                                            [Extent1].[lic_capacidad] ASC, [Extent1].[lic_grado_al] ASC, 
//                                            [Extent1].[lic_mon_ilc] ASC, [Extent1].[maneja_lote] ASC, 
//                                            [Extent1].[maneja_lote_venc] ASC, [Extent1].[maneja_serial] ASC, 
//                                            [Extent1].[margen_max] ASC, [Extent1].[margen_min] ASC, 
//                                            [Extent1].[peso] ASC, [Extent1].[prec_om] ASC, 
//                                            [Extent1].[punt_cli] ASC, [Extent1].[punt_ven] ASC, 
//                                            [Extent1].[relacion] ASC, [Extent1].[relac_unidad] ASC, 
//                                            [Extent1].[rowguid] ASC, [Extent1].[stock_max] ASC, 
//                                            [Extent1].[stock_min] ASC, [Extent1].[stock_pedido] ASC, 
//                                            [Extent1].[tipo] ASC, [Extent1].[tipo_imp] ASC, 
//                                            [Extent1].[uni_principal] ASC, [Extent1].[uso_principal] ASC, 
//                                            [Extent1].[volumen] ASC";
//                    var lst = ctx.Database.SqlQuery<DTO.GESTION.BusquedaArticuloUnidad>(sql, p1).ToList();
//                    result.Lista = lst;
//                    return result;
//                }
//            }
//            catch (Exception e)
//            {
//                result.Mensaje = e.Message;
//                result.Result = DTO.Enumerados.EnumResult.isError;
//            }
//            return result;
//        }
//        public DTO.ResultadoEntidad<DTO.GESTION.ObtenerArticulo> 
//            Get_ArticuloById(string codArt)
//        {
//            var result = new DTO.ResultadoEntidad<DTO.GESTION.ObtenerArticulo>();
//            try
//            {
//                using (var ctx = new pPanEntities(_gestion.ConnectionString))
//                {
//                    var p1 = new SqlParameter("@codArt", codArt);
//                    var sql = @"SELECT 
//                                    [Extent1].[co_art] AS [co_art], 
//                                    [Extent1].[fecha_reg] AS [fecha_reg], 
//                                    [Extent1].[art_des] AS [art_des], 
//                                    [Extent1].[tipo] AS [tipo], 
//                                    [Extent1].[anulado] AS [anulado], 
//                                    [Extent1].[fecha_inac] AS [fecha_inac], 
//                                    [Extent1].[co_lin] AS [co_lin], 
//                                    [Extent1].[co_subl] AS [co_subl], 
//                                    [Extent1].[co_cat] AS [co_cat], 
//                                    [Extent1].[co_color] AS [co_color], 
//                                    [Extent1].[co_ubicacion] AS [co_ubicacion], 
//                                    [Extent1].[cod_proc] AS [cod_proc], 
//                                    [Extent1].[item] AS [item], 
//                                    [Extent1].[modelo] AS [modelo], 
//                                    [Extent1].[ref] AS [r_f], 
//                                    [Extent1].[generico] AS [generico], 
//                                    [Extent1].[maneja_serial] AS [maneja_serial], 
//                                    [Extent1].[maneja_lote] AS [maneja_lote], 
//                                    [Extent1].[maneja_lote_venc] AS [maneja_lote_venc], 
//                                    [Extent1].[margen_min] AS [margen_min], 
//                                    [Extent1].[margen_max] AS [margen_max], 
//                                    [Extent1].[tipo_imp] AS [tipo_imp], 
//                                    [Extent1].[co_reten] AS [co_reten], 
//                                    [Extent1].[garantia] AS [garantia], 
//                                    [Extent1].[volumen] AS [volumen], 
//                                    [Extent1].[peso] AS [peso], 
//                                    [Extent1].[stock_min] AS [stock_min], 
//                                    [Extent1].[stock_max] AS [stock_max], 
//                                    [Extent1].[stock_pedido] AS [stock_pedido], 
//                                    [Extent1].[relac_unidad] AS [relac_unidad], 
//                                    [Extent1].[punt_ven] AS [punt_ven], 
//                                    [Extent1].[punt_cli] AS [punt_cli], 
//                                    [Extent1].[lic_mon_ilc] AS [lic_mon_ilc], 
//                                    [Extent1].[lic_capacidad] AS [lic_capacidad], 
//                                    [Extent1].[lic_grado_al] AS [lic_grado_al], 
//                                    [Extent1].[lic_tipo] AS [lic_tipo], 
//                                    [Extent1].[prec_om] AS [prec_om], 
//                                    [Extent1].[comentario] AS [comentario], 
//                                    [Extent1].[tipo_cos] AS [tipo_cos], 
//                                    [Extent1].[porc_margen_minimo] AS [porc_margen_minimo], 
//                                    [Extent1].[mont_comi] AS [mont_comi], 
//                                    [Extent1].[porc_arancel] AS [porc_arancel], 
//                                    [Extent1].[dis_cen] AS [dis_cen], 
//                                    [Extent1].[campo1] AS [campo1], 
//                                    [Extent1].[campo2] AS [campo2], 
//                                    [Extent1].[campo3] AS [campo3], 
//                                    [Extent1].[campo4] AS [campo4], 
//                                    [Extent1].[campo5] AS [campo5], 
//                                    [Extent1].[campo6] AS [campo6], 
//                                    [Extent1].[campo7] AS [campo7], 
//                                    [Extent1].[campo8] AS [campo8], 
//                                    [Extent1].[co_us_in] AS [co_us_in], 
//                                    [Extent1].[co_sucu_in] AS [co_sucu_in], 
//                                    [Extent1].[fe_us_in] AS [fe_us_in], 
//                                    [Extent1].[co_us_mo] AS [co_us_mo], 
//                                    [Extent1].[co_sucu_mo] AS [co_sucu_mo], 
//                                    [Extent1].[fe_us_mo] AS [fe_us_mo], 
//                                    [Extent1].[revisado] AS [revisado], 
//                                    [Extent1].[trasnfe] AS [trasnfe], 
//                                    [Extent1].[validador] AS [validador], 
//                                    [Extent1].[rowguid] AS [rowguid], 
//                                    [Extent1].[co_uni] AS [co_uni], 
//                                    [Extent1].[uni_principal] AS [uni_principal], 
//                                    [Extent1].[des_uni] AS [des_uni], 
//                                    [Extent1].[relacion] AS [relacion], 
//                                    [Extent1].[equivalencia] AS [equivalencia], 
//                                    [Extent1].[uso_principal] AS [uso_principal]
//                                FROM (SELECT 
//                                        [v_saArticulo_saArtUnidad].[co_art] AS [co_art], 
//                                        [v_saArticulo_saArtUnidad].[fecha_reg] AS [fecha_reg], 
//                                        [v_saArticulo_saArtUnidad].[art_des] AS [art_des], 
//                                        [v_saArticulo_saArtUnidad].[tipo] AS [tipo], 
//                                        [v_saArticulo_saArtUnidad].[anulado] AS [anulado], 
//                                        [v_saArticulo_saArtUnidad].[fecha_inac] AS [fecha_inac], 
//                                        [v_saArticulo_saArtUnidad].[co_lin] AS [co_lin], 
//                                        [v_saArticulo_saArtUnidad].[co_subl] AS [co_subl], 
//                                        [v_saArticulo_saArtUnidad].[co_cat] AS [co_cat], 
//                                        [v_saArticulo_saArtUnidad].[co_color] AS [co_color], 
//                                        [v_saArticulo_saArtUnidad].[co_ubicacion] AS [co_ubicacion], 
//                                        [v_saArticulo_saArtUnidad].[cod_proc] AS [cod_proc], 
//                                        [v_saArticulo_saArtUnidad].[item] AS [item], 
//                                        [v_saArticulo_saArtUnidad].[modelo] AS [modelo], 
//                                        [v_saArticulo_saArtUnidad].[ref] AS [ref], 
//                                        [v_saArticulo_saArtUnidad].[generico] AS [generico], 
//                                        [v_saArticulo_saArtUnidad].[maneja_serial] AS [maneja_serial], 
//                                        [v_saArticulo_saArtUnidad].[maneja_lote] AS [maneja_lote], 
//                                        [v_saArticulo_saArtUnidad].[maneja_lote_venc] AS [maneja_lote_venc], 
//                                        [v_saArticulo_saArtUnidad].[margen_min] AS [margen_min], 
//                                        [v_saArticulo_saArtUnidad].[margen_max] AS [margen_max], 
//                                        [v_saArticulo_saArtUnidad].[tipo_imp] AS [tipo_imp], 
//                                        [v_saArticulo_saArtUnidad].[co_reten] AS [co_reten], 
//                                        [v_saArticulo_saArtUnidad].[garantia] AS [garantia], 
//                                        [v_saArticulo_saArtUnidad].[volumen] AS [volumen], 
//                                        [v_saArticulo_saArtUnidad].[peso] AS [peso], 
//                                        [v_saArticulo_saArtUnidad].[stock_min] AS [stock_min], 
//                                        [v_saArticulo_saArtUnidad].[stock_max] AS [stock_max], 
//                                        [v_saArticulo_saArtUnidad].[stock_pedido] AS [stock_pedido], 
//                                        [v_saArticulo_saArtUnidad].[relac_unidad] AS [relac_unidad], 
//                                        [v_saArticulo_saArtUnidad].[punt_ven] AS [punt_ven], 
//                                        [v_saArticulo_saArtUnidad].[punt_cli] AS [punt_cli], 
//                                        [v_saArticulo_saArtUnidad].[lic_mon_ilc] AS [lic_mon_ilc], 
//                                        [v_saArticulo_saArtUnidad].[lic_capacidad] AS [lic_capacidad], 
//                                        [v_saArticulo_saArtUnidad].[lic_grado_al] AS [lic_grado_al], 
//                                        [v_saArticulo_saArtUnidad].[lic_tipo] AS [lic_tipo], 
//                                        [v_saArticulo_saArtUnidad].[prec_om] AS [prec_om], 
//                                        [v_saArticulo_saArtUnidad].[comentario] AS [comentario], 
//                                        [v_saArticulo_saArtUnidad].[tipo_cos] AS [tipo_cos], 
//                                        [v_saArticulo_saArtUnidad].[porc_margen_minimo] AS [porc_margen_minimo], 
//                                        [v_saArticulo_saArtUnidad].[mont_comi] AS [mont_comi], 
//                                        [v_saArticulo_saArtUnidad].[porc_arancel] AS [porc_arancel], 
//                                        [v_saArticulo_saArtUnidad].[dis_cen] AS [dis_cen], 
//                                        [v_saArticulo_saArtUnidad].[campo1] AS [campo1], 
//                                        [v_saArticulo_saArtUnidad].[campo2] AS [campo2], 
//                                        [v_saArticulo_saArtUnidad].[campo3] AS [campo3], 
//                                        [v_saArticulo_saArtUnidad].[campo4] AS [campo4], 
//                                        [v_saArticulo_saArtUnidad].[campo5] AS [campo5], 
//                                        [v_saArticulo_saArtUnidad].[campo6] AS [campo6], 
//                                        [v_saArticulo_saArtUnidad].[campo7] AS [campo7], 
//                                        [v_saArticulo_saArtUnidad].[campo8] AS [campo8], 
//                                        [v_saArticulo_saArtUnidad].[co_us_in] AS [co_us_in], 
//                                        [v_saArticulo_saArtUnidad].[co_sucu_in] AS [co_sucu_in], 
//                                        [v_saArticulo_saArtUnidad].[fe_us_in] AS [fe_us_in], 
//                                        [v_saArticulo_saArtUnidad].[co_us_mo] AS [co_us_mo], 
//                                        [v_saArticulo_saArtUnidad].[co_sucu_mo] AS [co_sucu_mo], 
//                                        [v_saArticulo_saArtUnidad].[fe_us_mo] AS [fe_us_mo], 
//                                        [v_saArticulo_saArtUnidad].[revisado] AS [revisado], 
//                                        [v_saArticulo_saArtUnidad].[trasnfe] AS [trasnfe], 
//                                        [v_saArticulo_saArtUnidad].[validador] AS [validador], 
//                                        [v_saArticulo_saArtUnidad].[rowguid] AS [rowguid], 
//                                        [v_saArticulo_saArtUnidad].[co_uni] AS [co_uni], 
//                                        [v_saArticulo_saArtUnidad].[uni_principal] AS [uni_principal], 
//                                        [v_saArticulo_saArtUnidad].[des_uni] AS [des_uni], 
//                                        [v_saArticulo_saArtUnidad].[relacion] AS [relacion], 
//                                        [v_saArticulo_saArtUnidad].[equivalencia] AS [equivalencia], 
//                                        [v_saArticulo_saArtUnidad].[uso_principal] AS [uso_principal]
//                                      FROM [dbo].[v_saArticulo_saArtUnidad] AS [v_saArticulo_saArtUnidad]) AS [Extent1]
//                                      WHERE ([Extent1].[co_art] = @codArt) AND ([Extent1].[uni_principal] = 1)";
//                    var ent = ctx.Database.SqlQuery<DTO.GESTION.ObtenerArticulo>(sql, p1).FirstOrDefault();
//                    result.Entidad = ent;
//                    return result;
//                }
//            }
//            catch (Exception e)
//            {
//                result.Mensaje = e.Message;
//                result.Result = DTO.Enumerados.EnumResult.isError;
//            }
//            return result;
//        }
//        public DTO.ResultadoEntidad<decimal> 
//            Get_ObtenerPrecioxArtAlma(string codArt, DateTime fecha, string codPrecio, string codAlmacen, string coddMonedaBase, bool conIva, string codUnidad)
//        {
//            var result = new DTO.ResultadoEntidad<decimal>();
//            try
//            {
//                using (var ctx = new pPanEntities(_gestion.ConnectionString))
//                {
//                    var p1 = new SqlParameter("@strCo_Art", codArt);
//                    var p2 = new SqlParameter("@dtFecha", fecha.Date);
//                    var p3 = new SqlParameter("@strCo_Precio", codPrecio);
//                    var p4 = new SqlParameter("@strCo_Alma", codAlmacen);
//                    var p5 = new SqlParameter("@strCo_MoneBase", coddMonedaBase);
//                    var p6 = new SqlParameter("@bConImpuesto", conIva);
//                    var p7 = new SqlParameter("@sCod_Uni", codUnidad);
//                    var precio = 0m;

//                    var sql = @"SELECT TOP 1  
//                                    A.monto, 
//                                    A.co_mone, 
//                                    CAST(TP.incluye_imp AS INT) as precioIncluyeImpuesto, 
//                                    B.tipo_imp,
//                                    (CASE 
//                                        WHEN A.co_mone = (SELECT top(1) g_moneda FROM par_emp) OR A.co_mone IS NULL THEN 0 ELSE 1 
//                                    END) as otraMoneda 
//                                FROM
//                                    saArtPrecio A
//                                    INNER JOIN saArticulo B ON B.co_art = A.co_art
//                                    INNER JOIN saTipoPrecio TP ON Tp.co_precio = A.co_precio
//                                WHERE
//                                    A.Inactivo = 0 
//                                    AND A.co_precio = @strCo_Precio
//                                    AND A.co_art = @strCo_Art
//                                    AND ( A.co_alma IS NULL OR A.co_alma = @strCo_Alma)
//                                    AND ( @dtFecha>=A.desde)
//                                    AND ( @dtFecha <=A.hasta OR A.hasta IS NULL)
//                                ORDER BY desde DESC";
//                    var ent = ctx.Database.SqlQuery<hlp_1>(sql, p1, p2, p3, p4).FirstOrDefault();
//                    if (ent != null)
//                    {
//                        precio = ent.monto;
//                        if (ent.otraMoneda == 1) 
//                        {
//                            var t1 = new SqlParameter("@co_mone", ent.co_mone);
//                            var t2 = new SqlParameter("@dtFecha ", fecha);
//                            var sql2 = @" SELECT TOP 1
//                                            A.tasa_v, 
//                                            A.tasa_c, 
//                                            CAST(B.relacion AS INT)
//                                        FROM
//                                            saTasa A
//                                            INNER JOIN saMoneda B ON A.co_mone = B.co_mone
//                                        WHERE
//                                            A.co_mone = @co_mone
//                                            AND (@dtFecha >= A.fecha)
//                                        ORDER BY
//                                            fecha DESC";
//                            var ent2 = ctx.Database.SqlQuery<hlp_2>(sql2, t1, t2).FirstOrDefault();
//                            if (ent2 != null) 
//                            {
//                                precio *= ent2.tasa_v;
//                            }
//                        }
//                        var y1 = new SqlParameter("@dtFecha ", fecha);
//                        var y2 = new SqlParameter("@chTipoImpuesto", ent.tipo_imp);
//                        var y3 = new SqlParameter("@bVenta", 1);
//                        var sql3= @"SELECT TOP 1 
//                                        porc_tasa
//                                    FROM
//                                        saImpuestoSobreVentaReng
//                                    WHERE
//                                        fecha <= @dtFecha
//                                        AND tipo_imp = @chTipoImpuesto
//                                        AND ( ( @bVenta = 1 AND ventas = 1) OR ( @bVenta = 0 AND compras = 1) )
//                                    ORDER BY
//                                        fecha DESC";
//                        var ent3 = ctx.Database.SqlQuery<decimal>(sql3, y1, y2, y3).FirstOrDefault();
//                        if (ent.precioIncluyeImpuesto == 0 && conIva==true) // AGREGAR EL VALOR DEL IVA AL PRECIO
//                        {
//                            precio = (precio * ent3 / 100) + precio;
//                        }
//                        if (ent.precioIncluyeImpuesto == 1 && conIva==false) // EXTRAER EL VALOR DEL IVA AL PRECIO
//                        {
//                            precio = (precio * 100) / (100 + ent3);
//                        }

//                        var x1 = new SqlParameter("@strCo_Art", codArt);
//                        var x2 = new SqlParameter("@sCod_Uni", codUnidad);
//                        var x3 = new SqlParameter("@cnt", 1);
//                        var sql4 = @"SELECT
//                                        ROUND(@cnt * (
//                                                    CASE WHEN
//                                                            saArtUnidad.uni_principal = 1 OR saArtUnidad.uni_secundaria = 1
//                                                            THEN 1
//                                                            ELSE (
//                                                                    CASE WHEN 
//                                                                            saArtUnidad.relacion = 0 
//                                                                            THEN saArtUnidad.equivalencia 
//                                                                            ELSE 1/ saArtUnidad.equivalencia
//                                                                    END)
//                                                            END ), 5)
//                                    FROM
//                                        saArtUnidad
//                                        WHERE
//                                            saArtUnidad.co_art = @strCo_Art
//                                            AND saArtUnidad.co_uni = @sCod_Uni";
//                        var ent4 = ctx.Database.SqlQuery<decimal>(sql4, x1, x2, x3).FirstOrDefault();
//                        precio *= ent4;
//                    }
//                    result.Entidad = precio;
//                    return result;
//                }
//            }
//            catch (Exception e)
//            {
//                result.Mensaje = e.Message;
//                result.Result = DTO.Enumerados.EnumResult.isError;
//            }
//            return result;
//        }
//        public DTO.ResultadoEntidad<DTO.GESTION.ObtenerFechaTasa>
//            Get_ObtenerFechaTasa(string codMoneda, DateTime fecha)
//        {
//            var result = new DTO.ResultadoEntidad<DTO.GESTION.ObtenerFechaTasa>();
//            try
//            {
//                using (var ctx = new pPanEntities(_gestion.ConnectionString))
//                {
//                    var p1 = new SqlParameter("@sCo_Mone", codMoneda);
//                    var p2 = new SqlParameter("@dtFecha", fecha);
//                    var sql = @"exec pObtenerFechaTasa @sCo_Mone, @dtFecha";
//                    var ent = ctx.Database.SqlQuery<DTO.GESTION.ObtenerFechaTasa>(sql, p1, p2).FirstOrDefault();
//                    result.Entidad = ent;
//                    return result;
//                }
//            }
//            catch (Exception e)
//            {
//                result.Mensaje = e.Message;
//                result.Result = DTO.Enumerados.EnumResult.isError;
//            }
//            return result;
//        }

    }

}