namespace TelerikAcademy.TripyMate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingforeignkeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "EndTown_ID", "dbo.EndTowns");
            DropForeignKey("dbo.Posts", "StartTown_ID", "dbo.StartTowns");
            DropIndex("dbo.Posts", new[] { "EndTown_ID" });
            DropIndex("dbo.Posts", new[] { "StartTown_ID" });
            RenameColumn(table: "dbo.Posts", name: "EndTown_ID", newName: "EndTownId");
            RenameColumn(table: "dbo.Posts", name: "StartTown_ID", newName: "StartTownId");
            AddColumn("dbo.EndTowns", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.EndTowns", "CreatedOn", c => c.DateTime());
            AddColumn("dbo.EndTowns", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.EndTowns", "DeletedOn", c => c.DateTime());
            AlterColumn("dbo.Posts", "EndTownId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Posts", "StartTownId", c => c.Guid(nullable: false));
            CreateIndex("dbo.EndTowns", "IsDeleted");
            CreateIndex("dbo.Posts", "StartTownId");
            CreateIndex("dbo.Posts", "EndTownId");
            AddForeignKey("dbo.Posts", "EndTownId", "dbo.EndTowns", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "StartTownId", "dbo.StartTowns", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "StartTownId", "dbo.StartTowns");
            DropForeignKey("dbo.Posts", "EndTownId", "dbo.EndTowns");
            DropIndex("dbo.Posts", new[] { "EndTownId" });
            DropIndex("dbo.Posts", new[] { "StartTownId" });
            DropIndex("dbo.EndTowns", new[] { "IsDeleted" });
            AlterColumn("dbo.Posts", "StartTownId", c => c.Guid());
            AlterColumn("dbo.Posts", "EndTownId", c => c.Guid());
            DropColumn("dbo.EndTowns", "DeletedOn");
            DropColumn("dbo.EndTowns", "ModifiedOn");
            DropColumn("dbo.EndTowns", "CreatedOn");
            DropColumn("dbo.EndTowns", "IsDeleted");
            RenameColumn(table: "dbo.Posts", name: "StartTownId", newName: "StartTown_ID");
            RenameColumn(table: "dbo.Posts", name: "EndTownId", newName: "EndTown_ID");
            CreateIndex("dbo.Posts", "StartTown_ID");
            CreateIndex("dbo.Posts", "EndTown_ID");
            AddForeignKey("dbo.Posts", "StartTown_ID", "dbo.StartTowns", "ID");
            AddForeignKey("dbo.Posts", "EndTown_ID", "dbo.EndTowns", "ID");
        }
    }
}
