namespace WorldData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOwnerToOwnerIdInChart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Charts", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Charts", new[] { "Owner_Id" });
            AddColumn("dbo.Charts", "OwnerId", c => c.String());
            DropColumn("dbo.Charts", "Owner_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Charts", "Owner_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Charts", "OwnerId");
            CreateIndex("dbo.Charts", "Owner_Id");
            AddForeignKey("dbo.Charts", "Owner_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
