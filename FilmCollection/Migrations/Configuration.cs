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
           new Reziser() { Id = 1, Ime = "Marko", Prezime = "Markovic", DatumRodjenja = new DateTime(1970, 9, 1).Date},
           new Reziser() { Id = 2, Ime = "Jovan", Prezime = "Jovanovic", DatumRodjenja = new DateTime(1965, 8, 5).Date},
           new Reziser() { Id = 3, Ime = "Ilija", Prezime = "Ilic", DatumRodjenja = new DateTime(1967, 9, 5).Date }
           );

            context.Filmovi.AddOrUpdate(x => x.Id,
               new Film() { Id = 1, Ime = "Film1", Godina = 2012, ReziserId = 1 },
               new Film() { Id = 2, Ime = "Film2", Godina = 2013, ReziserId = 2 },
               new Film() { Id = 3, Ime = "Film3", Godina = 2014, ReziserId = 3 }
               );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
