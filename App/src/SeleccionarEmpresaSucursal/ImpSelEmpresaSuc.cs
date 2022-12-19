using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.SeleccionarEmpresaSucursal
{

    public class ImpSelEmpresaSuc : ISelEmpresaSuc
    {


        private hlp.Opcion.IOpcion _gEmpresa;
        private hlp.Opcion.IOpcion _gSucursal;
        private bool _hab_Empresa;
        private bool _hab_Sucursal;


        public ImpSelEmpresaSuc()
        {
            _abandonarIsOk = false;
            _acepTarDatosIsOk = false;
            _hab_Empresa = false;
            _hab_Sucursal = false;
            _gEmpresa = new hlp.Opcion.ImpOpcion();
            _gSucursal = new hlp.Opcion.ImpOpcion();
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _acepTarDatosIsOk = false;
            _hab_Empresa = false;
            _hab_Sucursal = false;
            _gEmpresa.Inicializa();
            _gSucursal.Inicializa();
        }
        SelEmpSucFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new SelEmpSucFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar();
        }


        public BindingSource GetEmpresa_Source { get { return _gEmpresa.Source; } }
        public BindingSource GetSucursal_Source { get { return _gSucursal.Source; } }
        public bool GetEmpresa_Habilitar { get { return _hab_Empresa; } }
        public bool GetSucursal_Habilitar { get { return _hab_Sucursal; } }
        public string GetEmpresa_ID { get { return _gEmpresa.GetId; } }
        public string GetSucursal_ID { get { return _gSucursal.GetId; } }
        public void setEmpresa(string id)
        {
            _gEmpresa.setFicha(id);
        }
        public void setSucursal(string id)
        {
            _gSucursal.setFicha(id);
        }


        private bool _acepTarDatosIsOk;
        public bool AcepTarDatosIsOk { get { return _acepTarDatosIsOk; } }
        public bool SelEmpresaSucIsOk { get { return _acepTarDatosIsOk; } }
        public void AceptarDatos()
        {
            _acepTarDatosIsOk = false;
            if (_gEmpresa.GetId == "") 
            {
                Helpers.Msg.Error("[ CAMPO EMPRESA NO SELECCIONADO ] DEBES SELECCIONAR UNA EMPRESA");
                return;
            }
            if (_gSucursal.GetId == "")
            {
                Helpers.Msg.Error("[ CAMPO SUCURSAL NO SELECCIONADO ] DEBES SELECCIONAR UNA SUCURSAL");
                return;
            }
            _acepTarDatosIsOk = true;
        }


        private bool CargarData()
        {
            try
            {
                var _lstEmp = new List<hlp.ficha>();
                var _lstSuc = new List<hlp.ficha>();
                var _codUsu = Sistema.Usuario.CodUsuario;
                var _codPqte = Sistema.MyConfiguracion.codPaquete;

                var r01 = Sistema.MyData.GetEmpresaListaByUsuario(_codUsu, _codPqte);
                var r02 = Sistema.MyData.GetSucursalLista();

                //EMPRESAS
                foreach (var rg in r01.Lista)
                {
                    var nr = new hlp.ficha()
                    {
                        codigo = "",
                        desc = rg.desc_empresa,
                        id = rg.cod_empresa,
                    };
                    _lstEmp.Add(nr);
                }
                _gEmpresa.setData(_lstEmp);
                //SUCURSALES
                foreach (var rg in r02.Lista)
                {
                    var nr = new hlp.ficha()
                    {
                        codigo = "",
                        desc = rg.sucur_des,
                        id = rg.co_sucur,
                    };
                    _lstSuc.Add(nr);
                }
                _gSucursal.setData(_lstSuc);

                //PUEDO SELECCIONAR LA EMPRESA
                if (Sistema.Usuario.SelEmpresaAdmi) 
                {
                    _hab_Empresa=true;
                }
                else
                {
                    _gEmpresa.setFicha(Sistema.Usuario.CodEmpresaAdmi);
                    _hab_Empresa = false;
                }

                // PUEDO SELECCIONAR QUE SUCURSAL 
                if (Sistema.Usuario.PideSucu) 
                {
                    if (Sistema.Usuario.CambSucu)  
                    {
                        _hab_Sucursal = true;
                    }
                    else
                    {
                        _gSucursal.setFicha(Sistema.Usuario.Sucursal);
                        _hab_Sucursal = false;
                    }
                }
                else
                {
                    _gSucursal.setFicha(Sistema.Usuario.Sucursal);
                    _hab_Sucursal = false;
                }
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

    }

}
