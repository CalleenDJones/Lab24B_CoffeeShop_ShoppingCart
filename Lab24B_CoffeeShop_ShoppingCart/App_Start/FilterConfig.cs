﻿using System.Web;
using System.Web.Mvc;

namespace Lab24B_CoffeeShop_ShoppingCart
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}