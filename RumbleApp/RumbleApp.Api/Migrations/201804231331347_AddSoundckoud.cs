namespace JamnationApp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSoundckoud : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "SoundCloud", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "SoundCloud");
        }
    }
}
