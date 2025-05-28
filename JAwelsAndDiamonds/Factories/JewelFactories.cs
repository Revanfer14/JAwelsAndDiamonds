using JAwelsAndDiamonds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Factories
{
    public class JewelFactories
    {
        public static MsJewel createJewel(string name, int price, int year, int brandId, int categoryId)
        {
            MsJewel jewel = new MsJewel();
            jewel.JewelName = name;
            jewel.JewelPrice = price;
            jewel.JewelReleaseYear = year;
            jewel.BrandID = brandId;
            jewel.CategoryID = categoryId;
            return jewel;
        }
    }
}