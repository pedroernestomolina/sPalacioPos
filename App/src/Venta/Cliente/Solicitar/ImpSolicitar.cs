using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Venta.Cliente.Solicitar
{
    
    public class ImpSolicitar: ISolicitar
    {


        public ImpSolicitar ()	
        {
            _abandonarIsOk = false;
            _aceptarProcesarIsOk = false;
            _clienteSolciitar = "";
            _clienteSeleccionado = null;
        }


        public void Inicializa()
        {
            _abandonarIsOk = false;
            _aceptarProcesarIsOk = false;
            _clienteSolciitar = "";
            _clienteSeleccionado = null;
        }
        SolicitarFrm frm;
        public void Inicia()
        {
            if (frm == null)
            {
                frm = new SolicitarFrm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = Helpers.Msg.Abandonar("Abandonar Busqueda ?");
        }


        private string _clienteSolciitar;
        public string GetClienteSolcitar { get { return _clienteSolciitar; } }
        public void setClienteBuscar(string ciRif)
        {
            _clienteSolciitar = ciRif;
        }


        private bool _aceptarProcesarIsOk;
        private OOB.Cliente.Ficha _clienteSeleccionado;
        public bool AceptarProcesarIsOk { get { return _aceptarProcesarIsOk; } }
        public bool ClientSeleccionadoIsOk { get { return _aceptarProcesarIsOk; } }
        public OOB.Cliente.Ficha ClientSeleccionado { get { return _clienteSeleccionado; } }
        public void AceptarProcesar()
        {
            _aceptarProcesarIsOk = false;
            _clienteSeleccionado=null;
            if (_clienteSolciitar.Trim() == "") { return; }
            try
            {
                var r01 = Sistema.MyData.cli_ObtenerFichaById(_clienteSolciitar);
                _clienteSeleccionado = r01.Entidad;
                _aceptarProcesarIsOk = true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }

}