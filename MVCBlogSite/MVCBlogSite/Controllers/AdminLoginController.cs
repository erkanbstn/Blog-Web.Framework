using Islemler.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Varliklar.Somut;
using VeriErisimler.EFDal;

namespace MVCBlogSite.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        AdminManager am = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin a)
        {
            var x = am.AdminLogin(a);
            if (x != null)
            {
                FormsAuthentication.SetAuthCookie(a.UserName, false);
                Session["AdminID"] = a.AdminID;
                return RedirectToAction("Index", "AdminBlog");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}