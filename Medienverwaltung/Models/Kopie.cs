using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medienverwaltung.Models
{
    public class Kopie
    {
        public int KopieId { get; set; }
        public int TitelId { get; set; }
        public string Typ { get; set; }

        public virtual Titel Titel { get; set; }
        public virtual ApplicationUser UserProfile { get; set; }
    }
}