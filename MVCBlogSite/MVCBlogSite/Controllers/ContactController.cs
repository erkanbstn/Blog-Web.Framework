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
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        // GET: Contact

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact c)
        {
            cm.ServisEkle(c);
            ViewBag.mesaj = "Mesaj Başarıyla Gönderildi";
            return View();
        }
        public PartialViewResult ContactHead()
        {
            return PartialView();
        }
        public PartialViewResult ContactDetail()
        {
            return PartialView();
        }
    }
}