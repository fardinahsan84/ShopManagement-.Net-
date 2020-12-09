using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShopMngmnt.Model;
using CoffeeShopMngmnt.Interface;
using CoffeeShopMngmnt.Repository;

namespace CoffeeShopMngmnt.Controllers
{
    public class AdminController : Controller
    {
        IRepository<User> usrRepo = new UserRepository();


        public ActionResult Index()
        {
            if (Session["usrId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
           {
                return View(usrRepo.GetAll());
            }
        }

        public ActionResult Details(int id)
        {
            if (Session["usrId"] == null)
            {
                return RedirectToAction("Login","User");
            }
            else
            {
                var admin = usrRepo.GetAll().SingleOrDefault(x => x.UserId == id);
                return View(admin);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["usrId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View(usrRepo.Get(id));
            }
        }

        [HttpPost]
        public ActionResult Edit(FormCollection Form, User d, int id)
        {
           
            if (ModelState.IsValid)
            {
                if (Form["Username"] != null &&
                 Form["Password"] != null &&
                Form["Phone"] != null &&
                Form["Address"] != null &&
                Form["Email"] != null)
                {
                    d = usrRepo.Get(id);

                    d.Username = Form["Username"];
                    d.Password = Form["Password"];
                    d.Phone = Form["Phone"];
                    d.Address = Form["Address"];
                    d.Email = Form["Email"];
                    d.UserType = "employee";
                    usrRepo.Update(d);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewData["NullEntry"] = "all field required";
                    return View("Edit");
                }
            }
            else
            {
                return View("Edit");
            }
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["usrId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View();
            }
        }

        [HttpPost, ActionName("Create")]
        public ActionResult Signup(User d, FormCollection Form)
        {
           
            if (ModelState.IsValid)
            {
                if (Form["Username"] != null &&
                 Form["Password"] != null &&
                Form["Phone"] != null &&
                Form["Address"] != null &&
                Form["Email"] != null &&
                Form["UserType"] != null )
                {

                    d.Username = Form["Username"];
                    d.Password = Form["Password"];
                    d.Phone = Form["Phone"];
                    d.Address = Form["Address"];
                    d.Email = Form["Email"];
                    d.UserType = "employee";
                    usrRepo.Insert(d);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["NullEntry"] = "all field required";
                    return View("Create");
                }
            }
            else
            {
                return View("Create");
            }
            
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["usrId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View(usrRepo.Get(id));
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            usrRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult SaleInformation()
        {
            return RedirectToAction("Index","Sale");
        }

         public ActionResult ItemInformation()
        {
            return RedirectToAction("Index","Item");
        }

         public ActionResult Logout ()
         {
             Session["usrId"] = null;
             return RedirectToAction("Login","User");
         }
    }
}
