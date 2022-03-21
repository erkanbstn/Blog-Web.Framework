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
    public class AuthorLoginController : Controller
    {
        // GET: AuthorLogin
        AuthorManager am = new AuthorManager(new EFAuthorDal());
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Author a)
        {
            var x = am.AuthorSign(a);
            if (x != null)
            {
                FormsAuthentication.SetAuthCookie(x.AuthorName, false);
                Session["AuthorID"] = x.AuthorID;
                return RedirectToAction("Index", "AuthorPanel");
            }
            return View();
        }
    }
}
