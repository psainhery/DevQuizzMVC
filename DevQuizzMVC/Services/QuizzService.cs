using DevQuizzMVC.DTO;
using DevQuizzMVC.Models;
using DevQuizzMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.Services
{
    public class QuizzService
    {
        private QuizzRepository repo = new QuizzRepository();

        public List<QuizzDTO> getAllQuizzs()
        {
            return repo.getAllQuizzs();
        }

        public void Add(QuizzDTO quizzDTO)
        {
            repo.Add(quizzDTO);
        }

        public QuizzDTO getQuizzDTOById(int? id)
        {
            return repo.getQuizzDTOById(id);
        }

        internal AnswerQuizzDTO FindReponse(int quizzId, int qstId, int idReponse)
        {
            return repo.FindReponse(quizzId, qstId, idReponse);
        }

        public void Update(QuizzDTO c)
        {
            using (MyContext context = new MyContext())
            {

                Quizz QuizDB = context.Quizzes.Find(c.Id); //
                if (QuizDB != null)
                {
                    QuizDB.Title = c.Title;
                    /*QuizDB. = c.Email;
                    QuizDB.Password = c.Password;
                    */
                    //Appel des setters => etat = Modified
                    context.SaveChanges();
                }


            }
        }
    }
}