using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Medienverwaltung.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtstag { get; set; }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<Medienverwaltung.Models.Typ> Typs { get; set; }

        public System.Data.Entity.DbSet<Medienverwaltung.Models.Interpret> Interprets { get; set; }

        public System.Data.Entity.DbSet<Medienverwaltung.Models.Titel> Titels { get; set; }

        public System.Data.Entity.DbSet<Medienverwaltung.Models.Kopie> Kopies { get; set; }

        public System.Data.Entity.DbSet<Medienverwaltung.Models.TitelViewModel> TitelViewModels { get; set; }

    }
}