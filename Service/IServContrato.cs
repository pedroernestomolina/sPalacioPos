using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    
    public interface IServContrato: IVenta, ITasaFiscal, ICliente, ISistema, IArticulo
    {

        DTO.ResultadoEntidad<DateTime>
            serv_ObtenerFecha();


        DTO.ResultadoEntidad<DTO.MASTER.EstatusUsuario>
            Get_EstatusUsuario(string codUsu);
        DTO.ResultadoEntidad<int>
            AutenticarUsuario(string codUsu, string psw);
        DTO.ResultadoEntidad<DTO.MASTER.MpUsuario>
            GetUsuario(string codUsu);

        DTO.ResultadoLista<DTO.MASTER.ConsultarUsuarioAccesos>
            GetEmpresaListaAccesoByUsuario(string codUsu, string sProducto);
        DTO.ResultadoEntidad<DTO.MASTER.MpEmpresa>
            GetEmpresa(string codEmpresa);
        DTO.ResultadoEntidad<DTO.GESTION.PAR_EMP>
            GetEmpresaParametros(string codEmpresa);


        DTO.ResultadoLista<DTO.GESTION.SucursalLista>
            GetSucursalLista();
        DTO.ResultadoEntidad<DTO.GESTION.Sucursal>
            Get_SucursalById(string codSuc);

    }

}