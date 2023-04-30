using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobileStoreV3.Models;

namespace MobileStoreV3.Controllers
{
    public class MobilePhoneController: Controller
    {
        private  MobileStoreDbContext db = new MobileStoreDbContext();

        // GET: MobilePhoneModel
        public ActionResult Index()
        {
            var mobilePhones = db.MobilePhones.ToList();
            return View("Index",mobilePhones);
        }

        // GET: MobilePhoneM/AddProduct
        //[Authorize(Roles = "cashier")]
        public ActionResult AddProduct( string returnUrl)
        {
            return View("_AddMobilePhone");
        }

        // POST: MobilePhoneM/AddProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "cashier")]
        public ActionResult AddProduct(MobilePhoneModel mobilePhone)
        {
            if (ModelState.IsValid)
            {
                db.MobilePhones.Add(mobilePhone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mobilePhone);
        }

        // GET: MobilePhoneModel/Edit/5
        [Authorize(Roles = "cashier")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobilePhoneModel mobilePhone = db.MobilePhones.Find(id);
            if (mobilePhone == null)
            {
                return HttpNotFound();
            }
            return View(mobilePhone);
        }

        // POST: MobilePhoneModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "cashier")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ImageUrl,Price")] MobilePhoneModel mobilePhone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobilePhone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mobilePhone);
        }

        // GET: MobilePhoneModel/Delete/5
        [Authorize(Roles = "cashier")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobilePhoneModel mobilePhone = db.MobilePhones.Find(id);
            if (mobilePhone == null)
            {
                return HttpNotFound();
            }
            return View(mobilePhone);
        }

        // POST: MobilePhoneModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "cashier")]
        public ActionResult DeleteConfirmed(int id)
        {
            MobilePhoneModel mobilePhone = db.MobilePhones.Find(id);
            db.MobilePhones.Remove(mobilePhone);
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