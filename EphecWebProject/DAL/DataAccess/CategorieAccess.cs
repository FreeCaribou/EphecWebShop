using EphecWebProject.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EphecWebProject.DAL.DataAccess
{
    public static class CategorieAccess
    {

        static WebShopContext db = new WebShopContext();

        public static List<Categorie> ListeCategorie()
        {
            List<Categorie> categories = db.Categories.ToList();
            return categories;
        }
    }
}