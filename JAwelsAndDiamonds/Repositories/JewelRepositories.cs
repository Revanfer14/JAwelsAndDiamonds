using JAwelsAndDiamonds.DatabaseSingleton;
using JAwelsAndDiamonds.Factories;
using JAwelsAndDiamonds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Repositories
{
    public class JewelRepositories
    {
        static DiamondEntitiesEntities1 db = DBSingleton.getInstance();

        public static List<MsJewel> displayJewels()
        {
            return db.MsJewels.ToList();
        }

        public static MsJewel getJewel(int id)
        {
            return db.MsJewels.Find(id);
        }
        public static dynamic showJewelDetails(int id)
        {
            return db.MsJewels
                .Where(j => j.JewelID == id)
                .Select(j => new
                {
                    j.JewelID,
                    j.JewelName,
                    CategoryName = j.MsCategory.CategoryName,
                    BrandName = j.MsBrand.BrandName,
                    Country = j.MsBrand.BrandCountry,
                    BrandClass = j.MsBrand.BrandClass,
                    j.JewelPrice,
                    j.JewelReleaseYear
                }).FirstOrDefault();
        }
        public static void deleteJewel(int id)
        {
            MsJewel jewel = db.MsJewels.Find(id);

            db.MsJewels.Remove(jewel);
            db.SaveChanges();
        }

        public static List<MsBrand> brandTypes()
        {
            return db.MsBrands.ToList();
        }

        public static List<MsCategory> categoryTypes()
        {
            return db.MsCategories.ToList();
        }

        public static void updateJewel(int id, string name, int price, int year, int brandId, int categoryId)
        {
            MsJewel jewel = db.MsJewels.Find(id);
            jewel.JewelName = name;
            jewel.JewelPrice = price;
            jewel.JewelReleaseYear = year;
            jewel.BrandID = brandId;
            jewel.CategoryID = categoryId;
            db.SaveChanges();
        }

        public static void addJewel(string name, int price, int year, int brandId, int categoryId)
        {
            MsJewel jewel = JewelFactories.createJewel(name, price, year, brandId, categoryId);
            db.MsJewels.Add(jewel);
            db.SaveChanges();
        }
    }
}