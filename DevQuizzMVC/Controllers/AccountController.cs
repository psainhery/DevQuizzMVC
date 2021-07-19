using DevQuizzMVC.DTO;
using DevQuizzMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevQuizzMVC.Controllers
{
    public class AccountController : Controller
    {
        private UserService service = new UserService();
        // GET: Account
        public ActionResult Index()
        {
            UserDTO dto = new UserDTO();
            return View(dto);
        }
        [HttpPost]
        public ActionResult Index(UserDTO dto)
        {
            if (ModelState.IsValid)
            {
                service.Add(dto);
                return RedirectToAction("registrationSuccess", "Account");
            }
            else
            {
                return View(dto);
            }
            return View(dto);



        }
        public ActionResult registrationSuccess()
        {
            return View();
        }
    }
}