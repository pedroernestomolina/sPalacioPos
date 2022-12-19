using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.OOB
{

    public class Resultado
    {
        public Enumerados.EnumResult  Result { get; set; }
        public string Mensaje { get; set; }

        public Resultado()
        {
            Result = Enumerados.EnumResult.isOk ;
            Mensaje = "";
        }
    }

}