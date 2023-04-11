using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using petmed.Dal;
using petmed.Models;

namespace petmed.Controllers
{
    public class ProceduresController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Procedures
        public ActionResult Index()
        {
            var procedures = db.Procedures.Include(p => p.Animal).Include(p => p.Veterinarian);
            return View(procedures.ToList());
        }

        // GET: Procedures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }

        // GET: Procedures/Create
        public ActionResult Create()
        {
            ViewBag.AnimalID = new SelectList(db.Animals, "ID", "Name");
            ViewBag.VeterinarianID = new SelectList(db.Veterinarians, "ID", "Name");
            return View();
        }

        // POST: Procedures/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,AdministeredMedication,Date,VeterinarianID,AnimalID")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                db.Procedures.Add(procedure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalID = new SelectList(db.Animals, "ID", "Name", procedure.AnimalID);
            ViewBag.VeterinarianID = new SelectList(db.Veterinarians, "ID", "Matriculation", procedure.VeterinarianID);
            return View(procedure);
        }

        // GET: Procedures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalID = new SelectList(db.Animals, "ID", "Name", procedure.AnimalID);
            ViewBag.VeterinarianID = new SelectList(db.Veterinarians, "ID", "Matriculation", procedure.VeterinarianID);
            return View(procedure);
        }

        // POST: Procedures/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,AdministeredMedication,Date,VeterinarianID,AnimalID")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalID = new SelectList(db.Animals, "ID", "Name", procedure.AnimalID);
            ViewBag.VeterinarianID = new SelectList(db.Veterinarians, "ID", "Matriculation", procedure.VeterinarianID);
            return View(procedure);
        }

        // GET: Procedures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }

        // POST: Procedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Procedure procedure = db.Procedures.Find(id);
            db.Procedures.Remove(procedure);
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
