using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{
    
    public interface IDataProv: IVenta, ITasaFiscal, ICliente, ISistema, IArticulo
    {

        OOB.ResultadoEntidad<bool>
            AutenticarUsuario(string codUsu, string psw);
        OOB.ResultadoEntidad<OOB.Usuario>
            GetUsuario(string codUsu);


        OOB.ResultadoLista<OOB.EmpresaLista>
            GetEmpresaListaByUsuario(string codUsu, string codPaquete);
        OOB.ResultadoEntidad<OOB.Empresa>
            GetEmpresa(string codEmp);
        OOB.ResultadoEntidad<OOB.EmpresaParametros>
            GetEmpresaParametros(string codEmp);


        OOB.ResultadoLista<OOB.SucursalLista>
            GetSucursalLista();
        OOB.ResultadoEntidad<OOB.Sucursal>
            GetSucursalById(string codSuc);


        OOB.ResultadoEntidad<DateTime>
            GetFechaServidor();

    }

}