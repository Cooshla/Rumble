namespace JamnationApp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userid1 : DbMigration
    {
        public override void Up()
        {
            Sql("alter table Profiles drop constraint [DF__Profiles__UserId__6C190EBB]");
            AlterColumn("dbo.Profiles", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "UserId", c => c.Int(nullable: false));
        }
    }
}
