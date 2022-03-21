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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        public ActionResult Index()
        {
            return View(cm.ServisListele());
        }
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(Category c)
        {
            cm.ServisEkle(c);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCategory(int id)
        {
            var x = cm.ServisIDGetir(id);
            return View(x);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category c)
        {
            cm.ServisGuncelle(c);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var x = cm.ServisIDGetir(id);
            cm.ServisSil(x);
            return RedirectToAction("Index");
        }
    }
}