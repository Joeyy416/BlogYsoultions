namespace SimpleBloggingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChangesHappened : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "Category_Id" });
            AlterColumn("dbo.Articles", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "Category_Id");
            AddForeignKey("dbo.Articles", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "Category_Id" });
            AlterColumn("dbo.Articles", "Category_Id", c => c.Int());
            CreateIndex("dbo.Articles", "Category_Id");
            AddForeignKey("dbo.Articles", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
