using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.hlp
{
    
    public interface IAceptarProcesar
    {
        bool AceptarProcesarIsOk { get; }
        void AceptarProcesar();
    }

}