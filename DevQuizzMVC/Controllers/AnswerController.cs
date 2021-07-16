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
    public class AnswerController : Controller
    {
        AnswerQuizzService service = new AnswerQuizzService();

        public ActionResult Index(string search, int? i, string sortBy, int? id)
        {
            List<AnswerQuizzDTO> lst = new List<AnswerQuizzDTO>();


            if (search != null)
                lst = service.GetAllAnswers().Where(a => a.AnswerText.Contains(search)).ToList();
            else
                lst = service.GetAllAnswers().Where(a => a.QuestionQuizzId == id).ToList();

            switch (sortBy)
            {
                case "nameAsc":
                    lst = lst.OrderBy(x => x.AnswerText).ToList();
                    break;
                case "nameDesc":
                    lst = lst.OrderByDescending(x => x.AnswerText).ToList();
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