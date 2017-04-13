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
    public class SavingsAccountsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: SavingsAccounts
        public ActionResult Index()
        {
            var savingsAccounts = db.SavingsAccounts.Include(s => s.Customer);
            return View(savingsAccounts.ToList());
        }

        // GET: SavingsAccounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingsAccount savingsAccount = db.SavingsAccounts.Find(id);
            if (savingsAccount == null)
            {
                return HttpNotFound();
            }
            return View(savingsAccount);
        }

        // GET: SavingsAccounts/Create
        public ActionResult Create()
        {
            ViewBag.CustomerEmail = new SelectList(db.Customers, "Email", "Password");
            return View();
        }

        // POST: SavingsAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountNumber,Balance,CustomerEmail,AccountName,AccountType")] SavingsAccount savingsAccount)
        {
            if (ModelState.IsValid)
            {
                db.SavingsAccounts.Add(savingsAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerEmail = new SelectList(db.Customers, "Email", "Password", savingsAccount.CustomerEmail);
            return View(savingsAccount);
        }

        // GET: SavingsAccounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingsAccount savingsAccount = db.SavingsAccounts.Find(id);
            if (savingsAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerEmail = new SelectList(db.Customers, "Email", "Password", savingsAccount.CustomerEmail);
            return View(savingsAccount);
        }

        // POST: SavingsAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountNumber,Balance,CustomerEmail,AccountName,AccountType")] SavingsAccount savingsAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(savingsAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerEmail = new SelectList(db.Customers, "Email", "Password", savingsAccount.CustomerEmail);
            return View(savingsAccount);
        }

        // GET: SavingsAccounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SavingsAccount savingsAccount = db.SavingsAccounts.Find(id);
            if (savingsAccount == null)
            {
                return HttpNotFound();
            }
            return View(savingsAccount);
        }

        // POST: SavingsAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SavingsAccount savingsAccount = db.SavingsAccounts.Find(id);
            db.SavingsAccounts.Remove(savingsAccount);
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
