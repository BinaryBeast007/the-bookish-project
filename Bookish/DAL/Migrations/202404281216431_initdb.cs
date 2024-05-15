namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RiderId = c.Int(nullable: false),
                        ReviewDate = c.DateTime(nullable: false),
                        rating = c.Int(nullable: false),
                        review_text = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Riders", t => t.RiderId, cascadeDelete: true)
                .Index(t => t.RiderId);
            
            CreateTable(
                "dbo.Riders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        AvailabilityStatus = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "RiderId", "dbo.Riders");
            DropIndex("dbo.Reviews", new[] { "RiderId" });
            DropTable("dbo.Riders");
            DropTable("dbo.Reviews");
        }
    }
}
