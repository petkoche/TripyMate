namespace TelerikAcademy.TripyMate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPicUserPhone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PhotoId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PhotoId");
        }
    }
}
