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
            dto.Name = model.Name;
            dto.Email = model.Email;
            dto.Password = model.Password;
            dto.isAdmin = model.isAdmin;
            return dto;
        }

        public static User UserFromUserDTO(UserDTO dto, User model)
        {
            model.Id = dto.Id;
            model.Name = dto.Name;
            model.Email = dto.Email;
            model.Password = dto.Password;
            model.isAdmin = dto.isAdmin;
            return model;
        }
    }
}