using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.DTO
{
    public class AnswerQuizzDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="une réponse est requise")]
        public string AnswerText { get; set; }
        [Required(ErrorMessage = "Le type de réponse est requis")]
        public bool isCorrect { get; set; }
        public int QuestionQuizzId { get; set; }
        //Besoin ou pas??
        //public QuestionQuizz QuestionQuizz { get; set; }
    }
}