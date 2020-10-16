namespace SimpleBloggingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReasonColumnAddedToCommentsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "reasonForDisApproval", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "reasonForDisApproval");
        }
    }
}
