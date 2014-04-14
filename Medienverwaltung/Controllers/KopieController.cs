﻿using System;
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
    public class KopieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Kopie/
        public ActionResult Index()
        {
            var kopies = db.Kopies.Include(k => k.Titel);
            return View(kopies.ToList());
        }

        // GET: /Kopie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kopie kopie = db.Kopies.Find(id);
            if (kopie == null)
            {
                return HttpNotFound();
            }
            return View(kopie);
        }

        // GET: /Kopie/Create
        public ActionResult Create()
        {
            ViewBag.TitelId = new SelectList(db.Titels, "TitelId", "Name");
            return View();
        }

        // POST: /Kopie/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="KopieId,TitelId,BenutzerId,Typ")] Kopie kopie)
        {
            if (ModelState.IsValid)
            {
                db.Kopies.Add(kopie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TitelId = new SelectList(db.Titels, "TitelId", "Name", kopie.TitelId);
            return View(kopie);
        }

        // GET: /Kopie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kopie kopie = db.Kopies.Find(id);
            if (kopie == null)
            {
                return HttpNotFound();
            }
            ViewBag.TitelId = new SelectList(db.Titels, "TitelId", "Name", kopie.TitelId);
            return View(kopie);
        }

        // POST: /Kopie/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="KopieId,TitelId,BenutzerId,Typ")] Kopie kopie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kopie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TitelId = new SelectList(db.Titels, "TitelId", "Name", kopie.TitelId);
            return View(kopie);
        }

        // GET: /Kopie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kopie kopie = db.Kopies.Find(id);
            if (kopie == null)
            {
                return HttpNotFound();
            }
            return View(kopie);
        }

        // POST: /Kopie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kopie kopie = db.Kopies.Find(id);
            db.Kopies.Remove(kopie);
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
