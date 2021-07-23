using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.Models
{
    
    public class AnswerQuizz
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool isCorrect { get; set; }
        public int QuestionQuizzId { get; set; }
        public virtual QuestionQuizz QuestionQuizz { get; set; }


    }
}