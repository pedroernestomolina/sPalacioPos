using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contrato
{

    public interface IMaster
    {

        DTO.ResultadoEntidad<DateTime>
            Test_1();


        DTO.ResultadoEntidad<DTO.MASTER.EstatusFechaServidor>
            Get_EstatusFechaServidor(string codProducto);
        DTO.ResultadoEntidad<DTO.MASTER.EstatusUsuario>
            Get_EstatusUsuario(string codUsu);
        DTO.ResultadoEntidad<int>
            AutenticarUsuario(string codUsu, string psw);
        DTO.ResultadoEntidad<DTO.MASTER.MpUsuario>
            SeleccionarUsuario(string codUsu);
        DTO.Resultado
            ActualizarNumeroIntentos(string codUsu, bool actualizar);
        DTO.Resultado
            ActualizarFechaUltimoLogueo(string codUsu);
        DTO.Resultado
            InsertarPista(string codUsu, string tabla, string tipoOp, string nomEquipo, string coSucu, string campos);
        DTO.ResultadoLista<DTO.MASTER.ConsultarUsuarioAccesos> //QUE EMPRESAS PUEDE USAR EL USUARIO
            ConsultarUsuarioAccesos(string codUsu, string sProducto);
        DTO.ResultadoEntidad<DTO.MASTER.MpEmpresa>
            SeleccionarMpEmpresa(string codEmpresa);
        DTO.ResultadoEntidad<string>
            ObtenerMapaUsuario(string codUsu, string psw, string sEmpresa, string sProducto);
        DTO.ResultadoEntidad<DTO.MASTER.MpMapa>
            SeleccionarMapa(string codMapa, string sProducto);
        DTO.ResultadoLista<DTO.MASTER.MpConfiguracion>
            Get_MpConfiguracion();

    }

}