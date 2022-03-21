using Islemler.Somut;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Varliklar.Somut;
using VeriErisimler.EFDal;

namespace MVCBlogSite.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager(new EFBlogDal());
        AuthorManager am = new AuthorManager(new EFAuthorDal());
        CommentManager cm = new CommentManager(new EFCommentDal());
        CategoryManager cam = new CategoryManager(new EFCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult FeaturedList()
        {
            ViewBag.title1 = bm.BlogTitle(2);
            ViewBag.date1 = bm.BlogDate(2);
            ViewBag.image1 = bm.BlogImage(2);

            ViewBag.title2 = bm.BlogTitle(11);
            ViewBag.date2 = bm.BlogDate(11);
            ViewBag.image2 = bm.BlogImage(11);

            ViewBag.title3 = bm.BlogTitle(9);
            ViewBag.date3 = bm.BlogDate(9);
            ViewBag.image3 = bm.BlogImage(9);

            ViewBag.title4 = bm.BlogTitle(6);
            ViewBag.date4 = bm.BlogDate(6);
            ViewBag.image4 = bm.BlogImage(6);

            ViewBag.title5 = bm.BlogTitle(4);
            ViewBag.date5 = bm.BlogDate(4);
            ViewBag.image5 = bm.BlogImage(4);
            return PartialView();
        }
        public PartialViewResult BlogList(int page = 1)
        {
            return PartialView(bm.ServisListele().ToPagedList(page, 3));
        }
        public PartialViewResult OtherFeaturedList()
        {
            return PartialView();
        }



        // Blog Details
        public ActionResult BlogDetail(int id)
        {
            ViewBag.bID = id;
            return View(bm.ServisIDListele(id));
        }
        [HttpPost]
        public ActionResult BlogDetail(Comment c)
        {
            c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.ServisEkle(c);
            return RedirectToAction("BlogDetail");
        }
        public PartialViewResult PopularPost()
        {
            return PartialView();
        }
        public PartialViewResult Categories()
        {
            return PartialView(cam.ServisListele());
        }
        public PartialViewResult Tags()
        {
            return PartialView();
        }
        public PartialViewResult Comments(int id)
        {
            return PartialView(cm.CommmentBlog(id));
        }
        public PartialViewResult Bio(int id)
        {
            var author = bm.BlogAuthor(id);
            return PartialView(am.ServisIDListele(author));
        }
        public PartialViewResult DetailHead(int id)
        {
            return PartialView(bm.ServisIDListele(id));
        }
        public PartialViewResult DetailContent(int id)
        {
            return PartialView(bm.ServisIDListele(id));
        }

        // Add Comment





        // BlogByCategory

        public ActionResult BlogByCategories(int id, int page = 1)
        {
            return View(bm.CategoryBlogs(id).ToPagedList(page, 3));
        }



        public ActionResult BlogByCategory()
        {
            return View();
        }

        public PartialViewResult BlogByCategoryHead()
        {
            return PartialView();
        }
        public PartialViewResult BlogByCategoryContent()
        {
            return PartialView();
        }



        // Blog by Author

        public ActionResult AuthorBlog(int id, int page = 1)
        {
            return View(bm.AuthorBlogs(id).ToPagedList(page, 3));
        }
    }
}