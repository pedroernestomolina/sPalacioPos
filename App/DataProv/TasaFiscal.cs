using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{

    public partial class ImpDataProv: IDataProv
    {

        public OOB.ResultadoLista<OOB.TasaFiscal.Tipo>
            tasa_ObtenerTipoTasaFiscal()
        {
            var rt = new OOB.ResultadoLista<OOB.TasaFiscal.Tipo>();
            var r01 = ServiceProv.tasa_ObtenerTipoTasaFiscal();
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.TasaFiscal.Tipo>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.TasaFiscal.Tipo()
                        {
                            co_fijo = s.co_fijo,
                            desc_fijo = s.desc_fijo,
                            orden = s.orden,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;
            return rt;
        }
        public OOB.ResultadoLista<OOB.TasaFiscal.TipoValor>
            tasa_ObtenerTasaPorTipoValor(DateTime fecha)
        {
            var rt = new OOB.ResultadoLista<OOB.TasaFiscal.TipoValor>();
            var r01 = ServiceProv.tasa_ObtenerTasaPorTipoValor(fecha);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.TasaFiscal.TipoValor>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.TasaFiscal.TipoValor()
                        {
                            fecha = s.fecha,
                            porc_suntuario = s.porc_suntuario,
                            porc_tasa = s.porc_tasa,
                            tipo_imp = s.tipo_imp,
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