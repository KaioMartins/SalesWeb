namespace SalesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        BaseSalary = c.Double(nullable: false),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.SalesRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        Seller_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sellers", t => t.Seller_Id)
                .Index(t => t.Seller_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesRecords", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.Sellers", "Department_Id", "dbo.Departments");
            DropIndex("dbo.SalesRecords", new[] { "Seller_Id" });
            DropIndex("dbo.Sellers", new[] { "Department_Id" });
            DropTable("dbo.SalesRecords");
            DropTable("dbo.Sellers");
        }
    }
}
