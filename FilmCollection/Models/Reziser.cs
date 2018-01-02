using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FilmCollection.Models
{
    public class Reziser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Molimo unesite ime režisera.")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Molimo unesite prezime režisera.")]
        public string Prezime { get; set; }
        [Required]
        [RegularExpression("\\d{4}-\\d{2}-\\d{2}", ErrorMessage = "Molimo da unesete datum u pravilnom formatu (godina\\mesec\\dan).")]
        public string DatumRodjenja { get; set; }

        public Reziser()
        {

        }
    }
}