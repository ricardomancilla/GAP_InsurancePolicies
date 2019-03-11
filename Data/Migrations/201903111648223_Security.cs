namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Security : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "PasswordHash", c => c.Binary());
            AddColumn("dbo.User", "PasswordSalt", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "PasswordSalt");
            DropColumn("dbo.User", "PasswordHash");
        }
    }
}
