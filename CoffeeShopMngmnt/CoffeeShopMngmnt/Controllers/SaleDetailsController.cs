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
    public class SaleDetailsController : Controller
    {
        IRepository<Sale_Detail> saleDetailRepo = new SaleDetailRepository();


        public ActionResult Index(int id)
        {
            if (Session["usrId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                List<Sale_Detail> list = saleDetailRepo.GetAll().Where(c => c.Order_Number == id).ToList();
                Session["saleDetail"] = list;
                Session["OrderId"] = id;
                return View(saleDetailRepo.GetAll());
            }
        }

        public ActionResult Back()
        {
            return RedirectToAction("Index","Sale");
        }
    }
}