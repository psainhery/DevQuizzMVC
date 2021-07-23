using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.Models
{
    
    public class QuestionQuizz
    {

        public int Id { get; set; }
        public string QuestionText { get; set; }
        public bool isMultiple { get; set; }
        public int QuizzId { get; set; }

        public int NumOrder { get; set; }
        public virtual Quizz Quizz { get; set; }
        public virtual List<AnswerQuizz> AnswersQuizz { get; set; }
        public QuestionQuizz()
        {
            AnswersQuizz = new List<AnswerQuizz>();
        }

    }
}