namespace FilmCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilmCollectionMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rezisers", "DatumRodjenja", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rezisers", "DatumRodjenja", c => c.DateTime());
        }
    }
}
