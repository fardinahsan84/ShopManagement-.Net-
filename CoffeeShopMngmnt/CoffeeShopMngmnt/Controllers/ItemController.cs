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
    public class ItemController : Controller
    {

        IRepository<Item> itmRepo = new ItemRepository();
        public ActionResult Index()
        {
            if (Session["usrId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View(itmRepo.GetAll());
            }
        }


        public ActionResult Details(int id)
        {
            if (Session["usrId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                var item = itmRepo.GetAll().SingleOrDefault(x => x.ItemId == id);
                return View(item);
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
                return View(itmRepo.Get(id));
            }
        }

        [HttpPost]
        public ActionResult Edit(FormCollection Form, Item i,float? ItemPrice, int id)
        {
            if (ModelState.IsValid)
            {
                i = itmRepo.Get(id);

                i.ItemName = Form["ItemName"];
                i.ItemPrice = (float)ItemPrice;
                
                itmRepo.Update(i);
                return RedirectToAction("Index", "Item");
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
        public ActionResult NewItem(Item i, FormCollection Form, float? ItemPrice)
        {
            if (ModelState.IsValid)
            {
 

                i.ItemName = Form["ItemName"];
                i.ItemPrice = (float)ItemPrice;
                itmRepo.Insert(i);
                return RedirectToAction("Index");

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
                return View(itmRepo.Get(id));
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            itmRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Back()
        {
            return RedirectToAction("Index", "Admin");
        }
    }
}