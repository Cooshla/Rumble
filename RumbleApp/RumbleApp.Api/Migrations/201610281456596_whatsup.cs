namespace RumbleApp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatsup : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Created", c => c.DateTime());
            AlterColumn("dbo.Events", "Updated", c => c.DateTime());
            AlterColumn("dbo.Locations", "Created", c => c.DateTime());
            AlterColumn("dbo.Locations", "Updated", c => c.DateTime());
            AlterColumn("dbo.NotificationTags", "Created", c => c.DateTime());
            AlterColumn("dbo.NotificationTags", "Updated", c => c.DateTime());
            AlterColumn("dbo.Devices", "Created", c => c.DateTime());
            AlterColumn("dbo.Devices", "Updated", c => c.DateTime());
            AlterColumn("dbo.Profiles", "Created", c => c.DateTime());
            AlterColumn("dbo.Profiles", "Updated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "Updated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Profiles", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Devices", "Updated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Devices", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.NotificationTags", "Updated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.NotificationTags", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Locations", "Updated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Locations", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Updated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Created", c => c.DateTime(nullable: false));
        }
    }
}
