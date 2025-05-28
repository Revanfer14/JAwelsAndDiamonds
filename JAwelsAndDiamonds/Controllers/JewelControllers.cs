using JAwelsAndDiamonds.Handlers;
using JAwelsAndDiamonds.Models;
using JAwelsAndDiamonds.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Controllers
{
    public class JewelControllers
    {
        public static List<MsJewel> GetJewels()
        {
            return JewelHandlers.GetAllJewels();
        }

        public static dynamic GetJewelDetails(int jewelId)
        {
            return JewelHandlers.GetJewelDetails(jewelId);
        }

        public static MsJewel GetJewel(int jewelId)
        {
            return JewelHandlers.GetJewelById(jewelId);
        }

        public static void DeleteJewel(int jewelId)
        {
            JewelHandlers.DeleteJewel(jewelId);
        }
        public static List<MsBrand> GetBrands()
        {
            return JewelHandlers.GetAllBrands();
        }
        public static List<MsCategory> GetCategories()
        {
            return JewelHandlers.GetAllCategories();
        }
        public static void UpdateJewel(int jewelId, string jewelName, int jewelPrice,
            int releaseYear, int brandId, int categoryId)
        {
            JewelHandlers.UpdateJewel(jewelId, jewelName, jewelPrice, releaseYear, brandId, categoryId);
        }

        public static void CreateJewel(string jewelName, int jewelPrice,
            int releaseYear, int brandId, int categoryId)
        {
            JewelHandlers.CreateJewel(jewelName, jewelPrice, releaseYear, brandId, categoryId);
        }

        public static bool ValidateCreateJewel(string name, int price, int year, int brandId, int categoryId, out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 25)
            {
                errorMessage = "Jewel name must be between 3 and 25 characters.";
                return false;
            }

            if (price < 25)
            {
                errorMessage = "Price must be greater than $25 and a number.";
                return false;
            }

            if (year > DateTime.Now.Year)
            {
                errorMessage = "Year must be less than or equal to the current year and a number.";
                return false;
            }

            CreateJewel(name, price, year, brandId, categoryId);
            return true;
        }

        public static bool ValidateUpdateJewel(int jewelId, string name, int price, int year, int brandId, int categoryId, out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 25)
            {
                errorMessage = "Jewel name must be between 3 and 25 characters.";
                return false;
            }

            if (price < 25)
            {
                errorMessage = "Price must be greater than $25 and a number.";
                return false;
            }

            if (year > DateTime.Now.Year)
            {
                errorMessage = "Year must be less than or equal to the current year and a number.";
                return false;
            }

            UpdateJewel(jewelId, name, price, year, brandId, categoryId);
            return true;
        }
    }
}