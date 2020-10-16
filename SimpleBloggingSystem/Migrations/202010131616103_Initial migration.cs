namespace SimpleBloggingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublishingDate = c.DateTime(nullable: false),
                        ArticleBody = c.String(nullable: false),
                        ArticleOwner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ArticleOwner_Id, cascadeDelete: false)
                .Index(t => t.ArticleOwner_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentDate = c.DateTime(nullable: false),
                        CommentBody = c.String(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        Article_Id = c.Int(nullable: false),
                        CommentOwner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.CommentOwner_Id, cascadeDelete: false)
                .Index(t => t.Article_Id)
                .Index(t => t.CommentOwner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "CommentOwner_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Articles", "ArticleOwner_Id", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "CommentOwner_Id" });
            DropIndex("dbo.Comments", new[] { "Article_Id" });
            DropIndex("dbo.Articles", new[] { "ArticleOwner_Id" });
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Articles");
        }
    }
}
