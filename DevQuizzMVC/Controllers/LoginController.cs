using DevQuizzMVC.DTO;
using DevQuizzMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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

        public ActionResult ResetPassword()
        {
            return View(new UserDTO());
        }
        [HttpPost]
        public ActionResult ResetPassword(UserDTO dto)
        {
            if (ModelState.IsValidField("Email"))
            {
                //Vérifier que user existe en BD
                UserDTO userDB = service.getAllUsers().SingleOrDefault(u => u.Email.Equals(dto.Email));
                if (userDB != null)
                {
                    //Envoi de mail de réinitialisation
                    //Utilisation du système de codage Base64 pour l'adresse Email
                    string emailCoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(dto.Email));

                    //Envoyer un email qui contient l'adresse de réinitialisation du password
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("phrad.sainha@gmail.com");
                    msg.To.Add(dto.Email);
                    msg.Subject = "Réinitialisation du mot de passe";

                    string body = "Pour réinitialiser votre mot de passe cliquez sur le lien: http://localhost:62515/Login/Reset?key=" + emailCoded;

                    msg.Body = body;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = new NetworkCredential("phrad.sainha@gmail.com", "1234dawan");
                    smtp.EnableSsl = true;
                    smtp.Send(msg);

                    return View("Confirmation");
                }
                else
                {
                    ViewBag.Error = "Utilisateur inconnu";
                    return View(dto);
                }
            }
            else
            {
                ViewBag.Error = "Utilisateur inconnu";
                return View(dto);
            }
            
        }

        [Route("Reset/{key}")]
        public ActionResult Reset(string key)
        {
            //Décoder l'email

            string email = Encoding.UTF8.GetString(Convert.FromBase64String(key));

            //Vérifier que le user existe
            UserDTO userDB = service.getAllUsers().SingleOrDefault(u => u.Email.Equals(email));
            if (userDB != null)
            {
                Session["email"] = email;
                return View("Reinitialisation");
            }
            else
            {
                return View("UserInconnu");
            }
        }

        [HttpPost]
        public ActionResult NewPassword(FormCollection form)
        {
            string password = form.Get("password");
            string ConfimPassword = form.Get("ConfimPassword");

            if (password.Equals(ConfimPassword))
            {
                ViewBag.Error = "Les deux mots de passe sont différents";
                return View("Reinitialisation");
            }

            string email = (string)Session["email"];
            UserDTO userDB = service.getAllUsers().SingleOrDefault(u => u.Email.Equals(email));
            userDB.Password = password;
            service.Update(userDB);
            return RedirectToAction("Index");
        }


    }
}