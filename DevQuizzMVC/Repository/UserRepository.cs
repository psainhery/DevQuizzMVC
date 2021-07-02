using DevQuizzMVC.DTO;
using DevQuizzMVC.Models;
using DevQuizzMVC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.Repository
{
    public class UserRepository
    {
        public UserDTO findUserByEmailAndPassword(UserDTO dto)
        {
            UserDTO user = new UserDTO();
            //verification fonctionnement hashPassword
            using (MyContext context = new MyContext())
            {
                User model = context.Users.FirstOrDefault(x => x.Email.Equals(dto.Email) &&
                x.Password.Equals(HashTool.hashPassword(dto.Password)));
                if (model != null && model.Id != 0)
                {
                    user = Convertisseur.UserDtoFromUser(dto, model);
                }

            }
            return user;
        }
    }
}