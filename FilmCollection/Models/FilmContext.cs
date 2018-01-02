using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace FilmCollection.Models
{
    public class FilmContext : DbContext
    {
        public DbSet<Film> Filmovi { get; set; }
        public DbSet<Reziser> Reziseri { get; set; }
        
        public FilmContext() : base("name=FilmContext")
        {

        }
    }
}