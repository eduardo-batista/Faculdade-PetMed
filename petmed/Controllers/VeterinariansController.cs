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
    public class VeterinariansController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Veterinarians
        public ActionResult Index()
        {
            return View(db.Veterinarians.ToList());
        }

        // GET: Veterinarians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinarian veterinarian = db.Veterinarians.Find(id);
            if (veterinarian == null)
            {
                return HttpNotFound();
            }
            return View(veterinarian);
        }

        // GET: Veterinarians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veterinarians/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Matriculation,Crmv,Name,Cpf,Phone,Address,BirthDate")] Veterinarian veterinarian)
        {
            if (ModelState.IsValid)
            {
                db.Veterinarians.Add(veterinarian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(veterinarian);
        }

        // GET: Veterinarians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinarian veterinarian = db.Veterinarians.Find(id);
            if (veterinarian == null)
            {
                return HttpNotFound();
            }
            return View(veterinarian);
        }

        // POST: Veterinarians/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Matriculation,Crmv,Name,Cpf,Phone,Address,BirthDate")] Veterinarian veterinarian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veterinarian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinarian);
        }

        // GET: Veterinarians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinarian veterinarian = db.Veterinarians.Find(id);
            if (veterinarian == null)
            {
                return HttpNotFound();
            }
            return View(veterinarian);
        }

        // POST: Veterinarians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veterinarian veterinarian = db.Veterinarians.Find(id);
            db.Veterinarians.Remove(veterinarian);
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
