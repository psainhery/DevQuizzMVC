using DevQuizzMVC.DTO;
using DevQuizzMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevQuizzMVC.Controllers
{
    public class CategoryController : Controller
    {
        private QuizzService service = new QuizzService();

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuizzFrontList()
        {
            /* Recuperer une lst de Quiz en BDD
             * methode GetAllQuizz
             * besoin d'un nouveau service QuizzService
             * besoin d'un nouveau Repo QuizzRepository
             * utilisation du QuizzDTO
             */
            List<QuizzDTO> lst = new List<QuizzDTO>();
            lst = service.getAllQuizzs().Where(q => q.CategoryId.Equals(1)).ToList();
            
            return View(lst);
        }

        public ActionResult QuizzBackList()
        {
            List<QuizzDTO> lst = new List<QuizzDTO>();
            lst = service.getAllQuizzs().Where(q => q.CategoryId.Equals(2)).ToList();

            return View(lst);
        }
    }
}