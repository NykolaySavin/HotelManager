namespace HotelManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Service_Id", c => c.Guid());
            CreateIndex("dbo.Employees", "Service_Id");
            AddForeignKey("dbo.Employees", "Service_Id", "dbo.Services", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Service_Id", "dbo.Services");
            DropIndex("dbo.Employees", new[] { "Service_Id" });
            DropColumn("dbo.Employees", "Service_Id");
        }
    }
}
