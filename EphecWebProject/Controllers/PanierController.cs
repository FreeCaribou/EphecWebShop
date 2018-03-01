using EphecWebProject.DAL.DataAccess;
using EphecWebProject.Models;
using EphecWebProject.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EphecWebProject.Controllers
{
    public class PanierController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListePanier()
        {
            Dictionary<int, ArticlePanier> panier;
            if (Session["PANIER"] == null)
            {
                panier = new Dictionary<int, ArticlePanier>();
            }
            else
            {
                panier = (Dictionary<int, ArticlePanier>)Session["PANIER"];
            }
            List<ArticlePanier> panierToReturn = new List<ArticlePanier>();
            foreach (var item in panier)
            {
                panierToReturn.Add(item.Value);
            }

            return PartialView("_ListePanier",panierToReturn);
        }

        public ActionResult AjoutArticlePanier(int idArticle)
        {
            Article article = ArticleAccess.Article(idArticle);
            Dictionary<int, ArticlePanier> panier;

            if (article.ART_Stock <= 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                if (Session["PANIER"] == null)
                {
                    panier = new Dictionary<int, ArticlePanier>();
                    panier.Add(idArticle, new ArticlePanier
                    {
                        IdArticle = idArticle,
                        QuantiteArticle = 1,
                        LibelleArticle = article.ART_Libelle,
                        PrixUnitaire = article.ART_Prix
                    });
                    Session["PANIER"] = panier;
                }
                else
                {
                    panier = (Dictionary<int, ArticlePanier>)Session["PANIER"];
                    if (panier.ContainsKey(idArticle))
                    {
                        panier[idArticle].QuantiteArticle++;
                    }
                    else
                    {
                        panier.Add(idArticle, new ArticlePanier
                        {
                            IdArticle = idArticle,
                            QuantiteArticle = 1,
                            LibelleArticle = article.ART_Libelle,
                            PrixUnitaire = article.ART_Prix
                        });
                    }
                    Session["PANIER"] = panier;
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult DiminuerArticlePanier(int idArticle)
        {
            Dictionary<int, ArticlePanier> panier;
            panier = (Dictionary<int, ArticlePanier>)Session["PANIER"];
            if (panier.ContainsKey(idArticle))
            {
                panier[idArticle].QuantiteArticle--;
                if (panier[idArticle].QuantiteArticle == 0)
                {
                    panier.Remove(idArticle);
                }
                Session["PANIER"] = panier;
            }
 
            List<ArticlePanier> panierToReturn = new List<ArticlePanier>();
            foreach (var item in panier)
            {
                panierToReturn.Add(item.Value);
            }
            return PartialView("_ListePanier", panierToReturn);
        }

        public ActionResult AugmenterArticlePanier(int idArticle)
        {
            Dictionary<int, ArticlePanier> panier;
            panier = (Dictionary<int, ArticlePanier>)Session["PANIER"];
            Article article = ArticleAccess.Article(idArticle);
            if (panier.ContainsKey(idArticle))
            {
                if((panier[idArticle].QuantiteArticle + 1) <= article.ART_Stock)
                {
                    panier[idArticle].QuantiteArticle++;
                    Session["PANIER"] = panier;
                }
            }
                
            List<ArticlePanier> panierToReturn = new List<ArticlePanier>();
            foreach (var item in panier)
            {
                panierToReturn.Add(item.Value);
            }
            return PartialView("_ListePanier", panierToReturn);
        }

        public ActionResult CommanderPanier()
        {
            if (Session["CLIENT"] != null)
            {
                return RedirectToAction("CommanderPanier", "Commande");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

    }
}