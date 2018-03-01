using EphecWebProject.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EphecWebProject.DAL.DataAccess
{
    public static class SousCategorieAccess
    {

        static WebShopContext db = new WebShopContext();

        public static List<SousCategorie> ListeSousCategorie(int idCategorie)
        {
            List<SousCategorie> listeSousCategories;
            if (idCategorie == 0)
            {
                listeSousCategories = db.SousCategories.ToList();
            }
            else
            {
                listeSousCategories = db.SousCategories.Where(sc => sc.SCAT_CAT_Id == idCategorie).ToList();
            }
            return listeSousCategories;
        }

        


    }
}