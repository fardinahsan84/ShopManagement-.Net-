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
    public class SaleController : Controller
    {
        IRepository<Sale> saleRepo = new SaleRepository();


        public ActionResult Index()
        {
            if (Session["usrId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View(saleRepo.GetAll());
            }
        }

      

        
        public ActionResult Back()
        {
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Details(int id)
        {
            if (Session["usrId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                var admin = saleRepo.GetAll().SingleOrDefault(x => x.Order_Number == id);
                //List<User> list = usrRepo.GetAll().Where(c => c.UserType == "employee").ToList();
                Session["empid"] = admin.EmployeeId;
                return RedirectToAction("Index", "SaleDetails", new { id = admin.Order_Number });
            }
        }
    }
}