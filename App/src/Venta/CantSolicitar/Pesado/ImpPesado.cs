using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Venta.CantSolicitar.Pesado
{
    
    public class ImpPesado: ICantSolicitar
    {


        private decimal _cntSolicitar;
        private bool _cntSolicitarIsOk;
        public bool CantSolicitarIsOk { get { return _cntSolicitarIsOk; } }


        public ImpPesado()
        {
            _abandonarIsOk = false;
            _cntSolicitarIsOk = false;
            _cntSolicitar = 0m;
        }


        public void Inicializa()
        {
            _cntSolicitar = 0m;
        }
        CantSolicitarFrm frm;
        public void Inicia()
        {
            if (frm == null)
            {
                frm = new CantSolicitarFrm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }


        public decimal GetCntSolicitada { get { return _cntSolicitar; } }
        public void setCant(decimal cnt)
        {
            _cntSolicitar = cnt;
        }


        public bool AceptarSolicitudIsOk { get { return _cntSolicitarIsOk; } }
        public void AceptarSolicitud()
        {
            _cntSolicitarIsOk = false;
            if (_cntSolicitar > 0m) 
            {
                _cntSolicitarIsOk=true;
            }
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void Abandonar()
        {
            _abandonarIsOk = true;
        }

    }

}