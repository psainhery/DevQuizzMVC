using DevQuizzMVC.DTO;
using DevQuizzMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevQuizzMVC.Controllers
{
    public class LoginController : Controller
    {
        private UserService service = new UserService();
        public ActionResult Accueil()
        {
            return View();
        }

        // GET: Login
        public ActionResult Index()
        {
            UserDTO dto = new UserDTO(); 
            return View(dto);
        }
        [HttpPost]
        public ActionResult Index(UserDTO dto)
        {
           
            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                UserDTO user = service.findUserByEmailAndPassword(dto);
                if (user != null && user.Id != 0)
                {
                    if (user.isAdmin)
                    {
                        Session["userAdmin"] = user;
                        return RedirectToAction("Accueil");
                    }
                    else
                    {
                        //TODO
                        //return RedirectToAction("Accueil");
                        Session["userNormal"] = user;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.Erreur = "Echec connexion.....";
                    return View(dto);
                }
            }
            else
            {
                return View(dto);
            }
            
        }

        public ActionResult Logout()
        {
            //Session["userAdmin"] = null;
            //Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index");
        }



    }
}