namespace TelerikAcademy.TripyMate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _234535 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StartTowns", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.StartTowns", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.StartTowns", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.StartTowns", "DeletedOn", c => c.DateTime());
            CreateIndex("dbo.StartTowns", "IsDeleted");
        }
        
        public override void Down()
        {
            DropIndex("dbo.StartTowns", new[] { "IsDeleted" });
            DropColumn("dbo.StartTowns", "DeletedOn");
            DropColumn("dbo.StartTowns", "ModifiedOn");
            DropColumn("dbo.StartTowns", "CreatedOn");
            DropColumn("dbo.StartTowns", "IsDeleted");
        }
    }
}
