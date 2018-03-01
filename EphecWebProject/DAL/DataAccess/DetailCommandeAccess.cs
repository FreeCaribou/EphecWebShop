using EphecWebProject.Models;
using EphecWebProject.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EphecWebProject.DAL.DataAccess
{
    public static class DetailCommandeAccess
    {

        static WebShopContext db = new WebShopContext();

        public static List<DetailCommande> ListeDetailCommandeUneCommande(int idCommande)
        {
            List<DetailCommande> listeDetailCommande = db.DetailCommandes.Include("Article").Where(dc => dc.DCOM_COM_Id == idCommande).ToList();
            return listeDetailCommande;
        }

        public static DetailCommande CreateDetailCommande(int idCommande, ArticlePanier articlePanier)
        {
            ArticleAccess.DiminuerStockArticle(articlePanier.IdArticle, articlePanier.QuantiteArticle);
            DetailCommande detailCommande = new DetailCommande();
            detailCommande.DCOM_COM_Id = idCommande;
            detailCommande.DCOM_ART_Id = articlePanier.IdArticle;
            detailCommande.DCOM_PrixUnitaire = articlePanier.PrixUnitaire;
            detailCommande.DCOM_Quantite = articlePanier.QuantiteArticle;
            db.DetailCommandes.Add(detailCommande);
            db.SaveChanges();
            return detailCommande;
        }

    }
}