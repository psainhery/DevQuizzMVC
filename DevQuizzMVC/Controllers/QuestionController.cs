﻿using DevQuizzMVC.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DevQuizzMVC.Controllers
{
    public class QuestionController : Controller
    {
        private QuestionQuizzService service = new QuestionQuizzService();
        // GET: Question
        public ActionResult Index(string search, int? i, string sortBy, int? id)
        {
            List<QuestionQuizzDTO> lst = new List<QuestionQuizzDTO>();


            if (search != null)
                lst = service.GetAllQuestions().Where(q => q.QuestionText.Contains(search)).ToList();
            else
                lst = service.GetAllQuestions().Where(q => q.QuizzId == id).ToList();

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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionQuizzDTO QuestionQuizzDTO = service.GetQuestionQuizzDTOById(id);
            if (QuestionQuizzDTO == null)
            {
                return HttpNotFound();
            }
            return View(QuestionQuizzDTO);
        }

        public ActionResult Create()
        {
            return View(new QuestionQuizzDTO());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QuestionText,isMultiple,QuizzId")] QuestionQuizzDTO questionQuizzDTO)
        {
            if (ModelState.IsValid)
            {
                service.Add(questionQuizzDTO);
                return RedirectToAction("Index");
            }
            return View(questionQuizzDTO);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionQuizzDTO questionQuizzDTO = service.GetQuestionQuizzDTOById(id);
            if (questionQuizzDTO == null)
            {
                return HttpNotFound();
            }
            else
            {
               
                return View(questionQuizzDTO);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QuestionText,isMultiple,QuizzId")] QuestionQuizzDTO questionQuizzDTO)
        {
            if (ModelState.IsValid)
            {
                service.Update(questionQuizzDTO);
                return RedirectToAction("Index");
            }
            return View(questionQuizzDTO);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionQuizzDTO questionQuizzDTO = service.GetQuestionQuizzDTOById(id);
            if (questionQuizzDTO == null)
            {
                return HttpNotFound();
            }
            return View(questionQuizzDTO);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.DeleteQuestionQuizzDTO(id);
            return RedirectToAction("Index");
        }
    }
}