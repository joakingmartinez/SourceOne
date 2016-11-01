using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SourceOneDental.BO;

namespace SourceOneDental.UI.Controllers
{
    public class UserRolsController : BaseController
    {
        private SourceOneDentalEntities db = new SourceOneDentalEntities();

        // GET: UserRols
        public ActionResult Index()
        {
            return View(db.UserRol.ToList());
        }

        // GET: UserRols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRol userRol = db.UserRol.Find(id);
            if (userRol == null)
            {
                return HttpNotFound();
            }
            return View(userRol);
        }

        // GET: UserRols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,RowId,Created")] UserRol userRol)
        {
            if (ModelState.IsValid)
            {
                userRol.RowId = new Guid().ToString();
                userRol.Created = DateTime.Now;
                
                db.UserRol.Add(userRol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRol);
        }

        // GET: UserRols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRol userRol = db.UserRol.Find(id);
            if (userRol == null)
            {
                return HttpNotFound();
            }
            return View(userRol);
        }

        // POST: UserRols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,RowId,Created")] UserRol userRol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRol);
        }

        // GET: UserRols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRol userRol = db.UserRol.Find(id);
            if (userRol == null)
            {
                return HttpNotFound();
            }
            return View(userRol);
        }

        // POST: UserRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRol userRol = db.UserRol.Find(id);
            db.UserRol.Remove(userRol);
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
