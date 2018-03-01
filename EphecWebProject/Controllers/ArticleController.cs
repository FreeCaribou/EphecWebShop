using EphecWebProject.DAL.DataAccess;
using EphecWebProject.Models.DataModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EphecWebProject.Controllers
{
    public class ArticleController : Controller
    {

        public ActionResult ListeArticle(int idCategorie, int idSousCategorie)
        {
            List<Article> articles;
            if(idCategorie > 0)
            {
                Session.Add("CATEGORIE", idCategorie);
                Session.Add("SOUS-CATEGORIE", 0);
            }
            if(idSousCategorie > 0)
            {
                Session.Add("SOUS-CATEGORIE", idSousCategorie);
            }
            articles = ArticleAccess.ListeArticle(idCategorie, idSousCategorie);

            return PartialView("_ListeArticle", articles);
        }

        public ActionResult DetailArticle(int idArticle)
        {
            Article article = ArticleAccess.Article(idArticle);
            return View(article);
        }

    }
}