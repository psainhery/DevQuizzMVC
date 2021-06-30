using DevQuizzMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.DTO
{
    public class QuizzCategoryDTO
    {
        public int Id { get; set; }
        public List<Quizz> Quizzs { get; set; }
        [Required(ErrorMessage = "La categorie est requise")]
        public string Name { get; set; }
    }
}