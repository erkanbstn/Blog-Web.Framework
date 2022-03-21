using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlogSite.Controllers
{
    public class VitrinPartialController : Controller
    {
        public PartialViewResult Footer()
        {
            return PartialView();
        }
        public PartialViewResult Header()
        {
            return PartialView();
        }
        public PartialViewResult Script()
        {
            return PartialView();
        }
        public PartialViewResult Head()
        {
            return PartialView();
        }
    }
}