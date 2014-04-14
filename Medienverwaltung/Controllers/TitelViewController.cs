using Medienverwaltung.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medienverwaltung.Controllers
{
    [Authorize]
    public class TitelViewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /TitelView/
        public ActionResult Index()
        {
            DbSet<Titel> titels = db.Titels;
            List<TitelViewModel> titelViews = new List<TitelViewModel>();
            foreach (Titel titel in titels)
            {
                TitelViewModel view = new TitelViewModel()
                {
                    Name = titel.Name,
                    Interpret = titel.TitelInterpret.Name,
                    Typ = titel.TitelTyp.TypName,
                    Erscheinung = titel.Erscheinung,
                    Beschreibung = titel.Beschreibung
                };
            }
            return View(titelViews);
        }
	}
}