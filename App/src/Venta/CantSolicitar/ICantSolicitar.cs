using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Venta.CantSolicitar
{
    
    public interface ICantSolicitar: hlp.IGestion
    {
        bool CantSolicitarIsOk { get; }
        decimal GetCntSolicitada { get; }
        void setCant(decimal cnt);
        void AceptarSolicitud();

        void Abandonar();
        bool AbandonarIsOk { get; }
        bool AceptarSolicitudIsOk { get; }
    }

}