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
    public class AdminAdminController : Controller
    {
        // GET: AdminAdmin
        AdminManager am = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            return View(am.ServisListele());
        }

        public ActionResult NewAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAdmin(Admin a)
        {
            am.ServisEkle(a);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAdmin(int id)
        {
            var x = am.ServisIDGetir(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin a)
        {
            am.ServisGuncelle(a);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            am.ServisSil(am.ServisIDGetir(id));
            return RedirectToAction("Index");
        }
    }
}