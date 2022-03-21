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
    public class AuthorPanelController : Controller
    {
        AuthorManager am = new AuthorManager(new EFAuthorDal());
        BlogManager bm = new BlogManager(new EFBlogDal());
        CommentManager cam = new CommentManager(new EFCommentDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());

        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["AuthorID"]);
            return View(am.ServisIDGetir(id));
        }
        [HttpPost]
        public ActionResult Index(Author a)
        {
            am.ServisGuncelle(a);
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "AuthorLogin");
        }

        public ActionResult Bloglarim()
        {
            int id = Convert.ToInt32(Session["AuthorID"]);
            return View(bm.AuthorBlogs(id));
        }

        public ActionResult BlogComments(int id)
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
        public ActionResult DeleteBlog(int id)
        {
            var x = cam.ServisIDGetir(id);
            cam.ServisSil(x);
            return RedirectToAction("Bloglarim");
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
        public ActionResult DeleteComment(int id)
        {
            var x = cam.ServisIDGetir(id);
            cam.ServisSil(x);
            return RedirectToAction($"CommentBlog/{CommentManager.blogid}");
        }
    }
}