using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace App.Helpers
{

    public class Utilitis
    {


        static public void CargarXml()
        {
            Sistema.MyServidor= new Sistema.Servidor();
            var doc = new XmlDocument();
            doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Conf.XML");
            if (doc.HasChildNodes)
            {
                foreach (XmlNode nd in doc)
                {
                    if (nd.LocalName.ToUpper().Trim() == "CONFIGURACION")
                    {
                        foreach (XmlNode nv in nd.ChildNodes)
                        {
                            if (nv.LocalName.ToUpper().Trim() == "SERVIDOR")
                            {
                                foreach (XmlNode sv in nv.ChildNodes)
                                {
                                    if (sv.LocalName.Trim().ToUpper() == "INSTANCIA")
                                    {
                                        Sistema.MyServidor.Instancia = sv.InnerText.Trim();
                                    }
                                    if (sv.LocalName.Trim().ToUpper() == "CATALOGO1")
                                    {
                                        Sistema.MyServidor.Catalogo1 = sv.InnerText.Trim();
                                    }
                                    if (sv.LocalName.Trim().ToUpper() == "CATALOGO2")
                                    {
                                        Sistema.MyServidor.Catalogo2 = sv.InnerText.Trim();
                                    }
                                    if (sv.LocalName.Trim().ToUpper() == "USUARIO")
                                    {
                                        Sistema.MyServidor.Usuario = sv.InnerText.Trim();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

}