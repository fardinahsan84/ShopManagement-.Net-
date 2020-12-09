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
    public class OrderController : Controller
    {
        IRepository<Sale> usrRepo = new SaleRepository();


        public ActionResult Index()
        {
            if (Session["empId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View(usrRepo.GetAll());
            }
        }
   
    }
}