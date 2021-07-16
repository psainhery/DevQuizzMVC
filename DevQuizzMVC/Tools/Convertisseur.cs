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

      
        public static QuestionQuizzDTO QuestionQuizzDTOFromQuestionQuizz(QuestionQuizzDTO dto, QuestionQuizz model)
        {
            dto.Id = model.Id;
            dto.QuestionText = model.QuestionText;
            dto.isMultiple = model.isMultiple;
            dto.QuizzId = model.QuizzId;
            dto.Quizz = model.Quizz;
            dto.AnswersQuizz = model.AnswersQuizz;
            return dto;
        }

        public static QuestionQuizz QuestionQuizzFromQuestionQuizzDTO(QuestionQuizzDTO dto, QuestionQuizz model)
        {
            model.Id = dto.Id;
            model.QuestionText = dto.QuestionText;
            model.isMultiple = dto.isMultiple;
            model.QuizzId = dto.QuizzId;
            model.Quizz = dto.Quizz;
            model.AnswersQuizz = dto.AnswersQuizz;
            return model;
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

        public static AnswerQuizzDTO AnswerQuizzDTOFromAnswerQuizz(AnswerQuizzDTO dto, AnswerQuizz model)
        {
            dto.Id = model.Id;
            dto.AnswerText = model.AnswerText;
            dto.isCorrect = model.isCorrect;
            dto.QuestionQuizzId = model.QuestionQuizzId;
            return dto;
        }
    }
}