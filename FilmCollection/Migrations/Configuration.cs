namespace FilmCollection.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FilmCollection.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<FilmCollection.Models.FilmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FilmCollection.Models.FilmContext context)
        {
            context.Reziseri.AddOrUpdate(x => x.Id,
             new Reziser() { Id = 1,  Ime = "Marko", Prezime = "Markovic", DatumRodjenja="1965-10-20"},
             new Reziser() { Id = 2,  Ime = "Jovan", Prezime = "Jovanovic", DatumRodjenja="1958-09-05" },
             new Reziser() { Id = 3,  Ime = "Ilija", Prezime = "Ilic", DatumRodjenja="1969-08-12" }
             );

            context.Filmovi.AddOrUpdate(x => x.Id,
               new Film() { Id = 1, Ime="Film 1", Godina=2012, ReziserId=1},
               new Film() { Id = 2, Ime="Film 2", Godina=2010, ReziserId=2},
               new Film() { Id = 3, Ime="Film 3", Godina=2014, ReziserId=3}
               );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
