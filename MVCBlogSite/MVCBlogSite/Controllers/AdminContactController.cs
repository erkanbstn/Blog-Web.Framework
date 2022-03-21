using Islemler.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeriErisimler.EFDal;

namespace MVCBlogSite.Controllers
{
    public class AdminContactController : Controller
    {
        // GET: AdminContact
        ContactManager cm = new ContactManager(new EFContactDal());
        public ActionResult Index()
        {
            return View(cm.ServisListele());
        }
        public ActionResult DeleteContact(int id)
        {
            cm.ServisSil(cm.ServisIDGetir(id));
            return RedirectToAction("Index");
        }
    }
}