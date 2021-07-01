using DevQuizzMVC.DTO;
using DevQuizzMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.Tools
{
    public class Convertisseur
    {
        public static UserDTO UserDtoFromUser(UserDTO dto, User model)
        {
            dto.Id = model.Id;
            dto.Email = model.Email;
            dto.Password = model.Password;
            dto.isAdmin = model.isAdmin;
            return dto;
        }
    }
}