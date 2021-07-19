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


        [Required(ErrorMessage = "Saisisser votre nom")]
        public string Name { get; set; }


        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Mot de passe obligatoire")]
        public string Password { get; set; }

        public bool isAdmin { get; set; }

    }
}
