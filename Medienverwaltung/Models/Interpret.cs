using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medienverwaltung.Models
{
    public class Interpret
    {
        public int InterpretId { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public DateTime Gruendung { get; set; }
    }
}