using EphecWebProject.Models.DataModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EphecWebProject.DAL.DataAccess
{
    public static class ArticleAccess
    {
        static WebShopContext db = new WebShopContext();

        public static List<Article> ListeArticle(int idCategorie, int idSousCategorie)
        {
            List<Article> articles = new List<Article>();
            if (idSousCategorie > 0)
            {
                articles = db.Articles.Include("SousCategorie").Where(a => a.SousCategorie.SCAT_Id == idSousCategorie).ToList();
            }
            else if (idCategorie > 0)
            {
                articles = db.Articles.Include("SousCategorie").Where(a => a.SousCategorie.SCAT_CAT_Id == idCategorie).ToList();
            }
            else
            {
                articles = db.Articles.Include("SousCategorie").ToList();
            }
            return articles;
        }

        public static Article Article(int idArticle)
        {
            Article article = db.Articles.Include("SousCategorie").Where(a => a.ART_Id == idArticle).FirstOrDefault();
            return article;
        }

        public static Article DiminuerStockArticle(int idArticle, int quantite)
        {
            Article article = Article(idArticle);
            article.ART_Stock -= quantite;
            db.SaveChanges();
            return article;
        }

        public static Article CreateArticle(Article article)
        {
            Article newArticle = db.Articles.Add(article);
            db.SaveChanges();
            return newArticle;
        }

        public static bool DeleteArticle(int idArticle)
        {
            Article article = db.Articles.Find(idArticle);
            db.Articles.Remove(article);
            db.SaveChanges();
            return true;
        }

        public static Article UpdateArticle(Article article)
        {
            Article articleToUpdate = db.Articles.Find(article.ART_Id);
            if(articleToUpdate != null)
            {
                db.Entry(articleToUpdate).CurrentValues.SetValues(article);
                db.SaveChanges();
            }
           
            return article;
        }



    }
}