using App.src.hlp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Login
{

    public interface ILogin: IGestion, IAbandonar
    {
        void setCodigoUsu(string codUsu);
        void setPswUsu(string psw);
        void VerificarUsuario();
        bool LoginIsOk { get; }
        string GetCodUsu { get; }
    }

}
