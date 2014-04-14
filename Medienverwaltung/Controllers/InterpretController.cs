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
    public class InterpretController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Interpret/
        public ActionResult Index()
        {
            return View(db.Interprets.ToList());
        }

        // GET: /Interpret/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interpret interpret = db.Interprets.Find(id);
            if (interpret == null)
            {
                return HttpNotFound();
            }
            return View(interpret);
        }

        // GET: /Interpret/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Interpret/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="InterpretId,Name,Beschreibung,Gruendung")] Interpret interpret)
        {
            if (ModelState.IsValid)
            {
                if (!existsInterpret(interpret.Name))
                {
                    db.Interprets.Add(interpret);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Interpret does already exist!");
            }

            return View(interpret);
        }

        // GET: /Interpret/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interpret interpret = db.Interprets.Find(id);
            if (interpret == null)
            {
                return HttpNotFound();
            }
            return View(interpret);
        }

        // POST: /Interpret/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="InterpretId,Name,Beschreibung,Gruendung")] Interpret interpret)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interpret).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interpret);
        }

        // GET: /Interpret/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interpret interpret = db.Interprets.Find(id);
            if (interpret == null)
            {
                return HttpNotFound();
            }
            return View(interpret);
        }

        // POST: /Interpret/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Interpret interpret = db.Interprets.Find(id);
            db.Interprets.Remove(interpret);
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

        private bool existsInterpret(string Name)
        {
            foreach (Interpret interpret in db.Interprets)
            {
                if (interpret.Name == Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
