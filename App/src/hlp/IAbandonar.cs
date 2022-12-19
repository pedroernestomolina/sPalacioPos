using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.hlp
{
    
    public interface IAbandonar
    {
        bool AbandonarIsOk { get; }
        void AbandonarFicha();
    }

}