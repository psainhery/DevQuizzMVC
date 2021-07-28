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
                //User model = context.Users.FirstOrDefault(x => x.Email.Equals(dto.Email) &&
                //x.Password.Equals(HashTool.hashPassword(dto.Password)));

                User model = context.Users.FirstOrDefault(x => x.Email.Equals(dto.Email) &&
                x.Password.Equals(dto.Password));


                if (model != null && model.Id != 0)
                {
                    user = Convertisseur.UserDtoFromUser(dto, model);
                }

            }
            return user;
        }

        public void Add(UserDTO userDTO)
        {
            User u = Convertisseur.UserFromUserDTO(userDTO, new User());
            using (MyContext context = new MyContext())
            {
                context.Users.Add(u);
                context.SaveChanges();
            }
        }

        public List<UserDTO> getAllUsers()
        {
            List<UserDTO> lst = new List<UserDTO>();
            //UserDTO dto = new UserDTO(); 
            using (MyContext context = new MyContext())
            {
                List<User> lstModel = context.Users.ToList();
                foreach (User model in lstModel)
                {
                    lst.Add(Convertisseur.UserDtoFromUser(new UserDTO(), model));
                }
            }
            return lst;
        }

        public void DeleteUserDTO(int id)
        {
            using (MyContext context = new MyContext())
            {
                User q = context.Users.Find(id);
                context.Users.Remove(q);
                context.SaveChanges();
            }
        }

        public UserDTO getUserDTOById(int? id)
        {
            UserDTO dto = new UserDTO();
            using (MyContext context = new MyContext())
            {
                User model = context.Users.Find(id);
                if (model != null)
                {
                    dto = Convertisseur.UserDtoFromUser(dto, model);
                }
            }
            return dto;
        }

    }
}