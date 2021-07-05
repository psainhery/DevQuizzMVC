using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevQuizzMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuizzFrontList()
        {
            return View();
        }

        public ActionResult QuizzBackList()
        {
            return View();
        }
    }
}