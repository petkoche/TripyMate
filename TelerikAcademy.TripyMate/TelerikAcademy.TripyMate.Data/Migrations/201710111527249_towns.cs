namespace TelerikAcademy.TripyMate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class towns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EndTowns",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StartTowns",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Posts", "EndTown_ID", c => c.Guid());
            AddColumn("dbo.Posts", "StartTown_ID", c => c.Guid());
            CreateIndex("dbo.Posts", "EndTown_ID");
            CreateIndex("dbo.Posts", "StartTown_ID");
            AddForeignKey("dbo.Posts", "EndTown_ID", "dbo.EndTowns", "ID");
            AddForeignKey("dbo.Posts", "StartTown_ID", "dbo.StartTowns", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "StartTown_ID", "dbo.StartTowns");
            DropForeignKey("dbo.Posts", "EndTown_ID", "dbo.EndTowns");
            DropIndex("dbo.Posts", new[] { "StartTown_ID" });
            DropIndex("dbo.Posts", new[] { "EndTown_ID" });
            DropColumn("dbo.Posts", "StartTown_ID");
            DropColumn("dbo.Posts", "EndTown_ID");
            DropTable("dbo.StartTowns");
            DropTable("dbo.EndTowns");
        }
    }
}
