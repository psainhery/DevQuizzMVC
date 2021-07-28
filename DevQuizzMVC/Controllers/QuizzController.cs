using DevQuizzMVC.DTO;
using DevQuizzMVC.Filters;
using DevQuizzMVC.Models;
using DevQuizzMVC.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DevQuizzMVC.Controllers
{
    public class QuizzController : Controller
    {
        private QuizzService service = new QuizzService();
        private QuestionQuizzService questionService = new QuestionQuizzService();
        private AnswerQuizzService answerService = new AnswerQuizzService();
        

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
        public ActionResult Create([Bind(Include = "Id,Title,CategoryId,QuizzCategory,QuestionsQuizz")] QuizzDTO quizzDTO, HttpPostedFileBase Picture)
        {
            if (ModelState.IsValid)
            {
                quizzDTO.Picture = quizzDTO.Title + Path.GetExtension(Picture.FileName);
                Picture.SaveAs(Server.MapPath("~/Content/picturesQuizz/") + quizzDTO.Picture);

                service.Add(quizzDTO);
                return RedirectToAction("Index");
            }
            return View(quizzDTO);
        }

        //public ActionResult DoQuizz(int? id)
        //{
        //    //recuperer le quiz cliqué 

        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    QuizzDTO quizzDTO = service.getQuizzDTOById(id);
        //    if (quizzDTO == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(quizzDTO);
        //}

        public ActionResult DoQuizz(string search, int? i, string sortBy, QuizzDTO quizzDTO)
        {
            List<QuestionQuizzDTO> lst = new List<QuestionQuizzDTO>();
            if (search != null)
                lst = questionService.GetAllQuestions().Where(u => u.QuestionText.Contains(search)).ToList();
            else
                lst = questionService.GetAllQuestions().Where(q => q.QuizzId.Equals(quizzDTO.Id)).ToList();


            switch (sortBy)
            {
                case "nameAsc":
                    lst = lst.OrderBy(x => x.QuestionText).ToList();
                    break;
                case "nameDesc":
                    lst = lst.OrderByDescending(x => x.QuestionText).ToList();
                    break;
                case null:
                    break;
                default:
                    break;
            }


            return View(lst.ToPagedList(i ?? 1, 5));
        }
        [LoginFilter]
        public ActionResult Demarrer(int id)
        {
            Session["score"] = 0;
            Session["quizzId"] = id;
            Session["ordre"] = 1;
            ViewBag.QuizzDTO = service.getQuizzDTOById(id);
            QuestionQuizzDTO question = questionService.FindQuestion(id, 1);
            return View("Progress2", question);
        }

        [HttpPost]
        public ActionResult Next(FormCollection form)
        {
            int score = Convert.ToInt32(Session["score"]);
            int quizzId = Convert.ToInt32(Session["quizzId"]);
            int ordre = Convert.ToInt32(Session["ordre"]);
            QuizzDTO quizzDto = service.getQuizzDTOById(quizzId);
            ViewBag.QuizzDTO = quizzDto;
            QuestionQuizzDTO qst = quizzDto.QuestionsQuizzDTO[ordre - 1];
            if (!qst.isMultiple)
            {
                int idReponse = Convert.ToInt32(form.Get("selectedSimpleReponse"));
                if (idReponse>0)
                {
                    if (service.FindReponse(quizzId, qst.Id, idReponse).isCorrect)
                    {
                        score++;
                        Session["score"] = score;
                    }
                    else
                    {
                        score--;
                        Session["score"] = score;
                    }
                }
                else
                {
                    ViewBag.Error = "Veuilez séléctionner une réponse";
                    return View("Progress2", qst);

                } 
                                
            }
            else
            {
                string[] reponses = form.GetValues("selectedRep[]");                
                if (reponses==null)
                {
                    ViewBag.Error = "Veuilez séléctionner une réponse";
                    return View("Progress2", qst);

                }
                else
                {
                    bool[] tabRep = new bool[reponses.Length];
                    for (int i = 0; i < reponses.Length; i++)
                    {
                        tabRep[i] = service.FindReponse(quizzId, qst.Id, Convert.ToInt32(reponses[i])).isCorrect;
                    }
                    bool exist = tabRep.Contains(false);
                    if (exist == true)
                    {
                        score--;
                        Session["score"] = score;
                    }
                    else
                    {
                        score++;
                        Session["score"] = score;
                    }
                }

            }
            if(ordre < quizzDto.QuestionsQuizzDTO.Count)
            {
                ordre++;
                Session["ordre"] = ordre;
                QuestionQuizzDTO question = questionService.FindQuestion(quizzId, ordre);
                return View("Progress2", question);
            }
            else
            {
                return View("Resultat");
            }

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizzDTO QuizDTO = service.getQuizzDTOById(id);
            if (QuizDTO == null)
            {
                return HttpNotFound();
            }
            return View(QuizDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,CategoryId,QuizzCategory,QuestionsQuizz")] QuizzDTO QuizDTO)
        {
            if (ModelState.IsValid)
            {
                service.Update(QuizDTO);
                return RedirectToAction("index");
            }
            return View(QuizDTO);
        }

        //public ActionResult Delete(int id)
        //{
        //    //using with ressources

        //    using (MyContext context = new MyContext())
        //    {
        //        Quizz c = context.Quizzes.Find(id);

        //        if (c != null)
        //        {
        //            context.Quizzes.Remove(c);

        //            context.SaveChanges();

        //        }
        //        else
        //        {
        //            Console.WriteLine("erreur ");
        //        }
        //        return RedirectToAction("index");

        //    }
        //}

        public ActionResult Delete(int? id)
        {
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuizzDTO quizzDTO = service.getQuizzDTOById(id);
            service.DeleteQuizzDTO(id);
            return RedirectToAction("Index");
        }


    }
}
