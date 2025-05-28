using JAwelsAndDiamonds.Models;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Handlers
{
    public class JewelHandlers
    {
        public static List<MsJewel> GetAllJewels()
        {
            return JewelRepositories.displayJewels();
        }

        public static MsJewel GetJewelById(int jewelId)
        {
            return JewelRepositories.getJewel(jewelId);
        }

        public static dynamic GetJewelDetails(int jewelId)
        {
            return JewelRepositories.showJewelDetails(jewelId);
        }

        public static void DeleteJewel(int jewelId)
        {
            JewelRepositories.deleteJewel(jewelId);
        }

        public static List<MsBrand> GetAllBrands()
        {
            return JewelRepositories.brandTypes();
        }

        public static List<MsCategory> GetAllCategories()
        {
            return JewelRepositories.categoryTypes();
        }

        public static void UpdateJewel(int jewelId, string jewelName, int jewelPrice,
           int releaseYear, int brandId, int categoryId)
        {
            JewelRepositories.updateJewel(jewelId, jewelName, jewelPrice, releaseYear, brandId, categoryId);
        }

        public static void CreateJewel(string jewelName, int jewelPrice,
            int releaseYear, int brandId, int categoryId)
        {
            JewelRepositories.addJewel(jewelName, jewelPrice, releaseYear, brandId, categoryId);
        }
    }
}