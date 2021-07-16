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
    }
}