namespace HotelManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Role = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.InternalUserDatas",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        HashedPassword = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.Employees", t => t.Username)
                .Index(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InternalUserDatas", "Username", "dbo.Employees");
            DropIndex("dbo.InternalUserDatas", new[] { "Username" });
            DropTable("dbo.InternalUserDatas");
            DropTable("dbo.Employees");
        }
    }
}
