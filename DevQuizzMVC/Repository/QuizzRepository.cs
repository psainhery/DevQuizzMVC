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
    }
}