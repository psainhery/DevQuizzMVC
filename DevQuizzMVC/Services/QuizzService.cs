using DevQuizzMVC.DTO;
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
    }
}