namespace LiteratureAssistant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.count",
                c => new
                    {
                        countId = c.Int(nullable: false, identity: true),
                        itemId = c.Int(nullable: false),
                        received = c.Int(),
                        receivedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        currentlyOnHand = c.Int(),
                        currentlyOnHandDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.countId)
                .ForeignKey("dbo.item", t => t.itemId)
                .Index(t => t.itemId);
            
            CreateTable(
                "dbo.item",
                c => new
                    {
                        itemId = c.Int(nullable: false, identity: true),
                        itemTemplateId = c.Int(nullable: false),
                        parentItemId = c.Int(),
                        childItemId = c.Int(),
                        groupItemId = c.Int(),
                        parentGroupItemId = c.Int(),
                        processItemId = c.Int(),
                        parentProcessItemId = c.Int(),
                    })
                .PrimaryKey(t => t.itemId)
                .ForeignKey("dbo.item", t => t.childItemId)
                .ForeignKey("dbo.item", t => t.groupItemId)
                .ForeignKey("dbo.item", t => t.parentItemId)
                .ForeignKey("dbo.item", t => t.processItemId)
                .ForeignKey("dbo.itemTemplate", t => t.itemTemplateId)
                .Index(t => t.itemTemplateId)
                .Index(t => t.parentItemId)
                .Index(t => t.childItemId)
                .Index(t => t.groupItemId)
                .Index(t => t.processItemId);
            
            CreateTable(
                "dbo.itemAttribute",
                c => new
                    {
                        itemAttributeId = c.Int(nullable: false, identity: true),
                        organizationId = c.Int(),
                        itemId = c.Int(nullable: false),
                        templateAttributeId = c.Int(nullable: false),
                        value = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.itemAttributeId)
                .ForeignKey("dbo.organization", t => t.organizationId)
                .ForeignKey("dbo.templateAttribute", t => t.templateAttributeId)
                .ForeignKey("dbo.item", t => t.itemId)
                .Index(t => t.organizationId)
                .Index(t => t.itemId)
                .Index(t => t.templateAttributeId);
            
            CreateTable(
                "dbo.organization",
                c => new
                    {
                        organizationId = c.Int(nullable: false, identity: true),
                        defaultOrganization = c.Boolean(),
                        name = c.String(),
                        systemName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.organizationId);
            
            CreateTable(
                "dbo.templateAttribute",
                c => new
                    {
                        templateAttributeId = c.Int(nullable: false, identity: true),
                        itemTemplateId = c.Int(nullable: false),
                        templateAttributeName = c.String(nullable: false, maxLength: 50),
                        required = c.Boolean(),
                        priority = c.Int(),
                    })
                .PrimaryKey(t => t.templateAttributeId)
                .ForeignKey("dbo.itemTemplate", t => t.itemTemplateId)
                .Index(t => t.itemTemplateId);
            
            CreateTable(
                "dbo.itemTemplate",
                c => new
                    {
                        itemTemplateId = c.Int(nullable: false, identity: true),
                        itemTemplateName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.itemTemplateId);
            
            CreateTable(
                "dbo.order",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        itemId = c.Int(nullable: false),
                        orderedForUserId = c.Int(nullable: false),
                        orderedByUserId = c.Int(),
                        date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        pending = c.Boolean(),
                        received = c.Boolean(),
                        orderSent = c.Boolean(),
                        quantity = c.Int(),
                        language = c.String(),
                    })
                .PrimaryKey(t => t.orderId)
                .ForeignKey("dbo.user", t => t.orderedByUserId)
                .ForeignKey("dbo.user", t => t.orderedForUserId)
                .ForeignKey("dbo.item", t => t.itemId)
                .Index(t => t.itemId)
                .Index(t => t.orderedForUserId)
                .Index(t => t.orderedByUserId);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        userName = c.String(maxLength: 50),
                        firstName = c.String(nullable: false, maxLength: 50),
                        lastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.order", "itemId", "dbo.item");
            DropForeignKey("dbo.order", "orderedForUserId", "dbo.user");
            DropForeignKey("dbo.order", "orderedByUserId", "dbo.user");
            DropForeignKey("dbo.itemAttribute", "itemId", "dbo.item");
            DropForeignKey("dbo.templateAttribute", "itemTemplateId", "dbo.itemTemplate");
            DropForeignKey("dbo.item", "itemTemplateId", "dbo.itemTemplate");
            DropForeignKey("dbo.itemAttribute", "templateAttributeId", "dbo.templateAttribute");
            DropForeignKey("dbo.itemAttribute", "organizationId", "dbo.organization");
            DropForeignKey("dbo.item", "processItemId", "dbo.item");
            DropForeignKey("dbo.item", "parentItemId", "dbo.item");
            DropForeignKey("dbo.item", "groupItemId", "dbo.item");
            DropForeignKey("dbo.item", "childItemId", "dbo.item");
            DropForeignKey("dbo.count", "itemId", "dbo.item");
            DropIndex("dbo.order", new[] { "orderedByUserId" });
            DropIndex("dbo.order", new[] { "orderedForUserId" });
            DropIndex("dbo.order", new[] { "itemId" });
            DropIndex("dbo.templateAttribute", new[] { "itemTemplateId" });
            DropIndex("dbo.itemAttribute", new[] { "templateAttributeId" });
            DropIndex("dbo.itemAttribute", new[] { "itemId" });
            DropIndex("dbo.itemAttribute", new[] { "organizationId" });
            DropIndex("dbo.item", new[] { "processItemId" });
            DropIndex("dbo.item", new[] { "groupItemId" });
            DropIndex("dbo.item", new[] { "childItemId" });
            DropIndex("dbo.item", new[] { "parentItemId" });
            DropIndex("dbo.item", new[] { "itemTemplateId" });
            DropIndex("dbo.count", new[] { "itemId" });
            DropTable("dbo.user");
            DropTable("dbo.order");
            DropTable("dbo.itemTemplate");
            DropTable("dbo.templateAttribute");
            DropTable("dbo.organization");
            DropTable("dbo.itemAttribute");
            DropTable("dbo.item");
            DropTable("dbo.count");
        }
    }
}
