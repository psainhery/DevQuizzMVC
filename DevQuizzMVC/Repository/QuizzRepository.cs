using DevQuizzMVC.DTO;
using DevQuizzMVC.Models;
using DevQuizzMVC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.Repository
{
    public class QuizzRepository
    {
        public List<QuizzDTO> getAllQuizzs()
        {
            List<QuizzDTO> lst = new List<QuizzDTO>();
            //UserDTO dto = new UserDTO(); 
            using (MyContext context = new MyContext())
            {
                List<Quizz> lstModel = context.Quizzes.ToList();
                foreach (Quizz model in lstModel)
                {
                    lst.Add(Convertisseur.QuizzDtoFromQuizz(new QuizzDTO(), model));
                }
            }
            return lst;
        }

        internal AnswerQuizzDTO FindReponse(int quizzId, int qstId, int idReponse)
        {
            AnswerQuizzDTO repDTO = new AnswerQuizzDTO();
            using (MyContext context = new MyContext())
            {
                AnswerQuizz answer = context.AnswerQuizzes.SingleOrDefault(r => r.QuestionQuizzId == qstId && r.QuestionQuizz.QuizzId == quizzId && r.Id == idReponse);
                return Convertisseur.AnswerQuizzDTOFromAnswerQuizz(repDTO, answer);
            }
        }

        public QuizzDTO getQuizzDTOById(int? id)
        {
            QuizzDTO dto = new QuizzDTO();
            using (MyContext context = new MyContext())
            {
                Quizz model = context.Quizzes.Find(id);
                if (model != null)
                {
                    dto = Convertisseur.QuizzDtoFromQuizz(dto, model);
                }
            }
            return dto;
        }

        internal void DeleteQuizzDTO(int id)
        {
            using (MyContext context = new MyContext())
            {
                Quizz q = context.Quizzes.Find(id);
                context.Quizzes.Remove(q);
                context.SaveChanges();
            }
        }

        public void Add(QuizzDTO quizzDTO)
        {
            Quizz q = Convertisseur.QuizzFromQuizzDto(quizzDTO, new Quizz());
            using (MyContext context = new MyContext())
            {
                context.Quizzes.Add(q);
                context.SaveChanges();
            }
        }
    }
}