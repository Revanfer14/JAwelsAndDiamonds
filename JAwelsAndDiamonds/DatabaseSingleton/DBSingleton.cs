using JAwelsAndDiamonds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.DatabaseSingleton
{
    public class DBSingleton
    {
        private static DiamondEntitiesEntities1 instance;

        public static DiamondEntitiesEntities1 getInstance()
        {
            if (instance == null)
            {
                instance = new DiamondEntitiesEntities1();
            }

            return instance;
        }
    }
}