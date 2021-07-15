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

        public static QuizzDTO QuizzDtoFromQuizz(QuizzDTO dto, Quizz model)
        {
            dto.Id = model.Id;
            dto.Title = model.Title;
            dto.CategoryId = model.CategoryId;
            dto.QuizzCategory = model.QuizzCategory;
            dto.QuestionsQuizz = model.QuestionsQuizz;
            return dto;
        }

        public static Quizz QuizzFromQuizzDto(QuizzDTO dto, Quizz model)
        {
            model.Id = dto.Id;
            model.Title = dto.Title;
            model.CategoryId = dto.CategoryId;
            model.QuizzCategory = dto.QuizzCategory;
            model.QuestionsQuizz = dto.QuestionsQuizz;
            return model;
        }
    }
}