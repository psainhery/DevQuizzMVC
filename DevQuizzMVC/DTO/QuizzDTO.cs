using DevQuizzMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.DTO
{
    public class QuizzDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Titre obligatoire")]
        public string Title { get; set; }
        public int CategoryId { get; set; }
        //Besoin ou pas??
        //public QuizzCategory QuizzCategory { get; set; }

        public List<QuestionQuizz> QuestionsQuizz { get; set; }
    }
}