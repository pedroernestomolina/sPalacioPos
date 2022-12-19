using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PROFIT
{

    public partial class pPanEntities : DbContext
    {
        public pPanEntities(string cn)
            : base(cn)
        {
        }
    }

}