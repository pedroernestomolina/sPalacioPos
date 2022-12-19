using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                src.Login.ILogin _gLogin = new src.Login.ImpLogin();
                src.SeleccionarEmpresaSucursal.ISelEmpresaSuc _gSelEmpresaSuc = new src.SeleccionarEmpresaSucursal.ImpSelEmpresaSuc();


                bool isModoProduccion = true;
                Helpers.Utilitis.CargarXml();
                Sistema.ImprimirFactura = new Imprimir.Tickera80.Documento();
                Sistema.MyConfiguracion= new Sistema.Configuracion();
                Sistema.MyConfiguracion.codPaquete = "ADMI";
                Sistema.MyConfiguracion.NombreEquipo = Environment.MachineName.ToString();
                Sistema.MyData = new DataProv.ImpDataProv(Sistema.MyServidor.Instancia,
                                                                Sistema.MyServidor.Catalogo1,
                                                                Sistema.MyServidor.Catalogo2,
                                                                Sistema.MyServidor.Usuario,
                                                                isModoProduccion);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                _gLogin.Inicializa();
                _gLogin.Inicia();
                if (_gLogin.LoginIsOk)
                {
                    var r01 = Sistema.MyData.GetUsuario(_gLogin.GetCodUsu);
                    Sistema.Usuario = r01.Entidad;

                    //
                    _gSelEmpresaSuc.Inicializa();
                    _gSelEmpresaSuc.Inicia();
                    if (_gSelEmpresaSuc.SelEmpresaSucIsOk)
                    {
                        Sistema.MyConfiguracion.codEmpresa = _gSelEmpresaSuc.GetEmpresa_ID.Trim();
                        Sistema.MyConfiguracion.codSucursal = _gSelEmpresaSuc.GetSucursal_ID.Trim();
                        var _gPrincipal = new src.Principal.ImpPrincipal();
                        _gPrincipal.Inicializa();
                        _gPrincipal.Inicia();
                    }
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
            Application.Exit();
        }
    }
}