using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Medienverwaltung.Models
{
    public class TitelViewModel
    {
        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Interpret")]
        public string Interpret { get; set; } //Name aus Interpret-Model

        [Required]
        [Display(Name="Typ")]
        public string Typ { get; set; }

        public DateTime Erscheinung { get; set; }
        public string Beschreibung { get; set; }
    }
} 