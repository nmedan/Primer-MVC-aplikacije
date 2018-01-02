namespace FilmCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilmMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        Godina = c.Int(nullable: false),
                        ReziserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rezisers", t => t.ReziserId, cascadeDelete: true)
                .Index(t => t.ReziserId);
            
            CreateTable(
                "dbo.Rezisers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        Prezime = c.String(nullable: false),
                        DatumRodjenja = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "ReziserId", "dbo.Rezisers");
            DropIndex("dbo.Films", new[] { "ReziserId" });
            DropTable("dbo.Rezisers");
            DropTable("dbo.Films");
        }
    }
}
