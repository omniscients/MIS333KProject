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
    public class CheckingAccountsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: CheckingAccounts
        public ActionResult Index()
        {
            var checkingAccounts = db.CheckingAccounts.Include(c => c.Customer);
            return View(checkingAccounts.ToList());
        }

        // GET: CheckingAccounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckingAccount checkingAccount = db.CheckingAccounts.Find(id);
            if (checkingAccount == null)
            {
                return HttpNotFound();
            }
            return View(checkingAccount);
        }

        // GET: CheckingAccounts/Create
        public ActionResult Create()
        {
            ViewBag.CustomerEmail = new SelectList(db.Customers, "Email", "Password");
            return View();
        }

        // POST: CheckingAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountNumber,Balance,CustomerEmail,AccountName")] CheckingAccount checkingAccount)
        {
            if (ModelState.IsValid)
            {
                db.CheckingAccounts.Add(checkingAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerEmail = new SelectList(db.Customers, "Email", "Password", checkingAccount.CustomerEmail);
            return View(checkingAccount);
        }

        // GET: CheckingAccounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckingAccount checkingAccount = db.CheckingAccounts.Find(id);
            if (checkingAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerEmail = new SelectList(db.Customers, "Email", "Password", checkingAccount.CustomerEmail);
            return View(checkingAccount);
        }

        // POST: CheckingAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountNumber,Balance,CustomerEmail,AccountName")] CheckingAccount checkingAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkingAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerEmail = new SelectList(db.Customers, "Email", "Password", checkingAccount.CustomerEmail);
            return View(checkingAccount);
        }

        // GET: CheckingAccounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckingAccount checkingAccount = db.CheckingAccounts.Find(id);
            if (checkingAccount == null)
            {
                return HttpNotFound();
            }
            return View(checkingAccount);
        }

        // POST: CheckingAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CheckingAccount checkingAccount = db.CheckingAccounts.Find(id);
            db.CheckingAccounts.Remove(checkingAccount);
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
