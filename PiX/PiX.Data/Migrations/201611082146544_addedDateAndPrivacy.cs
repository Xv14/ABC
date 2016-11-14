namespace PiX.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDateAndPrivacy : DbMigration
    {
        public override void Up()
        {
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
                        Password = c.String(unicode: false),
                        AgencyName = c.String(unicode: false),
                        Active = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Criteria",
                c => new
                    {
                        CriteriaId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        User_UserId = c.Guid(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CriteriaId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.User_UserId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.WitnessCards",
                c => new
                    {
                        idWitnessCard = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false, unicode: false),
                        etat = c.Int(),
                        idAgent = c.Int(),
                        address_Country = c.String(unicode: false),
                        address_State = c.String(unicode: false),
                        address_City = c.String(unicode: false),
                        address_Street = c.String(unicode: false),
                        address_ZipCode = c.String(unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        category_CategoryId = c.Int(),
                        agent_UserId = c.Guid(),
                        User_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.idWitnessCard)
                .ForeignKey("dbo.Categories", t => t.category_CategoryId)
                .ForeignKey("dbo.Users", t => t.agent_UserId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.category_CategoryId)
                .Index(t => t.agent_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Etat = c.Int(nullable: false),
                        Card_idWitnessCard = c.Int(),
                        Post_PostId = c.Int(),
                        User_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.WitnessCards", t => t.Card_idWitnessCard)
                .ForeignKey("dbo.Posts", t => t.Post_PostId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Card_idWitnessCard)
                .Index(t => t.Post_PostId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        idEvenement = c.Int(nullable: false, identity: true),
                        nameEvent = c.String(unicode: false),
                        description = c.String(unicode: false),
                        idAgent = c.Int(nullable: false),
                        agent_UserId = c.Guid(),
                        Card_idWitnessCard = c.Int(),
                    })
                .PrimaryKey(t => t.idEvenement)
                .ForeignKey("dbo.Users", t => t.agent_UserId)
                .ForeignKey("dbo.WitnessCards", t => t.Card_idWitnessCard)
                .Index(t => t.agent_UserId)
                .Index(t => t.Card_idWitnessCard);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        PostDateTime = c.DateTime(nullable: false, precision: 0),
                        Privacy = c.Int(nullable: false),
                        Image = c.String(unicode: false),
                        User_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.EventUsers",
                c => new
                    {
                        Event_idEvenement = c.Int(nullable: false),
                        User_UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_idEvenement, t.User_UserId })
                .ForeignKey("dbo.Events", t => t.Event_idEvenement, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Event_idEvenement)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.WitnessCardTreatedUsers",
                c => new
                    {
                        WitnessCardTreated_idWitnessCard = c.Int(nullable: false),
                        User_UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.WitnessCardTreated_idWitnessCard, t.User_UserId })
                .ForeignKey("dbo.WitnessCards", t => t.WitnessCardTreated_idWitnessCard, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.WitnessCardTreated_idWitnessCard)
                .Index(t => t.User_UserId);
            
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
            DropForeignKey("dbo.Criteria", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.WitnessCards", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.UserUsers", "User_UserId1", "dbo.Users");
            DropForeignKey("dbo.UserUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "Card_idWitnessCard", "dbo.WitnessCards");
            DropForeignKey("dbo.WitnessCardTreatedUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.WitnessCardTreatedUsers", "WitnessCardTreated_idWitnessCard", "dbo.WitnessCards");
            DropForeignKey("dbo.EventUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.EventUsers", "Event_idEvenement", "dbo.Events");
            DropForeignKey("dbo.Events", "Card_idWitnessCard", "dbo.WitnessCards");
            DropForeignKey("dbo.Events", "agent_UserId", "dbo.Users");
            DropForeignKey("dbo.WitnessCards", "agent_UserId", "dbo.Users");
            DropForeignKey("dbo.Criteria", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.WitnessCards", "category_CategoryId", "dbo.Categories");
            DropIndex("dbo.UserUsers", new[] { "User_UserId1" });
            DropIndex("dbo.UserUsers", new[] { "User_UserId" });
            DropIndex("dbo.WitnessCardTreatedUsers", new[] { "User_UserId" });
            DropIndex("dbo.WitnessCardTreatedUsers", new[] { "WitnessCardTreated_idWitnessCard" });
            DropIndex("dbo.EventUsers", new[] { "User_UserId" });
            DropIndex("dbo.EventUsers", new[] { "Event_idEvenement" });
            DropIndex("dbo.Posts", new[] { "User_UserId" });
            DropIndex("dbo.Events", new[] { "Card_idWitnessCard" });
            DropIndex("dbo.Events", new[] { "agent_UserId" });
            DropIndex("dbo.Comments", new[] { "User_UserId" });
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropIndex("dbo.Comments", new[] { "Card_idWitnessCard" });
            DropIndex("dbo.WitnessCards", new[] { "User_UserId" });
            DropIndex("dbo.WitnessCards", new[] { "agent_UserId" });
            DropIndex("dbo.WitnessCards", new[] { "category_CategoryId" });
            DropIndex("dbo.Criteria", new[] { "Category_CategoryId" });
            DropIndex("dbo.Criteria", new[] { "User_UserId" });
            DropTable("dbo.UserUsers");
            DropTable("dbo.WitnessCardTreatedUsers");
            DropTable("dbo.EventUsers");
            DropTable("dbo.Posts");
            DropTable("dbo.Events");
            DropTable("dbo.Comments");
            DropTable("dbo.WitnessCards");
            DropTable("dbo.Categories");
            DropTable("dbo.Criteria");
            DropTable("dbo.Users");
        }
    }
}
