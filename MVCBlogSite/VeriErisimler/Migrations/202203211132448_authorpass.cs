namespace VeriErisimler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorpass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "AuthorPassword");
        }
    }
}
