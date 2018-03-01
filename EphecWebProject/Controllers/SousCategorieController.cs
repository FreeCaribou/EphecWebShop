using EphecWebProject.DAL.DataAccess;
using EphecWebProject.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EphecWebProject.Controllers
{
    public class SousCategorieController : Controller
    {
        
        public ActionResult ListeSousCategorie(int idCategorie)
        {
            List<SousCategorie> sousCategories = SousCategorieAccess.ListeSousCategorie(idCategorie);
            return PartialView("_ListeSousCategorie", sousCategories);
        }

        public ActionResult ListeSousCategoriePourEdit(int idCategorie)
        {
            List<SousCategorie> sousCategories = SousCategorieAccess.ListeSousCategorie(idCategorie);
            return PartialView("_ListeSousCategoriePourEdit", sousCategories);
        }

    }
}