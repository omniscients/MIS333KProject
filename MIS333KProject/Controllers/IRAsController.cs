using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS333KProject.DAL;
using MIS333KProject.Models;

namespace MIS333KProject.Controllers
{
    public class IRAsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: IRAs
        public ActionResult Index()
        {
            var iRAs = db.IRAs.Include(i => i.Customer);
            return View(iRAs.ToList());
        }

        // GET: IRAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IRA iRA = db.IRAs.Find(id);
            if (iRA == null)
            {
                return HttpNotFound();
            }
            return View(iRA);
        }

        // GET: IRAs/Create
        public ActionResult Create()
        {
            ViewBag.AccountNumber = new SelectList(db.Customers, "Email", "Password");
            return View();
        }

        // POST: IRAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountNumber,Balance,CustomerEmail,AccountName,AccountType")] IRA iRA)
        {
            if (ModelState.IsValid)
            {
                db.IRAs.Add(iRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountNumber = new SelectList(db.Customers, "Email", "Password", iRA.AccountNumber);
            return View(iRA);
        }

        // GET: IRAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IRA iRA = db.IRAs.Find(id);
            if (iRA == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountNumber = new SelectList(db.Customers, "Email", "Password", iRA.AccountNumber);
            return View(iRA);
        }

        // POST: IRAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountNumber,Balance,CustomerEmail,AccountName,AccountType")] IRA iRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountNumber = new SelectList(db.Customers, "Email", "Password", iRA.AccountNumber);
            return View(iRA);
        }

        // GET: IRAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IRA iRA = db.IRAs.Find(id);
            if (iRA == null)
            {
                return HttpNotFound();
            }
            return View(iRA);
        }

        // POST: IRAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            IRA iRA = db.IRAs.Find(id);
            db.IRAs.Remove(iRA);
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
