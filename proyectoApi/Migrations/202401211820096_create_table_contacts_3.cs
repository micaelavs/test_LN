namespace proyectoApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_contacts_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Timestamp");
        }
    }
}
