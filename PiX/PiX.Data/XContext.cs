using MySql.Data.Entity;
using PiX.Data.XConventions;
using PiX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class XContext : DbContext
    {
        public XContext()
            : base("Name=Xbook")
        {
            //Database.SetInitializer<XContext>(new FTFContextInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Comment> Comments { get; set; }

        //Complete the rest of DbSets

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //If you want to remove all Convetions and work only with configuration :
            //  modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Add(new DateTime2Convention());
        }

    }
}
