using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Data.XInfrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private XContext dataContext;
        public XContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new XContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
