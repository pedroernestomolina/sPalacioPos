using Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    
    public partial class ServImpContrato: IServContrato
    {

        public static IProvider ServiceProv;


        public ServImpContrato(string instancia, string cat1, string cat2, string usu, bool isModoProduccion)
        {
            ServiceProv = new ImpContrato.Provider(instancia, cat1, cat2, usu, isModoProduccion);
        }


        public DTO.ResultadoEntidad<DateTime> 
            serv_ObtenerFecha()
        {
            return ServiceProv.Get_FechaServidor();
        }
        

        public DTO.ResultadoEntidad<DTO.MASTER.EstatusUsuario> 
            Get_EstatusUsuario(string codUsu)
        {
            return ServiceProv.Get_EstatusUsuario(codUsu);
        }
        public DTO.ResultadoEntidad<int> 
            AutenticarUsuario(string codUsu, string psw)
        {
            return ServiceProv.AutenticarUsuario(codUsu, psw);
        }
        public DTO.ResultadoEntidad<DTO.MASTER.MpUsuario> 
            GetUsuario(string codUsu)
        {
            return ServiceProv.SeleccionarUsuario(codUsu);
        }
        

        public DTO.ResultadoEntidad<DTO.MASTER.MpEmpresa> 
            GetEmpresa(string codEmpresa)
        {
            return ServiceProv.SeleccionarMpEmpresa(codEmpresa);
        }
        public DTO.ResultadoEntidad<DTO.GESTION.PAR_EMP> 
            GetEmpresaParametros(string codEmpresa)
        {
            return ServiceProv.SeleccionarParametrosEmpresa(codEmpresa);
        }


        public DTO.ResultadoLista<DTO.MASTER.ConsultarUsuarioAccesos> 
            GetEmpresaListaAccesoByUsuario(string codUsu, string sProducto)
        {
            return ServiceProv.ConsultarUsuarioAccesos(codUsu, sProducto);
        }


        public DTO.ResultadoLista<DTO.GESTION.SucursalLista> 
            GetSucursalLista()
        {
            return ServiceProv.Get_Sucursales();
        }
        public DTO.ResultadoEntidad<DTO.GESTION.Sucursal> 
            Get_SucursalById(string codSuc)
        {
            return ServiceProv.Get_SucursalById(codSuc);
        }

    }

}