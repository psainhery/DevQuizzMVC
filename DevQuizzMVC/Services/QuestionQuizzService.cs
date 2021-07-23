using DevQuizzMVC.DTO;
using System;
using System.Collections.Generic;

namespace DevQuizzMVC.Controllers
{
    public class QuestionQuizzService
    {
        private QuestionQuizzRepository repo = new QuestionQuizzRepository();

        public List<QuestionQuizzDTO> GetAllQuestions()
        {
            return repo.GetAllQuestions();
        }

        public QuestionQuizzDTO GetQuestionQuizzDTOById(int? id)
        {
            return repo.GetQuestionDTOByID(id);
        }

        public void Add(QuestionQuizzDTO questionQuizzDTO)
        {
            repo.Add(questionQuizzDTO);
        }

        public void Update(QuestionQuizzDTO questionQuizzDTO)
        {
            repo.Update(questionQuizzDTO);
        }

        public void DeleteQuestionQuizzDTO(int id)
        {
            repo.DeleteQuestionQuizzDTO(id);
        }

        internal QuestionQuizzDTO FindQuestion(int quizId, int ordre)
        {
            return repo.FindQuestion(quizId, ordre);
        }
    }
}