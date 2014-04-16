using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medienverwaltung.Models;

namespace Medienverwaltung.Controllers
{
    public class TitelViewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /TitelView/
        public ActionResult Index()
        {
            var titels = db.Titels.Include(t => t.TitelTyp).Include(t => t.TitelInterpret);

            var titelviewmodels = new List<TitelViewModel>();

            foreach (var item in titels)
            {
                TitelViewModel tvm = new TitelViewModel
                {
                    Name = item.Name,
                    Interpret = item.TitelInterpret.Name,
                    Typ = item.TitelTyp,
                    Erscheinung = item.Erscheinung,
                    Beschreibung = item.Beschreibung
                };
                titelviewmodels.Add(tvm);
            }

            return View(titelviewmodels.ToList());
        }

        // GET: /TitelView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitelViewModel titelviewmodel = db.TitelViewModels.Find(id);
            if (titelviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(titelviewmodel);
        }

        // GET: /TitelView/Create
        public ActionResult Create()
        {
            ViewBag.TypId = new SelectList(db.Typs, "TypId", "TypName");
            return View();
        }

        // POST: /TitelView/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TitelId,Name,Interpret,TypId,Erscheinung,Beschreibung")] TitelViewModel titelviewmodel)
        {
            if (ModelState.IsValid)
            {
                
                if (!new InterpretController().Exists(titelviewmodel.Interpret))
                {
                    new InterpretController().Create(new Interpret { Name = titelviewmodel.Interpret, Gruendung = new DateTime(1900,1,1) });
                 
                }
                Interpret interpret = db.Interprets.Where(i => i.Name == titelviewmodel.Interpret).Single();
                Typ typ = db.Typs.Where(t => t.TypId == titelviewmodel.TypId).Single();

                Titel titel = new Titel
                {
                    Name = titelviewmodel.Name,
                    TitelInterpret = interpret,
                    TitelTyp = typ,
                    Erscheinung = titelviewmodel.Erscheinung,
                    Beschreibung = titelviewmodel.Beschreibung
                };

                //db.TitelViewModels.Add(titelviewmodel);
                //db.SaveChanges();
                db.Titels.Add(titel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypId = new SelectList(db.Typs, "TypId", "TypName", titelviewmodel.TypId);
            return View(titelviewmodel);
        }

        // GET: /TitelView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitelViewModel titelviewmodel = db.TitelViewModels.Find(id);
            if (titelviewmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypId = new SelectList(db.Typs, "TypId", "TypName", titelviewmodel.TypId);
            return View(titelviewmodel);
        }

        // POST: /TitelView/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TitelId,Name,Interpret,TypId,Erscheinung,Beschreibung")] TitelViewModel titelviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(titelviewmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypId = new SelectList(db.Typs, "TypId", "TypName", titelviewmodel.TypId);
            return View(titelviewmodel);
        }

        // GET: /TitelView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitelViewModel titelviewmodel = db.TitelViewModels.Find(id);
            if (titelviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(titelviewmodel);
        }

        // POST: /TitelView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TitelViewModel titelviewmodel = db.TitelViewModels.Find(id);
            db.TitelViewModels.Remove(titelviewmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
