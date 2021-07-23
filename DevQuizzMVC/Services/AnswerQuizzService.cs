using DevQuizzMVC.DTO;
using DevQuizzMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.Services
{
    public class AnswerQuizzService
    {
        private AnswerQuizzRepository repo = new AnswerQuizzRepository();

        public List<AnswerQuizzDTO> GetAllAnswers()
        {
            return repo.GetAllAnswers();
        }

        public AnswerQuizzDTO getAnswerDTOById(int? id)
        {
            return repo.getAnswerDTOById(id);
        }

        public void Update(AnswerQuizzDTO answerQuizzDTO)
        {
            repo.Update(answerQuizzDTO);
        }

        public void DeleteAnswerDTO(int id)
        {
            repo.DeleteAnswerDTO(id);
        }

        public void Add(AnswerQuizzDTO answerQuizzDTO)
        {
            repo.Add(answerQuizzDTO);
        }

       
    }
}