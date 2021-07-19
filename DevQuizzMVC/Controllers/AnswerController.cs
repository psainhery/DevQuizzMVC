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
    public class AnswerController : Controller
    {
        AnswerQuizzService service = new AnswerQuizzService();
        QuestionQuizzService questionService = new QuestionQuizzService();

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
            ViewBag.QuestionDTO = questionService.GetQuestionQuizzDTOById(id);

            return View(lst.ToPagedList(i ?? 1, 5));

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerQuizzDTO answerQuizzDTO = service.getAnswerDTOById(id);
            if (answerQuizzDTO == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.QuestionDTO = questionService.GetQuestionQuizzDTOById(id);
                return View(answerQuizzDTO);

            }
            

        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AnswerText,isCorrect,QuestionQuizzId")] AnswerQuizzDTO answerQuizzDTO, int? id)
        {
            if (ModelState.IsValid)
            {
                service.Update(answerQuizzDTO);
                return RedirectToAction("Index", new { id = answerQuizzDTO.QuestionQuizzId });
            }
            ViewBag.QuestionDTO = questionService.GetQuestionQuizzDTOById(id);
            return View(answerQuizzDTO);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnswerQuizzDTO answerQuizzDTO = service.getAnswerDTOById(id);
            if (answerQuizzDTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionDTO = questionService.GetQuestionQuizzDTOById(id);
            return View(answerQuizzDTO);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnswerQuizzDTO answerQuizzDTO = service.getAnswerDTOById(id);
            service.DeleteAnswerDTO(id);
            ViewBag.QuestionDTO = questionService.GetQuestionQuizzDTOById(id);
            return RedirectToAction("Index", new { id = answerQuizzDTO.QuestionQuizzId });
        }

        public ActionResult Create(int? id)
        {
            ViewBag.QuestionDTO = questionService.GetQuestionQuizzDTOById(id);
            return View(new AnswerQuizzDTO());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AnswerText,isCorrect,QuestionQuizzId")] AnswerQuizzDTO answerQuizzDTO, int? id)
        {
            //rentrer automatiquement la valeur QuestionId
            if (ModelState.IsValid)
            {
                service.Add(answerQuizzDTO);
                return RedirectToAction("Index", new { id = answerQuizzDTO.QuestionQuizzId });
            }
            ViewBag.QuestionDTO = questionService.GetQuestionQuizzDTOById(id);
            return View(answerQuizzDTO);
        }
    }
}