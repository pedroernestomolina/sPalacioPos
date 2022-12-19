using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MASTER
{

    public partial class masterprofitEntities : DbContext
    {
        public masterprofitEntities(string cn)
            : base(cn)
        {
        }
    }

}