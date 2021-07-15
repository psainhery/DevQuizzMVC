using DevQuizzMVC.DTO;
using DevQuizzMVC.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevQuizzMVC.Controllers
{
    public class QuizzController : Controller
    {
        private QuizzService service = new QuizzService();
        public ActionResult Index(string search, int? i, string sortBy)
        {
            // Affichage Liste QUizz coté admin
            List<QuizzDTO> lst = new List<QuizzDTO>();
            if (search != null)
                lst = service.getAllQuizzs().Where(q => q.Title.Contains(search)).ToList();
            else
                lst = service.getAllQuizzs();
            //Tri
            switch (sortBy)
            {
                case "nameAsc":
                    lst = lst.OrderBy(x => x.Title).ToList();
                    break;
                case "nameDesc":
                    lst = lst.OrderByDescending(x => x.Title).ToList();
                    break;
                case null:
                    break;
                default:
                    break;
            }

            return View(lst.ToPagedList(i ?? 1, 5));
        }
    }
}