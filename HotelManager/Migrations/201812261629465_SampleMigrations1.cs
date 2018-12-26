namespace HotelManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "ServiceType_Id", "dbo.ServiceTypes");
            DropIndex("dbo.Services", new[] { "ServiceType_Id" });
            CreateTable(
                "dbo.ServiceTypeServices",
                c => new
                    {
                        ServiceType_Id = c.Guid(nullable: false),
                        Service_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceType_Id, t.Service_Id })
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Service_Id, cascadeDelete: true)
                .Index(t => t.ServiceType_Id)
                .Index(t => t.Service_Id);
            
            DropColumn("dbo.Services", "ServiceType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "ServiceType_Id", c => c.Guid());
            DropForeignKey("dbo.ServiceTypeServices", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.ServiceTypeServices", "ServiceType_Id", "dbo.ServiceTypes");
            DropIndex("dbo.ServiceTypeServices", new[] { "Service_Id" });
            DropIndex("dbo.ServiceTypeServices", new[] { "ServiceType_Id" });
            DropTable("dbo.ServiceTypeServices");
            CreateIndex("dbo.Services", "ServiceType_Id");
            AddForeignKey("dbo.Services", "ServiceType_Id", "dbo.ServiceTypes", "Id");
        }
    }
}
