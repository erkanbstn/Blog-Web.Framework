using Islemler.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Varliklar.Somut;
using VeriErisimler.EFDal;

namespace MVCBlogSite.Controllers
{
    public class AdminAboutController : Controller
    {
        AboutManager am = new AboutManager(new EFAboutDal());
        public ActionResult Index()
        {
            return View(am.ServisIDGetir(1));
        }
        [HttpPost]
        public ActionResult Index(About a)
        {
            am.ServisGuncelle(a);
            return View();
        }
       
    }
}