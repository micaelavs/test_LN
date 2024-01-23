namespace proyectoApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_city : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "IdCity", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacts", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Company", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Profile", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Image", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Address", c => c.String(maxLength: 50));
            CreateIndex("dbo.Contacts", "IdCity");
            AddForeignKey("dbo.Contacts", "IdCity", "dbo.Cities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "IdCity", "dbo.Cities");
            DropIndex("dbo.Contacts", new[] { "IdCity" });
            AlterColumn("dbo.Contacts", "Address", c => c.String());
            AlterColumn("dbo.Contacts", "Email", c => c.String());
            AlterColumn("dbo.Contacts", "Image", c => c.String());
            AlterColumn("dbo.Contacts", "Profile", c => c.String());
            AlterColumn("dbo.Contacts", "Company", c => c.String());
            AlterColumn("dbo.Contacts", "Name", c => c.String());
            DropColumn("dbo.Contacts", "IdCity");
            DropTable("dbo.Cities");
        }
    }
}
