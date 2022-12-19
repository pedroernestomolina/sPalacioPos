using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Imprimir
{

    public interface IDocumento
    {
        void setData(data ds);
        void ImprimirDoc();
        void ImprimirCopiaDoc();
        bool IsModoTicket { get; }

        void setControlador(System.Drawing.Printing.PrintPageEventArgs e);
        void setDatosEmpresa(string rifEmp, string nombreEmp, string dirEmp, string telEmp);
    }

}