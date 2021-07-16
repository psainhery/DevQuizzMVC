﻿using DevQuizzMVC.DTO;
using DevQuizzMVC.Models;
using DevQuizzMVC.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DevQuizzMVC.Controllers
{
    public class UserController : Controller
    {
         private UserService service = new UserService();
        // GET: UserManagement
        public ActionResult Index(string search, int? i, string sortBy)
        {
            List<UserDTO> lst = new List<UserDTO>();
            if (search != null)
                lst = service.getAllUsers().Where(u => u.Name.Contains(search)).ToList();
            else
                lst = service.getAllUsers();
            //Tri
            switch (sortBy)
            {
                case "nameAsc":
                    lst = lst.OrderBy(x => x.Name).ToList();
                    break;
                case "nameDesc":
                    lst = lst.OrderByDescending(x => x.Name).ToList();
                    break;
                case null:
                    break;
                default:
                    break;
            }
            
            return View(lst.ToPagedList(i ?? 1, 5));
        }
       

        public ActionResult Create()
        {
            return View(new UserDTO());
        }
        // POST: Utilisateur/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Password,isAdmin")] UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                service.Add(userDTO);
                return RedirectToAction("Index");
            }
            return View(userDTO);
        }

    
        public ActionResult Delete(int id)
        {
            //using with ressources

            using (MyContext context = new MyContext())
            {
                User c = context.Users.Find(id);
               
                if (c != null)
                {
                    context.Users.Remove(c);

                    context.SaveChanges();
                   
                }
                else
                {
                    Console.WriteLine("erreur ");
                }
                return RedirectToAction("index");

            } 



        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO userDTO = service.getUserDTOById(id);
            if (userDTO == null)
            {
                return HttpNotFound();
            }
            //return RedirectToAction("detailsUser");
            return View(userDTO);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,isAdmin,Email")] UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                service.Update(userDTO);
                return RedirectToAction("Index");
            }
            return View(userDTO);
        }
        


    }
}