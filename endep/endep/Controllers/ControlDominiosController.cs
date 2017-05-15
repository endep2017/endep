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
    [Authorize]
    public class ControlDominiosController : Controller
    {
        private endepContext db = new endepContext();

        // GET: ControlDominios
        public ActionResult Index()
        {
            return View(db.ControlDominios.ToList());
        }

        // GET: ControlDominios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlDominio controlDominio = db.ControlDominios.Find(id);
            if (controlDominio == null)
            {
                return HttpNotFound();
            }
            return View(controlDominio);
        }

        // GET: ControlDominios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControlDominios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DominioId,Descripcion,PadreId,vigente,Abreviatura,Observacion")] ControlDominio controlDominio)
        {
            if (ModelState.IsValid)
            {
                db.ControlDominios.Add(controlDominio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(controlDominio);
        }

        // GET: ControlDominios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlDominio controlDominio = db.ControlDominios.Find(id);
            if (controlDominio == null)
            {
                return HttpNotFound();
            }
            return View(controlDominio);
        }

        // POST: ControlDominios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DominioId,Descripcion,PadreId,vigente,Abreviatura,Observacion")] ControlDominio controlDominio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controlDominio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(controlDominio);
        }

        // GET: ControlDominios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlDominio controlDominio = db.ControlDominios.Find(id);
            if (controlDominio == null)
            {
                return HttpNotFound();
            }
            return View(controlDominio);
        }

        // POST: ControlDominios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ControlDominio controlDominio = db.ControlDominios.Find(id);
            db.ControlDominios.Remove(controlDominio);
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
