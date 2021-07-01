using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.Models
{
    
    public class User
    {
        public int Id { get; set; }

        public string Name  { get; set; }
        //[Required]
        public string Email { get; set; }
        //[Required]
        public string Password { get; set; }

        public bool isAdmin { get; set; }


    }
}