using PiX.Domain.Entities;
using PiX.ServicePatterns.GenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiX.Data.XInfrastructure;

namespace PiX.Services.Posts
{
    public class PostService : Service<Post>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public PostService() : base(ut)
        {
        }
    }
}
