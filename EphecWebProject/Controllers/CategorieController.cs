using EphecWebProject.DAL.DataAccess;
using EphecWebProject.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EphecWebProject.Controllers
{
    public class CategorieController : Controller
    {

        public ActionResult ListeCategorie()
        {
            return PartialView("_ListeCategorie", CategorieAccess.ListeCategorie());
        }

        public ActionResult ListeCategoriePourEdit()
        {
            return PartialView("_ListeCategoriePourEdit", CategorieAccess.ListeCategorie());
        }
    }
}