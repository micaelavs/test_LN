namespace proyectoApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_contacts_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Contacts", new[] { "Contact_Id" });
            DropColumn("dbo.Contacts", "Contact_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Contact_Id", c => c.Int());
            CreateIndex("dbo.Contacts", "Contact_Id");
            AddForeignKey("dbo.Contacts", "Contact_Id", "dbo.Contacts", "Id");
        }
    }
}
