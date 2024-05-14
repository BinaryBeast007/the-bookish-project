namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TKey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        BuyerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyers", t => t.BuyerId, cascadeDelete: true)
                .Index(t => t.BuyerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "BuyerId", "dbo.Buyers");
            DropIndex("dbo.Tokens", new[] { "BuyerId" });
            DropTable("dbo.Tokens");
        }
    }
}
