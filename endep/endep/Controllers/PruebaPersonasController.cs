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
    public class PruebaPersonasController : Controller
    {
        private endepContext db = new endepContext();

        // GET: PruebaPersonas
        public ActionResult Index()
        {
            var pruebaPersona = db.PruebaPersona.Include(p => p.TipoDocumento);
            return View(pruebaPersona.ToList());
        }

        // GET: PruebaPersonas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PruebaPersona pruebaPersona = db.PruebaPersona.Find(id);
            if (pruebaPersona == null)
            {
                return HttpNotFound();
            }
            return View(pruebaPersona);
        }

        // GET: PruebaPersonas/Create
        public ActionResult Create()
        {
            ViewBag.DocumentoId = new SelectList(db.TipoDocumentoes, "DocumentoId", "Descripcion");
            return View();
        }

        // POST: PruebaPersonas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PesonaId,Nombres,Apellidos,Identificacion,DocumentoId")] PruebaPersona pruebaPersona)
        {
            if (ModelState.IsValid)
            {
                db.PruebaPersona.Add(pruebaPersona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            ViewBag.DocumentoId = new SelectList(db.TipoDocumentoes, "DocumentoId", "Descripcion", pruebaPersona.DocumentoId);
            return View(pruebaPersona);
        }

        // GET: PruebaPersonas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PruebaPersona pruebaPersona = db.PruebaPersona.Find(id);
            if (pruebaPersona == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentoId = new SelectList(db.TipoDocumentoes, "DocumentoId", "Descripcion", pruebaPersona.DocumentoId);
            return View(pruebaPersona);
        }

        // POST: PruebaPersonas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PesonaId,Nombres,Apellidos,Identificacion,DocumentoId")] PruebaPersona pruebaPersona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pruebaPersona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocumentoId = new SelectList(db.TipoDocumentoes, "DocumentoId", "Descripcion", pruebaPersona.DocumentoId);
            return View(pruebaPersona);
        }

        // GET: PruebaPersonas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PruebaPersona pruebaPersona = db.PruebaPersona.Find(id);
            if (pruebaPersona == null)
            {
                return HttpNotFound();
            }
            return View(pruebaPersona);
        }

        // POST: PruebaPersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PruebaPersona pruebaPersona = db.PruebaPersona.Find(id);
            db.PruebaPersona.Remove(pruebaPersona);
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
