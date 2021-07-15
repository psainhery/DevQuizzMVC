using DevQuizzMVC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevQuizzMVC.Controllers
{
    public class CreateAccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View(new UserDTO());
        }
        [HttpPost]
        public ActionResult Index(UserDTO userDTO)
        {
            return View(userDTO);
        }
    }
    
}