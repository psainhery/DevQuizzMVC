using DevQuizzMVC.DTO;
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
    }
}