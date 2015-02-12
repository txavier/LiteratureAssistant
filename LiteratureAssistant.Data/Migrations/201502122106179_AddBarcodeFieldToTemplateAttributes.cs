namespace LiteratureAssistant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBarcodeFieldToTemplateAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.templateAttribute", "barCode", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.templateAttribute", "barCode");
        }
    }
}
