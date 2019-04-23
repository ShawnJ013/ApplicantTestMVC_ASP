namespace ApplicantTestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.line_item",
                c => new
                    {
                        line_item_id = c.Int(nullable: false, identity: true),
                        order_id = c.Int(nullable: false),
                        stock_id = c.Int(nullable: false),
                        description = c.String(),
                        qty = c.Int(nullable: false),
                        date_added = c.DateTime(nullable: false),
                        unit_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.line_item_id)
                .ForeignKey("dbo.orders", t => t.order_id, cascadeDelete: true)
                .ForeignKey("dbo.stocks", t => t.stock_id, cascadeDelete: true)
                .ForeignKey("dbo.units", t => t.unit_id, cascadeDelete: true)
                .Index(t => t.order_id)
                .Index(t => t.stock_id)
                .Index(t => t.unit_id);
            
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        date_created = c.DateTime(nullable: false),
                        date_ordered = c.DateTime(),
                        date_updated = c.DateTime(nullable: false),
                        note = c.String(),
                        user_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.user_id);
            
            CreateTable(
                "dbo.stocks",
                c => new
                    {
                        stock_id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.stock_id);
            
            CreateTable(
                "dbo.units",
                c => new
                    {
                        unit_id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.unit_id);
            
            CreateTable(
                "dbo.unitstocks",
                c => new
                    {
                        unit_unit_id = c.Int(nullable: false),
                        stock_stock_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.unit_unit_id, t.stock_stock_id })
                .ForeignKey("dbo.units", t => t.unit_unit_id, cascadeDelete: true)
                .ForeignKey("dbo.stocks", t => t.stock_stock_id, cascadeDelete: true)
                .Index(t => t.unit_unit_id)
                .Index(t => t.stock_stock_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.line_item", "unit_id", "dbo.units");
            DropForeignKey("dbo.line_item", "stock_id", "dbo.stocks");
            DropForeignKey("dbo.unitstocks", "stock_stock_id", "dbo.stocks");
            DropForeignKey("dbo.unitstocks", "unit_unit_id", "dbo.units");
            DropForeignKey("dbo.line_item", "order_id", "dbo.orders");
            DropForeignKey("dbo.orders", "user_id", "dbo.users");
            DropIndex("dbo.unitstocks", new[] { "stock_stock_id" });
            DropIndex("dbo.unitstocks", new[] { "unit_unit_id" });
            DropIndex("dbo.orders", new[] { "user_id" });
            DropIndex("dbo.line_item", new[] { "unit_id" });
            DropIndex("dbo.line_item", new[] { "stock_id" });
            DropIndex("dbo.line_item", new[] { "order_id" });
            DropTable("dbo.unitstocks");
            DropTable("dbo.units");
            DropTable("dbo.stocks");
            DropTable("dbo.users");
            DropTable("dbo.orders");
            DropTable("dbo.line_item");
        }
    }
}
