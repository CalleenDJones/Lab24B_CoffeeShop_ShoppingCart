using Lab24B_CoffeeShop_ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab24B_CoffeeShop_ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MenuList()
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            List<Item> items = ORM.items.ToList();
            //ViewBag.Items = ORM.items.ToList();
            //ViewBag.Items = Item;
            ViewBag.Items = items;

            return View();
        }

        public ActionResult MenuListbyID(int itemID)
        {
            //@foreach(Item item in ViewBag.Items)
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            List<Item> items = (from item in ORM.items
                                where item.ItemID == itemID
                                select item).ToList();
            ViewBag.Items = items;
            return View("MenuList");
        }

        public ActionResult MenuListbyItemName(string itemName)
        {
            //@foreach(Item item in ViewBag.Items)
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            List<Item> items = (from item in ORM.items
                                where item.ItemName.Contains(itemName)
                                select item).ToList();
            ViewBag.Items = items;
            ViewBag.ItemNames = ORM.items.ToList();
            return View("MenuList");
        }

        public ActionResult MenuListbyDescription(string description)
        {
            //@foreach(Item item in ViewBag.Items)
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            List<Item> items = (from item in ORM.items
                                where item.Description.Contains(description)
                                select item).ToList();
            ViewBag.Items = items;
            ViewBag.Description = ORM.items.ToList();
            return View("MenuList");
        }

        public ActionResult MenuListbyPrice(int price)
        {
            //@foreach(Item item in ViewBag.Items)
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            List<Item> items = (from item in ORM.items
                                where item.Price == price
                                select item).ToList();
            ViewBag.Items = items;
            ViewBag.Price = ORM.items.ToList();
            return View("MenuList");
        }

        public ActionResult MenuListbyQuantity(int quantity)
        {
            //@foreach(Item item in ViewBag.Items)
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            List<Item> items = (from item in ORM.items
                                where item.Quantity == quantity
                                select item).ToList();
            ViewBag.Items = items;
            ViewBag.Quantity = ORM.items.ToList();
            return View("MenuList");
        }

        //public ActionResult MenuListSorted(string column)
        //{
        //    CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
        //    if (column == "ItemName")
        //    {
        //        List<Item> items = (from item in ORM.items
        //                            orderby item.ItemName
        //                            select item).ToList();
        //    }

        //    else if (column == "Description")
        //    {
        //        List<Item> items = (from item in ORM.items
        //                            orderby item.Description
        //                            select item).ToList();
        //    }

        //    else if (column == "Price")
        //    {
        //        List<Item> items = (from item in ORM.items
        //                            orderby item.Price
        //                            select item).ToList();
        //    }
        //    else if (column == "Quantity")
        //    {
        //        List<Item> items = (from item in ORM.items
        //                            orderby item.Quantity
        //                            select item).ToList();
        //    }
        //    else
        //    {
        //        ViewBag.ItemID = ORM.items.ToList();
        //        return View("MenuList");
        //    }
        //}

        public ActionResult Add(int id)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
           
            //check if the Cart object already exists
            if (Session["Cart"] == null)
            {
                //if it doesn't, make a new list of books
                List<Item> cart = new List<Item>();
                //add this book to it
                cart.Add((from item in ORM.items
                          where item.ItemID == id
                          select item).Single());
                //add the list to the session
                Session.Add("Cart", cart);
            }
            else
            {
                //if it does exist, get the list
                List<Item> cart = (List<Item>)(Session["Cart"]);
                //add this book to it
                cart.Add((from item in ORM.items
                          where item.ItemID == id
                          select item).Single());
            }
            return View();
        }

    }
}
    
