using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.Models
{
    
    public class QuizzCategory
    {
        public int Id { get; set; }
        public List<Quizz> Quizzs { get; set; }
        public string Name { get; set; }
        public QuizzCategory()
        {
            Quizzs = new List<Quizz>();
        }
    }
}