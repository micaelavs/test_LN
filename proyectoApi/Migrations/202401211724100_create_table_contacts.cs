namespace proyectoApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_contacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Company = c.String(),
                        Profile = c.String(),
                        Image = c.String(),
                        Email = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        PhoneNumber_Personal = c.String(),
                        PhoneNumber_Work = c.String(),
                        Address = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Contacts", new[] { "Contact_Id" });
            DropTable("dbo.Contacts");
        }
    }
}
