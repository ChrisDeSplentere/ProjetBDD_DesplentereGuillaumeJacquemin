﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppWebEncodageEmploi;

namespace AppWebEncodageEmploi.Controllers
{
    public class EntreprisesController : Controller
    {
        private DBIG3B1Entities db = new DBIG3B1Entities();

        // GET: Entreprises
        public ActionResult Index()
        {
            var entreprises = db.Entreprises.Include(e => e.Localite);
            return View(entreprises.ToList());
        }

        // GET: Entreprises/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entreprise entreprise = db.Entreprises.Find(id);
            if (entreprise == null)
            {
                return HttpNotFound();
            }
            return View(entreprise);
        }

        // GET: Entreprises/Create
        public ActionResult Create()
        {
            ViewBag.IDLocalite = new SelectList(db.Localites, "ID", "Nom");
            return View();
        }

        // POST: Entreprises/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numero,Denomination,NomRue,NumeroRue,NumTel,NbSoumis,NbNonSoumis,IDLocalite")] Entreprise entreprise)
        {
            if (ModelState.IsValid)
            {
                db.Entreprises.Add(entreprise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLocalite = new SelectList(db.Localites, "ID", "Nom", entreprise.IDLocalite);
            return View(entreprise);
        }

        // GET: Entreprises/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entreprise entreprise = db.Entreprises.Find(id);
            if (entreprise == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLocalite = new SelectList(db.Localites, "ID", "Nom", entreprise.IDLocalite);
            return View(entreprise);
        }

        // POST: Entreprises/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numero,Denomination,NomRue,NumeroRue,NumTel,NbSoumis,NbNonSoumis,IDLocalite")] Entreprise entreprise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entreprise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLocalite = new SelectList(db.Localites, "ID", "Nom", entreprise.IDLocalite);
            return View(entreprise);
        }

        // GET: Entreprises/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entreprise entreprise = db.Entreprises.Find(id);
            if (entreprise == null)
            {
                return HttpNotFound();
            }
            return View(entreprise);
        }

        // POST: Entreprises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Entreprise entreprise = db.Entreprises.Find(id);
            db.Entreprises.Remove(entreprise);
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
