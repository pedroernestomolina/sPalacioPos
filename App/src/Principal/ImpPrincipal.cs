using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Principal
{
    
    public class ImpPrincipal: IPrincipal
    {

        private bool _abandonarIsOk;
        private Producto.BuscarListar.IBuscar _gBuscarPrd;
        private Venta.ICajaVenta _gCajaVenta;



        public ImpPrincipal()
        {
            _abandonarIsOk = false;
            _gBuscarPrd = new Producto.BuscarListar.ImpBuscar();
            _gCajaVenta = new Venta.ImpCajaVenta();
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
        }
        PrincipalFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                CargarCuenta();
                //if (frm == null)
                //{
                //    frm = new PrincipalFrm();
                //    frm.setControlador(this);
                //}
                //frm.ShowDialog();
            }
        }


        public void BuscarProductos()
        {
            _gBuscarPrd.Inicializa();
            _gBuscarPrd.Inicia();
        }
        public void CargarCuenta()
        {
            _gCajaVenta.Inicializa();
            _gCajaVenta.Inicia();
        }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }


        private bool CargarData()
        {
            try
            {
                var codEmpresa = Sistema.MyConfiguracion.codEmpresa;
                var r01 = Sistema.MyData.GetEmpresa(codEmpresa);
                Sistema.MyConfiguracion.DescEmpresa = r01.Entidad.desc_empresa.Trim();
                var r02 = Sistema.MyData.GetEmpresaParametros(codEmpresa);
                Sistema.MyConfiguracion.codMoneda_PrecioArticulo = r02.Entidad.i_moneda_articulo.Trim();
                Sistema.MyConfiguracion.codMoneda_Trabajo = r02.Entidad.g_moneda.Trim();
                Sistema.MyConfiguracion.codPrecio = "01";
                Sistema.MyConfiguracion.codAlmacen = "01";
                var codSuc= Sistema.MyConfiguracion.codSucursal;
                var r03 = Sistema.MyData.GetSucursalById(codSuc);
                Sistema.MyConfiguracion.DescSucursal = r03.Entidad.sucur_des.Trim();
                var r04 = Sistema.MyData.GetFechaServidor();
                Sistema.MyConfiguracion.FechaServidor= r04.Entidad;

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
