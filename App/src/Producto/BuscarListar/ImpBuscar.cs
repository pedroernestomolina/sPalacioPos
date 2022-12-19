using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Producto.BuscarListar
{
    
    public class ImpBuscar: IBuscar
    {

        private IListaPrd _listaPrd;
        private bool _procesarItemIsOk;
        private string _idItemProcesar;


        public BindingSource GetData_Source { get { return _listaPrd.GetSource; } }
        public int GetCntItems { get { return _listaPrd.GetCtnItems; } }
        public data ItemActual { get { return (data)_listaPrd.ItemActual; } }
        

        public ImpBuscar()
        {
            _procesarItemIsOk = false;
            _idItemProcesar = "";
            _listaPrd = new ListaPrd();
            _gTipoBusq = new hlp.Opcion.ImpOpcion();
        }

        public void Inicializa()
        {
            _procesarItemIsOk = false;
            _idItemProcesar = "";
            _listaPrd.Inicializa();
            _gTipoBusq.Inicializa();
        }
        BuscarListarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new BuscarListarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        private string _cadenaBus;
        public void setCadenaBus(string cad)
        {
            _cadenaBus = cad;
        }
        public void Buscar()
        {
            if (_cadenaBus.Trim() == "") { return; }
            if (_gTipoBusq.GetId == "") { return; }
            try
            {
                var _modoBusq = OOB.Articulo.Enumerados.enumTipoBusqueda.PorCodigo;
                if (_gTipoBusq.GetId == "02") { _modoBusq = OOB.Articulo.Enumerados.enumTipoBusqueda.PorDescripcion; }
                var r01 = Sistema.MyData.art_ObtenerLista(_cadenaBus, _modoBusq);
                if (_modoBusq == OOB.Articulo.Enumerados.enumTipoBusqueda.PorCodigo)
                {
                    _listaPrd.setLista(r01.Lista.OrderBy(o=>o.co_art).ToList());
                }
                else
                {
                    _listaPrd.setLista(r01.Lista.OrderBy(o => o.art_des).ToList());
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void VerPrecio()
        {
            if (ItemActual != null)
            {
                try
                {
                    if (!ItemActual.PrecioIsActivo)
                    {
                        var r00 = Sistema.MyData.art_ObtenerFichaById(ItemActual.codPrd);
                        var codUnd = r00.Entidad.UnidadPrincipal;
                        var precioConIvaIncluido = true;
                        var codMonedaBase = Sistema.MyConfiguracion.codMoneda_Trabajo; //BSS
                        var codMonedaManejoPrecio = Sistema.MyConfiguracion.codMoneda_PrecioArticulo;//US$
                        var codAlmacen = Sistema.MyConfiguracion.codAlmacen;//01
                        var codPrecio = Sistema.MyConfiguracion.codPrecio;//01
                        var fecha = Sistema.MyConfiguracion.FechaServidor;//ACTUAL DEL SERVIDOR
                        //
                        var r01 = Sistema.MyData.art_ObtenerPrecio(ItemActual.codPrd, fecha, codPrecio, codAlmacen, codMonedaBase, precioConIvaIncluido, codUnd);
                        var r02 = Sistema.MyData.sist_TasaCambio_ObtenerFicha(codMonedaManejoPrecio, fecha);
                        ItemActual.setPrecioBs(r01.Entidad, r02.Entidad);
                    }
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        public void LimpiarBusqueda()
        {
            _listaPrd.LimpiarLista();
            _cadenaBus = "";
        }


        private hlp.Opcion.IOpcion _gTipoBusq;
        public string GetTipoBusqueda_Id { get { return _gTipoBusq.GetId; } }
        public BindingSource GetTipoBusqueda_Source { get { return _gTipoBusq.Source; } }


        private bool CargarData()
        {
            try
            {
                var _lst = new List<hlp.ficha>();
                _lst.Add(new hlp.ficha() { id = "01", codigo = "", desc = "Código" });
                _lst.Add(new hlp.ficha() { id = "02", codigo = "", desc = "Descripción" });
                _gTipoBusq.setData(_lst);
                setTipoBusqueda("02");
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }


        public void setTipoBusqueda(string id)
        {
            _gTipoBusq.setFicha(id);
        }
        public bool ProcesarItemIsOk { get { return _procesarItemIsOk; } }
        public string GetItemProcesar_Id { get { return _idItemProcesar; } }
        public void ProcesarArticulo()
        {
            _procesarItemIsOk = false;
            _idItemProcesar = "";
            if (ItemActual != null)
            {
                _procesarItemIsOk = true;
                _idItemProcesar = ItemActual.codPrd;
            }
        }

    }

}