using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Venta.CantSolicitar.NoPesado
{
    
    public class ImpNoPesado: ICantSolicitar
    {


        private decimal _cntSolicitar;
        private bool _cntSolicitarIsOk;
        public bool CantSolicitarIsOk { get { return _cntSolicitarIsOk; } }


        public ImpNoPesado()
        {
            _abandonarIsOk = false;
            _cntSolicitarIsOk = false;
            _cntSolicitar = 1;
        }


        public void Inicializa()
        {
            _cntSolicitar = 1m;
        }
        CantFrm frm;
        public void Inicia()
        {
            if (frm == null)
            {
                frm = new CantFrm();
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
            if (_cntSolicitar > 0) 
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