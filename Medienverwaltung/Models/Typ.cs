using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medienverwaltung.Models
{
    public class Typ
    {
        public int TypId { get; set; }
        public string TypName { get; set; }

        public virtual ICollection<Titel> Titels { get; set; }
    }
}