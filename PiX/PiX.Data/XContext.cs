using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using PiX.Data.XConventions;
using PiX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiX.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class XContext : IdentityDbContext<User, MyRole, int, MyLogin, MyUserRole, MyClaim>
    {
        public XContext()
            : base("Name=Xbook")
        {
            //Database.SetInitializer<XContext>(new FTFContextInitializer());
        }

        //to be removed maybe
        public static XContext Create()
        {
            return new XContext();
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Comment> Comments { get; set; }

        //Complete the rest of DbSets

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //If you want to remove all Convetions and work only with configuration :
            //  modelBuilder.Conventions.Remove<IncludeMetadataConvention>();


            base.OnModelCreating(modelBuilder);
            // Map Entities to their tables.
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<MyRole>().ToTable("Role");
            modelBuilder.Entity<MyClaim>().ToTable("UserClaim");
            modelBuilder.Entity<MyLogin>().ToTable("UserLogin");
            modelBuilder.Entity<MyUserRole>().ToTable("UserRole");
            // Set AutoIncrement-Properties
            modelBuilder.Entity<User>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<MyClaim>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<MyRole>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // Override some column mappings that do not match our default
            modelBuilder.Entity<User>().Property(r => r.UserName).HasColumnName("Login");
            modelBuilder.Entity<User>().Property(r => r.PasswordHash).HasColumnName("Password");
        }

    }
}
