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
    public class LugarGeograficoesController : Controller
    {
        private endepContext db = new endepContext();

        // GET: LugarGeograficoes
        public ActionResult Index()
        {
            return View(db.LugaresGeograficos.ToList());
        }

        // GET: LugarGeograficoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LugarGeografico lugarGeografico = db.LugaresGeograficos.Find(id);
            if (lugarGeografico == null)
            {
                return HttpNotFound();
            }
            return View(lugarGeografico);
        }

        // GET: LugarGeograficoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LugarGeograficoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LugarId,Descripcion,PadreId")] LugarGeografico lugarGeografico)
        {
            if (ModelState.IsValid)
            {
                db.LugaresGeograficos.Add(lugarGeografico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lugarGeografico);
        }

        // GET: LugarGeograficoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LugarGeografico lugarGeografico = db.LugaresGeograficos.Find(id);
            if (lugarGeografico == null)
            {
                return HttpNotFound();
            }
            return View(lugarGeografico);
        }

        // POST: LugarGeograficoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LugarId,Descripcion,PadreId")] LugarGeografico lugarGeografico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lugarGeografico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lugarGeografico);
        }

        // GET: LugarGeograficoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LugarGeografico lugarGeografico = db.LugaresGeograficos.Find(id);
            if (lugarGeografico == null)
            {
                return HttpNotFound();
            }
            return View(lugarGeografico);
        }

        // POST: LugarGeograficoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LugarGeografico lugarGeografico = db.LugaresGeograficos.Find(id);
            db.LugaresGeograficos.Remove(lugarGeografico);
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
