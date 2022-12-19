using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Login
{
    
    public class ImpLogin: ILogin
    {


        private string _codUsu;
        private string _psw;
        private bool _loginIsOk;


        public ImpLogin()
        {
            _codUsu = "";
            _psw = "";
            _loginIsOk=false;
        }


        public void Inicializa()
        {
            _codUsu = "";
            _psw = "";
            _loginIsOk=false;
        }
        LoginFrm frm;
        public void Inicia()
        {
            if (frm == null)
            {
                frm = new LoginFrm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }


        public string GetCodUsu { get { return _codUsu; } }
        public bool LoginIsOk { get { return _loginIsOk; } }
        public void setCodigoUsu(string codUsu)
        {
            _codUsu = codUsu;
        }
        public void setPswUsu(string psw)
        {
            _psw = psw;
        }
        public void VerificarUsuario()
        {
            _loginIsOk=false;
            if (_codUsu.Trim() == "")
                return;
            try
            {
                var r01 = Sistema.MyData.AutenticarUsuario(_codUsu, _psw);
                _loginIsOk = r01.Entidad;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private bool _abandonarIsOk;
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public void AbandonarFicha()
        {
            _abandonarIsOk = true;
        }

    }

}