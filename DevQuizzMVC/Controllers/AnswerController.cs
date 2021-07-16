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

        // GET: Utilisateur/Edit/5
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
                return View(answerQuizzDTO);

            }

        }

        // POST: Utilisateur/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AnswerText,isCorrect,QuestionQuizzId")] AnswerQuizzDTO answerQuizzDTO)
        {
            if (ModelState.IsValid)
            {
                service.Update(answerQuizzDTO);
                return RedirectToAction("Index", new { id = answerQuizzDTO.QuestionQuizzId });
            }
            return View(answerQuizzDTO);
        }

        // GET: Utilisateur/Delete/5
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
            return View(answerQuizzDTO);
        }

        // POST: Utilisateur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, AnswerQuizzDTO answerQuizzDTO)
        {
            service.DeleteAnswerDTO(id);
            return RedirectToAction("Index", new { id = answerQuizzDTO.QuestionQuizzId }); // ne renvoie pas au bon index
        }

        public ActionResult Create()
        {
            return View(new AnswerQuizzDTO());
        }

        // POST: Utilisateur/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AnswerText,isCorrect,QuestionQuizzId")] AnswerQuizzDTO answerQuizzDTO)
        {
            if (ModelState.IsValid)
            {
                service.Add(answerQuizzDTO);
                return RedirectToAction("Index", new { id = answerQuizzDTO.QuestionQuizzId });
            }

            return View(answerQuizzDTO);
        }
    }
}