using DevQuizzMVC.DTO;
using DevQuizzMVC.Models;
using DevQuizzMVC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevQuizzMVC.Controllers
{
    public class QuestionQuizzRepository
    {
        public List<QuestionQuizzDTO> GetAllQuestions()
        {
            List<QuestionQuizzDTO> lst = new List<QuestionQuizzDTO>();
            //UserDTO dto = new UserDTO(); 
            using (MyContext context = new MyContext())
            {
                List<QuestionQuizz> lstModel = context.QuestionQuizzes.ToList();
                foreach (QuestionQuizz model in lstModel)
                {
                    lst.Add(Convertisseur.QuestionQuizzDTOFromQuestionQuizz(new QuestionQuizzDTO(), model));
                }
            }
            return lst;
        }

        public void DeleteQuestionQuizzDTO(int id)
        {
            using (MyContext context = new MyContext())
            {
                QuestionQuizz q = context.QuestionQuizzes.Find(id);
                context.QuestionQuizzes.Remove(q);
                context.SaveChanges();
            }
        }

        public void Update(QuestionQuizzDTO questionQuizzDTO)
        {
            using (MyContext context = new MyContext())
            {
                QuestionQuizz q = context.QuestionQuizzes.Find(questionQuizzDTO.Id); 
                q = Convertisseur.QuestionQuizzFromQuestionQuizzDTO(questionQuizzDTO, q); 
                context.SaveChanges(); 
            }
        }

        public void Add(QuestionQuizzDTO questionQuizzDTO)
        {
            QuestionQuizz q = Convertisseur.QuestionQuizzFromQuestionQuizzDTO(questionQuizzDTO, new QuestionQuizz());
            using (MyContext context = new MyContext())
            {
                context.QuestionQuizzes.Add(q);
                context.SaveChanges();
            }
        }

        public QuestionQuizzDTO GetQuestionDTOByID(int? id)
        {
            QuestionQuizzDTO dto = new QuestionQuizzDTO();
            using (MyContext context = new MyContext())
            {
                QuestionQuizz model = context.QuestionQuizzes.Find(id);
                if(model != null)
                {
                    dto = Convertisseur.QuestionQuizzDTOFromQuestionQuizz(dto, model);
                }
                return dto;
            }
        }

        
    }
}