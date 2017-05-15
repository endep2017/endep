using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using endep.Models;

namespace endep.Controllers
{
    public class PosicionsController : Controller
    {
        private endepContext db = new endepContext();

        // GET: Posicions
        public ActionResult Index()
        {
            return View(db.Posiciones.ToList());
        }

        // GET: Posicions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicion posicion = db.Posiciones.Find(id);
            if (posicion == null)
            {
                return HttpNotFound();
            }
            return View(posicion);
        }

        // GET: Posicions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posicions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PosicionId,Nombre")] Posicion posicion)
        {
            if (ModelState.IsValid)
            {
                db.Posiciones.Add(posicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(posicion);
        }

        // GET: Posicions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicion posicion = db.Posiciones.Find(id);
            if (posicion == null)
            {
                return HttpNotFound();
            }
            return View(posicion);
        }

        // POST: Posicions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PosicionId,Nombre")] Posicion posicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posicion);
        }

        // GET: Posicions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicion posicion = db.Posiciones.Find(id);
            if (posicion == null)
            {
                return HttpNotFound();
            }
            return View(posicion);
        }

        // POST: Posicions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posicion posicion = db.Posiciones.Find(id);
            db.Posiciones.Remove(posicion);
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
