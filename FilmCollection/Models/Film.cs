using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FilmCollection.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Molimo unesite ime filma.")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Molimo unesite godinu filma.")]
        [Range(1800, 2017, ErrorMessage = "Molimo unesite godinu između 1800-te i 2017-e.")]
        public int Godina { get; set; }
        public int ReziserId { get; set; }
        public Reziser Reziser { get; set; }
        public Film()
        {
            
        }
    }
}