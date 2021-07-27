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
            foreach(QuestionQuizz question in model.QuestionsQuizz)
            {
                QuestionQuizzDTO qDTO = new QuestionQuizzDTO();
                dto.QuestionsQuizzDTO.Add(QuestionQuizzDTOFromQuestionQuizz(qDTO, question));
            }
            return dto;
        }

        public static Quizz QuizzFromQuizzDto(QuizzDTO dto, Quizz model)
        {
            model.Id = dto.Id;
            model.Title = dto.Title;
            model.CategoryId = dto.CategoryId;
            model.QuizzCategory = dto.QuizzCategory;
            foreach (QuestionQuizzDTO question in dto.QuestionsQuizzDTO)
            {
                QuestionQuizz q = new QuestionQuizz();
                model.QuestionsQuizz.Add(QuestionQuizzFromQuestionQuizzDTO(question, q));
            }
            return model;
        }

        public static QuestionQuizzDTO QuestionQuizzDTOFromQuestionQuizz(QuestionQuizzDTO dto, QuestionQuizz model)
        {
            dto.Id = model.Id;
            dto.QuestionText = model.QuestionText;
            dto.isMultiple = model.isMultiple;
            dto.QuizzId = model.QuizzId;
            dto.Quizz = model.Quizz;
            List<AnswerQuizzDTO> lstDto = new List<AnswerQuizzDTO>();
            foreach (AnswerQuizz reponse in model.AnswersQuizz)
            {
                //AnswerQuizzDTO an = new AnswerQuizzDTO();
                lstDto.Add(AnswerQuizzDTOFromAnswerQuizz(new AnswerQuizzDTO(), reponse));
            }
            dto.AnswersQuizzDTO = lstDto;
            dto.NumOrder = model.NumOrder;
            return dto;
        }

        public static QuestionQuizz QuestionQuizzFromQuestionQuizzDTO(QuestionQuizzDTO dto, QuestionQuizz model)
        {
            model.Id = dto.Id;
            model.QuestionText = dto.QuestionText;
            model.isMultiple = dto.isMultiple;
            model.NumOrder = dto.NumOrder;
            model.QuizzId = dto.QuizzId;
            model.Quizz = dto.Quizz;
            List<AnswerQuizz> lstDto = new List<AnswerQuizz>();
            foreach (AnswerQuizzDTO answer in dto.AnswersQuizzDTO)
            {
                //AnswerQuizz aDTO = new AnswerQuizz();
                lstDto.Add(AnswerQuizzFromAnswerQuizzDTO(answer, new AnswerQuizz()));
            }
            model.AnswersQuizz = lstDto;
            model.NumOrder = dto.NumOrder;
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

        public static AnswerQuizz AnswerQuizzFromAnswerQuizzDTO(AnswerQuizzDTO dto, AnswerQuizz model)
        {
            model.Id = dto.Id;
            model.AnswerText = dto.AnswerText;
            model.isCorrect = dto.isCorrect;
            model.QuestionQuizzId = dto.QuestionQuizzId;
            return model;
        }
    }
}