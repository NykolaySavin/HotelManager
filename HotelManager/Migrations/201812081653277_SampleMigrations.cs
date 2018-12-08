namespace HotelManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Orders");
            AddColumn("dbo.Orders", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Orders", new[] { "Id", "ClientId", "RoomId", "ServiceTypeId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Orders");
            DropColumn("dbo.Orders", "Id");
            AddPrimaryKey("dbo.Orders", new[] { "ClientId", "RoomId", "ServiceTypeId" });
        }
    }
}
