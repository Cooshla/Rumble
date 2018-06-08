namespace JamnationApp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intNotString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FriendRequests", "Profile_ProfileId", "dbo.Profiles");
            DropIndex("dbo.FriendRequests", new[] { "Profile_ProfileId" });
            DropColumn("dbo.FriendRequests", "ProfileId");
            RenameColumn(table: "dbo.FriendRequests", name: "Profile_ProfileId", newName: "ProfileId");
            AlterColumn("dbo.FriendRequests", "RequestId", c => c.Int(nullable: false));
            AlterColumn("dbo.FriendRequests", "ProfileId", c => c.Int(nullable: false));
            AlterColumn("dbo.FriendRequests", "ProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.FriendRequests", "ProfileId");
            AddForeignKey("dbo.FriendRequests", "ProfileId", "dbo.Profiles", "ProfileId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendRequests", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.FriendRequests", new[] { "ProfileId" });
            AlterColumn("dbo.FriendRequests", "ProfileId", c => c.Int());
            AlterColumn("dbo.FriendRequests", "ProfileId", c => c.String());
            AlterColumn("dbo.FriendRequests", "RequestId", c => c.String());
            RenameColumn(table: "dbo.FriendRequests", name: "ProfileId", newName: "Profile_ProfileId");
            AddColumn("dbo.FriendRequests", "ProfileId", c => c.String());
            CreateIndex("dbo.FriendRequests", "Profile_ProfileId");
            AddForeignKey("dbo.FriendRequests", "Profile_ProfileId", "dbo.Profiles", "ProfileId");
        }
    }
}
