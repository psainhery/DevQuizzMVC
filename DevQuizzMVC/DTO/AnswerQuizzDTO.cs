using DevQuizzMVC.Models;
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

        /*public static explicit operator AnswerQuizzDTO(List<AnswerQuizz> v)
        {
            throw new NotImplementedException();
        }*/
        //Besoin ou pas??
        public  virtual QuestionQuizz QuestionQuizz { get; set; }
    }
}