using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{

    public partial class ImpDataProv: IDataProv
    {

        public OOB.ResultadoEntidad<OOB.Sistema.Vendedor.Ficha> 
            sist_vend_ObtenerFicha(string codVen)
        {
            var rt = new OOB.ResultadoEntidad<OOB.Sistema.Vendedor.Ficha>();
            var r01 = ServiceProv.sist_vend_ObtenerFicha(codVen);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var ent = new OOB.Sistema.Vendedor.Ficha()
            {
                cedula = s.cedula,
                co_ven = s.co_ven,
                co_zon = s.co_zon,
                comentario = s.comentario,
                comision = s.comision,
                comissionv = s.comissionv,
                direc1 = s.direc1,
                direc2 = s.direc2,
                fecha_reg = s.fecha_reg,
                fun_cob = s.fun_cob,
                fun_ven = s.fun_ven,
                inactivo = s.inactivo,
                telefonos = s.telefonos,
                tipo = s.tipo,
                ven_des = s.ven_des,
            };
            rt.Entidad = ent;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.Sistema.CondPago.Ficha> 
            sist_condPago_ObtenerFicha(string codCond)
        {
            var rt = new OOB.ResultadoEntidad<OOB.Sistema.CondPago.Ficha>();
            var r01 = ServiceProv.sist_condPago_ObtenerFicha(codCond);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var ent = new OOB.Sistema.CondPago.Ficha()
            {
                co_cond = s.co_cond,
                cond_des = s.cond_des,
                dias_cred = s.dias_cred,
            };
            rt.Entidad = ent;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.Sistema.Transporte.Ficha> 
            sist_transporte_ObtenerFicha(string codTrans)
        {
            var rt = new OOB.ResultadoEntidad<OOB.Sistema.Transporte.Ficha>();
            var r01 = ServiceProv.sist_transporte_ObtenerFicha(codTrans);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var ent = new OOB.Sistema.Transporte.Ficha()
            {
                co_tran = s.co_tran,
                des_tran = s.des_tran,
            };
            rt.Entidad = ent;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.Sistema.Moneda.Ficha> 
            sist_moneda_ObtenerFicha(string codMone)
        {
            var rt = new OOB.ResultadoEntidad<OOB.Sistema.Moneda.Ficha>();
            var r01 = ServiceProv.sist_moneda_ObtenerFicha(codMone);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var ent = new OOB.Sistema.Moneda.Ficha()
            {
                cambio = s.cambio,
                co_mone = s.co_mone,
                mone_des = s.mone_des,
                relacion = s.relacion,
            };
            rt.Entidad = ent;
            return rt;
        }
        public OOB.ResultadoEntidad<decimal>
            sist_TasaCambio_ObtenerFicha(string codMoneda, DateTime fecha)
        {
            var rt = new OOB.ResultadoEntidad<decimal>();
            var r01 = ServiceProv.sist_ObtenerTasaCambio(codMoneda, fecha);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _tasa = 0m;
            if (r01.Entidad != null)
            {
                _tasa = r01.Entidad.TASA_V;
            }
            rt.Entidad = _tasa;
            return rt;
        }

    }

}