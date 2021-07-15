using DevQuizzMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.DTO
{
    public class QuestionQuizzDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="La question est requise")]
        public string QuestionText { get; set; }
        [Required(ErrorMessage = "Specifiez le type du question")]
        public bool isMultiple { get; set; }
        public int QuizzId { get; set; }
        //Besoin ou pas??
        public Quizz Quizz { get; set; }
        public List<AnswerQuizz> AnswersQuizz { get; set; }
    }
}