using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FilmCollection.Models
{
    public class Reziser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Molimo unesite ime režisera.")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Molimo unesite prezime režisera.")]
        public string Prezime { get; set; }
        
        [Required(ErrorMessage = "Molimo unesite datum rođenja režisera")]
        [DataType(DataType.Date, ErrorMessage = "Molimo unesite datum u ispravnom obliku.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatumRodjenja { get; set; }
        [NotMapped]
        public string PunoIme
        {
            get
            {
                return Ime + " " + Prezime;
            }
        }
        public Reziser()
        {

        }
    }
}