using MobileStoreV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MobileStoreV3.Controllers
{
    public class CustomerController:Controller
    {
        private MobileStoreDbContext db = new MobileStoreDbContext();

        // GET: CustomerModel
        public ActionResult Index()
        {
            var customers = db.Customers.ToList();
            return View(customers);
        }

        // GET: CustomerModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: CustomerModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: CustomerModel/ShoppingCart/5
        public ActionResult ShoppingCart()
        {
            /*CustomerModel customer = db.Customers.Find(1);
            if (customer == null)
            {
                return HttpNotFound();
            }*/
            return View("_ShoppingCart");
        }

        // POST: CustomerModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerModel customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: CustomerModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: CustomerModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerModel customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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