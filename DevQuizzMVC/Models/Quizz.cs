using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.Models
{
    
    public class Quizz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public QuizzCategory QuizzCategory { get; set; }

        public  List<QuestionQuizz> QuestionsQuizz { get; set; }

        public Quizz()
        {
            QuestionsQuizz = new List<QuestionQuizz>();
        }
            
    }
}