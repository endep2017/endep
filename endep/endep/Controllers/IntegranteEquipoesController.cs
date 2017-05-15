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
    public class IntegranteEquipoesController : Controller
    {
        private endepContext db = new endepContext();

        // GET: IntegranteEquipoes
        public ActionResult Index()
        {
            var integrantesEquipos = db.IntegrantesEquipos.Include(i => i.Equipo).Include(i => i.Posicion);
            return View(integrantesEquipos.ToList());
        }

        // GET: IntegranteEquipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntegranteEquipo integranteEquipo = db.IntegrantesEquipos.Find(id);
            if (integranteEquipo == null)
            {
                return HttpNotFound();
            }
            return View(integranteEquipo);
        }

        // GET: IntegranteEquipoes/Create
        public ActionResult Create()
        {
            ViewBag.EquipoId = new SelectList(db.Equipos, "EquipoId", "Nombre");
            ViewBag.PosicionId = new SelectList(db.Posiciones, "PosicionId", "Nombre");
            return View();
        }

        // POST: IntegranteEquipoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IntegranteEquipoId,id,PosicionId,EquipoId")] IntegranteEquipo integranteEquipo)
        {
            if (ModelState.IsValid)
            {
                db.IntegrantesEquipos.Add(integranteEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipoId = new SelectList(db.Equipos, "EquipoId", "Nombre", integranteEquipo.EquipoId);
            ViewBag.PosicionId = new SelectList(db.Posiciones, "PosicionId", "Nombre", integranteEquipo.PosicionId);
            return View(integranteEquipo);
        }

        // GET: IntegranteEquipoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntegranteEquipo integranteEquipo = db.IntegrantesEquipos.Find(id);
            if (integranteEquipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipoId = new SelectList(db.Equipos, "EquipoId", "Nombre", integranteEquipo.EquipoId);
            ViewBag.PosicionId = new SelectList(db.Posiciones, "PosicionId", "Nombre", integranteEquipo.PosicionId);
            return View(integranteEquipo);
        }

        // POST: IntegranteEquipoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IntegranteEquipoId,id,PosicionId,EquipoId")] IntegranteEquipo integranteEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(integranteEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipoId = new SelectList(db.Equipos, "EquipoId", "Nombre", integranteEquipo.EquipoId);
            ViewBag.PosicionId = new SelectList(db.Posiciones, "PosicionId", "Nombre", integranteEquipo.PosicionId);
            return View(integranteEquipo);
        }

        // GET: IntegranteEquipoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IntegranteEquipo integranteEquipo = db.IntegrantesEquipos.Find(id);
            if (integranteEquipo == null)
            {
                return HttpNotFound();
            }
            return View(integranteEquipo);
        }

        // POST: IntegranteEquipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IntegranteEquipo integranteEquipo = db.IntegrantesEquipos.Find(id);
            db.IntegrantesEquipos.Remove(integranteEquipo);
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
