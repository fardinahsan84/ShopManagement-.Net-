using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShopMngmnt.Repository;
using CoffeeShopMngmnt.Model;
using CoffeeShopMngmnt.Interface;

namespace CoffeeShopMngmnt.Controllers
{
    public class UserController : Controller
    {
        IRepository<User> usrRepo = new UserRepository();
        

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public ActionResult Signin(string Usename, string Password, FormCollection form)
        {
            if (usrRepo.GetAll().Where(c => c.Username == form["Username"].ToString() && c.Password == form["Password"].ToString()).FirstOrDefault() != null)
            {
                var user = usrRepo.GetAll().Where(c => c.Username == form["Username"].ToString() && c.Password == form["Password"].ToString()).FirstOrDefault();
                if (user.UserType == "admin")
                {
                    List<User> list = usrRepo.GetAll().Where(c => c.UserType== "employee").ToList();
                    Session["usrList"] = list;
                    Session["usrId"] = user.UserId;
                    Session["usrName"] = user.Username;
                    return RedirectToAction("Index", "Admin");
                }
                else //if(user.UserType=="admin")
                {
                    Session["empId"] = user.UserId;
                    Session["empName"] = user.Username;
                    return RedirectToAction("Index", "Employee", new { id = (int)Session["empId"] });
                }
               
            }
            else
            {
                ViewData["invalidlogin"] = "Invalid Login!Try Again";
                return View("Login");
            }
        }

        
    }
}