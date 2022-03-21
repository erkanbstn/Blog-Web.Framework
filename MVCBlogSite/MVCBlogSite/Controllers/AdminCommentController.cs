using Islemler.Somut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeriErisimler.EFDal;

namespace MVCBlogSite.Controllers
{
    public class AdminCommentController : Controller
    {
        // GET: AdminComment
        CommentManager cm = new CommentManager(new EFCommentDal());
        public ActionResult Index()
        {
            return View(cm.ServisListele());
        }
        public ActionResult DeleteComment(int id)
        {
            var x = cm.ServisIDGetir(id);
            cm.ServisSil(x);
            return RedirectToAction("Index");
        }
    }
}