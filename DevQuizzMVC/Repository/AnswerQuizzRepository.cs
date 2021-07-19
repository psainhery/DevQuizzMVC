using DevQuizzMVC.DTO;
using DevQuizzMVC.Models;
using DevQuizzMVC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.Repository
{
    public class AnswerQuizzRepository
    {
        public List<AnswerQuizzDTO> GetAllAnswers()
        {
            List<AnswerQuizzDTO> lst = new List<AnswerQuizzDTO>();
            using (MyContext context = new MyContext())
            {
                List<AnswerQuizz> lstModel = context.AnswerQuizzes.ToList();
                foreach (AnswerQuizz model in lstModel)
                {
                    lst.Add(Convertisseur.AnswerQuizzDTOFromAnswerQuizz(new AnswerQuizzDTO(), model));
                }
            }
            return lst;
        }

        public void DeleteAnswerDTO(int id)
        {
            using (MyContext context = new MyContext())
            {
                AnswerQuizz a = context.AnswerQuizzes.Find(id);
                context.AnswerQuizzes.Remove(a);
                context.SaveChanges();
            }
        }

        public void Add(AnswerQuizzDTO answerQuizzDTO)
        {
            AnswerQuizz a = Convertisseur.AnswerQuizzFromAnswerQuizzDTO(answerQuizzDTO, new AnswerQuizz());
            using (MyContext context = new MyContext())
            {
                context.AnswerQuizzes.Add(a);
                context.SaveChanges();
            }
        }

        public void Update(AnswerQuizzDTO answerQuizzDTO)
        {
            using (MyContext context = new MyContext())
            {
                AnswerQuizz a = context.AnswerQuizzes.Find(answerQuizzDTO.Id); //changed
                a = Convertisseur.AnswerQuizzFromAnswerQuizzDTO(answerQuizzDTO, a); //Modified - Added - Deleted - Attached - Detached
                context.SaveChanges(); //SQL Update
            }
        }

        public AnswerQuizzDTO getAnswerDTOById(int? id)
        {
            AnswerQuizzDTO dto = new AnswerQuizzDTO();
            using (MyContext context = new MyContext())
            {
                AnswerQuizz model = context.AnswerQuizzes.Find(id);
                if (model != null)
                {
                    dto = Convertisseur.AnswerQuizzDTOFromAnswerQuizz(dto, model);
                }
            }
            return dto;
        }
    }
}