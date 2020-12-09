using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShopMngmnt.Model;
using CoffeeShopMngmnt.Repository;
using CoffeeShopMngmnt.Interface;

namespace CoffeeShopMngmnt.Controllers
{
    public class EmployeeController : Controller
    {
        IRepository<User> usrRepo = new UserRepository();

        public ActionResult Index(int id)
        {
            if (Session["empId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                var emp = usrRepo.GetAll().SingleOrDefault(x => x.UserId == id);
                return View(emp);
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["empId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View(usrRepo.Get(id));
            }
        }

        [HttpPost]
        public ActionResult Edit(FormCollection Form, User e, int id)
        {
            if (ModelState.IsValid)
            {
                e = usrRepo.Get(id);

                e.Username = Form["Username"];
                e.Password = Form["Password"];
                e.Phone = Form["Phone"];
                e.Address = Form["Address"];
                e.Email = Form["Email"];
                e.UserType = "employee";
                usrRepo.Update(e);
                return RedirectToAction("Index", "Employee", new { id = (int)Session["empId"] });
            }
            else
            {
                return View("Edit");
            }
        }
        public ActionResult Logout()
        {
            Session["empId"] = null;
            return RedirectToAction("Login", "User");
        }
    }
}