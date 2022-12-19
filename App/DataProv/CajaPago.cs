using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{
    
    public partial class ImpDataProv: IDataProv
    {
        public OOB.ResultadoLista<OOB.Sistema.CajaPago.Ficha> 
            cjPago_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.Sistema.CajaPago.Ficha>();
            var r01 = ServiceProv.cjPago_Lista();
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.Sistema.CajaPago.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Sistema.CajaPago.Ficha()
                        {
                            cod_caja = s.cod_caja,
                            descrip = s.descrip,
                            inactivo = s.inactivo,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.Sistema.CajaPago.Ficha> 
            cjPago_GetCajaPagoById(string codCjaPago)
        {
            var rt = new OOB.ResultadoEntidad<OOB.Sistema.CajaPago.Ficha>();
            var r01 = ServiceProv.cjPago_GetCajaPagoById(codCjaPago);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            if (r01.Entidad != null)
            {
                var s = r01.Entidad;
                rt.Entidad = new OOB.Sistema.CajaPago.Ficha()
                {
                    cod_caja = s.cod_caja,
                    descrip = s.descrip,
                    co_mone=s.co_mone,
                    inactivo = s.inactivo,
                    rowguid = s.rowguid,
                };
            }
            return rt;
        }
    }

}