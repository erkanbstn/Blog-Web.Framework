using Islemler.Somut;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeriErisimler.EFDal;

namespace MVCBlogSite.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EFAboutDal());
        AuthorManager aam = new AuthorManager(new EFAuthorDal());
        // GET: About
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult AboutHead()
        {
            return PartialView();
        }
        public PartialViewResult Explore()
        {
            return PartialView(am.ServisListele());
        }
        public PartialViewResult Team(int page = 1)
        {
            return PartialView(aam.ServisListele().ToPagedList(page, 3));
        }

        public PartialViewResult LearnUs()
        {
            return PartialView(am.ServisListele());
        }
    }
}