using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [Required(ErrorMessage ="Email obligatoire")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mot de passe obligatoire")]
        public string Password { get; set; }

        public bool isAdmin { get; set; }

    }
}
