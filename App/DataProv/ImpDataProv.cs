using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{
    
    public partial class ImpDataProv: IDataProv
    {

        private Service.IServContrato ServiceProv;
 

        public ImpDataProv(string instancia, string cat1, string cat2, string usu, bool isModoProduccion)
        {
            ServiceProv = new Service.ServImpContrato(instancia, cat1, cat2, usu, isModoProduccion);
        }


        public OOB.ResultadoEntidad<bool> 
            AutenticarUsuario(string codUsu, string psw)
        {
            var rt= new OOB.ResultadoEntidad<bool>();
            var r01 = ServiceProv.Get_EstatusUsuario(codUsu);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            if (r01.Entidad.Estado == "I")
            {
                throw new Exception("USUARIO INACTIVO, VERIFIQUE POR FAVOR");
            }
            var r02 = ServiceProv.AutenticarUsuario(codUsu, psw);
            if (r02.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r02.Mensaje);
            }
            if (r02.Entidad == 0)
            {
                throw new Exception("CLAVE INCORRECTA, VERIFIQUE POR FAVOR");
            }
            rt.Entidad = true;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.Usuario> 
            GetUsuario(string codUsu)
        {
            var rt = new OOB.ResultadoEntidad<OOB.Usuario>();
            var r01 = ServiceProv.GetUsuario(codUsu);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s= r01.Entidad;
            rt.Entidad = new OOB.Usuario()
            {
                AccesoTodasEmpresaAdmi = s.Acceso_Todas_Empresa_Admi,
                CambSucu = s.Camb_Sucu,
                CodEmpresaAdmi = s.Cod_Empresa_Admi,
                CodUsuario = s.Cod_Usuario,
                CoMapaAdmi = s.co_mapa_admi,
                DescUsuario = s.Desc_Usuario,
                Estado = s.Estado,
                FecProx = s.Fec_Prox,
                FecUlt = s.Fec_Ult,
                FecUltFA = s.Fec_Ult_FA,
                IdGrupo = s.Id_Grupo,
                PideSucu = s.Pide_Sucu,
                Prioridad = s.Prioridad,
                SelEmpresaAdmi = s.Sel_Emp_Admi,
                Sucursal = s.Sucursal,
            };
            return rt;
        }


        public OOB.ResultadoEntidad<OOB.Empresa> 
            GetEmpresa(string codEmp)
        {
            var rt = new OOB.ResultadoEntidad<OOB.Empresa>();
            var r01 = ServiceProv.GetEmpresa(codEmp);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            if (r01.Entidad != null)
            {
                var s = r01.Entidad;
                rt.Entidad = new OOB.Empresa()
                {
                    cod_empresa = s.cod_empresa,
                    desc_empresa = s.desc_empresa,
                    producto = s.producto,
                    rif = s.rif,
                };
            }
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.EmpresaParametros> 
            GetEmpresaParametros(string codEmp)
        {
            var rt = new OOB.ResultadoEntidad<OOB.EmpresaParametros>();
            var r01 = ServiceProv.GetEmpresaParametros(codEmp);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            if (r01.Entidad != null)
            {
                var s = r01.Entidad;
                rt.Entidad = new OOB.EmpresaParametros()
                {
                    cod_emp = s.cod_emp,
                    g_moneda = s.g_moneda,
                    i_moneda_articulo = s.i_moneda_articulo,
                    v_co_ven = s.v_co_ven,
                    v_cond_pago = s.v_cond_pago,
                    v_tip_cli = s.v_tip_cli,
                    v_maneja_sucursales = s.v_maneja_sucursales,
                };
            }
            return rt;
        }
        public OOB.ResultadoLista<OOB.EmpresaLista> 
            GetEmpresaListaByUsuario(string codUsu, string codPaquete)
        {
            var rt = new OOB.ResultadoLista<OOB.EmpresaLista>();
            var r01 = ServiceProv.GetEmpresaListaAccesoByUsuario(codUsu, codPaquete);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<OOB.EmpresaLista>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0) 
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.EmpresaLista()
                        {
                            co_mapa = s.co_mapa,
                            cod_empresa = s.cod_empresa,
                            desc_empresa = s.desc_empresa,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = _lst;
            return rt;
        }


        public OOB.ResultadoLista<OOB.SucursalLista> 
            GetSucursalLista()
        {
            var rt = new OOB.ResultadoLista<OOB.SucursalLista>();
            var r01 = ServiceProv.GetSucursalLista();
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var _lst = new List<OOB.SucursalLista>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    _lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.SucursalLista()
                        {
                            co_sucur = s.co_sucur,
                            sucur_des = s.sucur_des,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = _lst;
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.Sucursal> 
            GetSucursalById(string codSuc)
        {
            var rt = new OOB.ResultadoEntidad<OOB.Sucursal>();
            var r01 = ServiceProv.Get_SucursalById(codSuc);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var nr = new OOB.Sucursal ()
            {
                co_sucur = s.co_sucur,
                sucur_des = s.sucur_des,
            };
            rt.Entidad = nr;
            return rt;
        }


        public OOB.ResultadoEntidad<DateTime> 
            GetFechaServidor()
        {
            var rt = new OOB.ResultadoEntidad<DateTime>();
            var r01 = ServiceProv.serv_ObtenerFecha();
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            rt.Entidad = r01.Entidad;
            return rt;
        }

    }

}