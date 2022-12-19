using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.src.Venta
{

    public interface ICajaItem: hlp.ILista
    {

        void setData(List<dataItem> list);

    }

}
