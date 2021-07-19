using DevQuizzMVC.DTO;
using DevQuizzMVC.Models;
using DevQuizzMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevQuizzMVC.Services
{
    public class UserService
    {
        private UserRepository repo = new UserRepository();
        public UserDTO findUserByEmailAndPassword(UserDTO dto)
        {
            UserDTO user = new UserDTO();
            user = repo.findUserByEmailAndPassword(dto);



            return user;
        }

        public List<UserDTO> getAllUsers()
        {
            return repo.getAllUsers();
        }

        public UserDTO getUserDTOById(int? id)
        {
            return repo.getUserDTOById(id);
        }

        public void Add(UserDTO userDTO)
        {
            repo.Add(userDTO);
        }
        public User details(int id)
        {
            User c = null;
            using (MyContext context = new MyContext())
            {
                c = context.Users.Find(id);
            }

            return c;
            
        }
        public void Update(UserDTO c)
        {
            using (MyContext context = new MyContext())
            {

                User UserDB = context.Users.Find(c.Id); //
                if (UserDB != null) 
                {
                    UserDB.Name = c.Name;
                    UserDB.Email = c.Email;
                    UserDB.Password = c.Password;

                    //Appel des setters => etat = Modified
                    context.SaveChanges();
                }


            }
        }
    }
}