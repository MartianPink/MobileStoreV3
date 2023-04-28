using MobileStoreV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStoreV3.Controllers
{
    public class HomeController : Controller
    {
        private readonly MobileStoreDbContext db = new MobileStoreDbContext();
        public ActionResult Index()
        {
            var mobilePhones = db.MobilePhones.ToList();
            return View("Index", mobilePhones);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}