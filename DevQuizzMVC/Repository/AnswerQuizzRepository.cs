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
    }
}