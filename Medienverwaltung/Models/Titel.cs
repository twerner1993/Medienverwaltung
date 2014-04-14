using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medienverwaltung.Models
{
    public class Titel
    {
        public int TitelId { get; set; }
        public string Name { get; set; }
        public int InterpretId { get; set; }
        public int TypId { get; set; }
        public DateTime Erscheinung { get; set; }
        public string Beschreibung { get; set; }

        public virtual Interpret TitelInterpret { get; set; }
        public virtual Typ TitelTyp { get; set; }
        public virtual ICollection<Kopie> Kopies { get; set; }

    }
}