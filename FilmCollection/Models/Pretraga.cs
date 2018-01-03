using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FilmCollection.Models
{
    public class Pretraga
    {
       
        [Range(1800, 2017, ErrorMessage = "Molimo unesite godinu između 1800-te i 2017-e.")]
        public int? PocetnaGodina { get; set; }
    
       
        [Range(1800, 2017, ErrorMessage = "Molimo unesite godinu između 1800-te i 2017-e.")]
        public int? ZavrsnaGodina { get; set; }
        
        public int? Reziser { get; set; }
    }
}