using DevQuizzMVC.DTO;
using DevQuizzMVC.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult Create()
        {
            return View(new QuizzDTO());
        }
        // POST: Utilisateur/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,CategoryId,QuizzCategory,QuestionsQuizz")] QuizzDTO quizzDTO)
        {
            if (ModelState.IsValid)
            {
                service.Add(quizzDTO);
                return RedirectToAction("Index");
            }
            return View(quizzDTO);
        }

        public ActionResult DoQuizz(int? id)
        {
            //recuperer le quiz cliqué 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizzDTO quizzDTO = service.getQuizzDTOById(id);
            if (quizzDTO == null)
            {
                return HttpNotFound();
            }
            return View(quizzDTO);
        }

        /*public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizzDTO QuizzDTO = service.getQuizzDTOById(id);
            if (QuizzDTO == null)
            {
                return HttpNotFound();
            }
            return View(QuizzDTO);
        }*/
    }
}