using Islemler.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Varliklar.Somut;
using VeriErisimler.EFDal;
using VeriErisimler.Somut;

namespace MVCBlogSite.Controllers
{
    public class AdminBlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogDal());
        AuthorManager am = new AuthorManager(new EFAuthorDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        CommentManager cam = new CommentManager(new EFCommentDal());
        public ActionResult Index()
        {
            return View(bm.ServisListele());
        }

        public ActionResult NewBlog()
        {
            List<SelectListItem> yazar = (from c in am.ServisListele()
                                          select new SelectListItem
                                          {
                                              Text = c.AuthorName,
                                              Value = c.AuthorID.ToString()
                                          }).ToList();

            List<SelectListItem> kategori = (from c in cm.ServisListele()
                                             select new SelectListItem
                                             {
                                                 Text = c.CategoryName,
                                                 Value = c.CategoryID.ToString()
                                             }).ToList();
            ViewBag.yazar = yazar;
            ViewBag.kategori = kategori;

            return View();
        }
        [HttpPost]
        public ActionResult NewBlog(Blog b)
        {
            b.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            bm.ServisEkle(b);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateBlog(int id)
        {
            var x = bm.ServisIDGetir(id);

            List<SelectListItem> yazar = (from c in am.ServisListele()
                                          select new SelectListItem
                                          {
                                              Text = c.AuthorName,
                                              Value = c.AuthorID.ToString()
                                          }).ToList();

            List<SelectListItem> kategori = (from c in cm.ServisListele()
                                             select new SelectListItem
                                             {
                                                 Text = c.CategoryName,
                                                 Value = c.CategoryID.ToString()
                                             }).ToList();
            ViewBag.yazar = yazar;
            ViewBag.kategori = kategori;



            return View(x);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog b)
        {
            // İngiltere'ye Giden Herkesin de Bildiği Gibi Saat Kulesi En Meşhur Yeridir. Boyutlarının Bir İnsanın 500 Kat Uzunluğunda Olduğunu Söylüyorlar !
            b.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            bm.ServisGuncelle(b);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBlog(int id)
        {
            var x = bm.ServisIDGetir(id);
            bm.ServisSil(x);
            return RedirectToAction("Index");
        }

        public ActionResult CommentBlog()
        {
            return View();
        }

        public PartialViewResult CommentBlogHead(int id)
        {
            return PartialView(am.ServisIDListele(id));
        }
        
        public PartialViewResult CommentBlogTable(int id)
        {
            CommentManager.blogid = id;
            return PartialView(cam.CommmentBlog(id));
        }
        public ActionResult DeleteComment(int id)
        {
            var x = cam.ServisIDGetir(id);
            cam.ServisSil(x);
            return RedirectToAction($"CommentBlog/{CommentManager.blogid}");
        }
    }
}