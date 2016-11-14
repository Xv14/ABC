using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Data.XConventions
{
    public class DateTime2Convention : Convention
    {

        //won't be used in MySQL, in sql server change "datetime" to "datetime2"
        public DateTime2Convention()
        {
            this.Properties<DateTime>().Configure(c => c.HasColumnType("datetime"));
        }


    }
}
