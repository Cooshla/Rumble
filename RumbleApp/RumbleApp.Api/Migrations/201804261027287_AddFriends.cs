namespace JamnationApp.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFriends : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendRequests",
                c => new
                    {
                        FriendId = c.Int(nullable: false, identity: true),
                        RequestId = c.String(),
                        ProfileId = c.String(),
                        Accepted = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                        Updated = c.DateTime(),
                        LastEditBy = c.String(),
                        CreatedBy = c.String(),
                        Profile_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.FriendId)
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileId)
                .Index(t => t.Profile_ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendRequests", "Profile_ProfileId", "dbo.Profiles");
            DropIndex("dbo.FriendRequests", new[] { "Profile_ProfileId" });
            DropTable("dbo.FriendRequests");
        }
    }
}
