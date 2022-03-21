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
    public class AdminAuthorController : Controller
    {
        AuthorManager am = new AuthorManager(new EFAuthorDal());
        public ActionResult Index()
        {
            return View(am.ServisListele());
        }

        public ActionResult UpdateAuthor(int id)
        {
            return View(am.ServisIDGetir(id));
        }
        [HttpPost]
        public ActionResult UpdateAuthor(Author a)
        {
            am.ServisGuncelle(a);
            return RedirectToAction("Index");
        }


    }
}