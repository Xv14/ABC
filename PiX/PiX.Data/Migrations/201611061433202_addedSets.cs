namespace PiX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Guid(nullable: false),
                        Title = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        MediaType = c.Int(nullable: false),
                        User_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        Cin = c.String(unicode: false),
                        Mail = c.String(unicode: false),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Tel = c.Int(nullable: false),
                        Address_Country = c.String(unicode: false),
                        Address_State = c.String(unicode: false),
                        Address_City = c.String(unicode: false),
                        Address_Street = c.String(unicode: false),
                        Address_ZipCode = c.String(unicode: false),
                        Image = c.String(unicode: false),
                        FollowersNumber = c.Int(nullable: false),
                        AgencyName = c.String(unicode: false),
                        Active = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserUsers",
                c => new
                    {
                        User_UserId = c.Guid(nullable: false),
                        User_UserId1 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.User_UserId1 })
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Users", t => t.User_UserId1)
                .Index(t => t.User_UserId)
                .Index(t => t.User_UserId1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.UserUsers", "User_UserId1", "dbo.Users");
            DropForeignKey("dbo.UserUsers", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserUsers", new[] { "User_UserId1" });
            DropIndex("dbo.UserUsers", new[] { "User_UserId" });
            DropIndex("dbo.Posts", new[] { "User_UserId" });
            DropTable("dbo.UserUsers");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
        }
    }
}
