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
        public string Picture { get; set; }
        //Besoin ou pas??
        public  virtual QuizzCategory QuizzCategory { get; set; }

        public virtual List<QuestionQuizzDTO> QuestionsQuizzDTO { get; set; }
        

        public QuizzDTO()
        {
            QuestionsQuizzDTO = new List<QuestionQuizzDTO>();
        }
    }
}