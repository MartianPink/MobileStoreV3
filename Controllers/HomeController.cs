using MobileStoreV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MobileStoreV3.Controllers
{
    public class HomeController : Controller
    {
        private readonly MobileStoreDbContext db = new MobileStoreDbContext();

        MobileStoreV3Entities StoreV3Entities = new MobileStoreV3Entities();
        public ActionResult Index()
        {
            var mobilePhones = db.MobilePhones.ToList();
            return View("Index", mobilePhones);
        }
            
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(User model,string returnUrl)
        {
            var dataItem = StoreV3Entities.Users.Where(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault();
            if (dataItem !=null)
            {
            FormsAuthentication.SetAuthCookie(dataItem.Username, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length >1&& returnUrl.StartsWith("/")&& !returnUrl.StartsWith("//")&& !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user/pass");
                return View();
            }
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Home");
        }


    }
}