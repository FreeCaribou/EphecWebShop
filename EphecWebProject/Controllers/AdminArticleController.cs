using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EphecWebProject.Models.DataModel;
using EphecWebProject.Models.Role;
using System.IO;
using System.Diagnostics;
using EphecWebProject.DAL.DataAccess;

namespace EphecWebProject.Controllers
{
    [IsAdmin]
    public class AdminArticleController : Controller
    {

        public ActionResult Index()
        {
            List<Article> listeArticle = ArticleAccess.ListeArticle(0, 0);
            return View(listeArticle);
        }

        public ActionResult Create()
        {
            ViewBag.ART_SCAT_Id = new SelectList(SousCategorieAccess.ListeSousCategorie(0), "SCAT_Id", "SCAT_Libelle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ART_Id,ART_SCAT_Id,ART_Libelle,ART_Description,ART_Prix,ART_Stock")] Article article, HttpPostedFileBase myFile)
        {
            if (ModelState.IsValid)
            {
                if(myFile != null && myFile.ContentLength > 0)
                {
                    string pic = Path.GetFileName(myFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images"), pic);                   
                    article.ART_UrlImage = "/Images/" + pic;
                    myFile.SaveAs(path);
                }
                ArticleAccess.CreateArticle(article);
                return RedirectToAction("Index");
            }

            ViewBag.ART_SCAT_Id = new SelectList(SousCategorieAccess.ListeSousCategorie(0), "SCAT_Id", "SCAT_Libelle", article.ART_SCAT_Id);
            return View(article);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = ArticleAccess.Article((int)id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.ART_SCAT_Id = new SelectList(SousCategorieAccess.ListeSousCategorie(0), "SCAT_Id", "SCAT_Libelle", article.ART_SCAT_Id);
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ART_Id,ART_SCAT_Id,ART_Libelle,ART_Description,ART_Prix,ART_Stock,ART_UrlImage")] Article article, HttpPostedFileBase myFile)
        {
            if (ModelState.IsValid)
            {
                if (myFile != null && myFile.ContentLength > 0)
                {
                    string pic = Path.GetFileName(myFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images"), pic);
                    article.ART_UrlImage = "/Images/" + pic;
                    myFile.SaveAs(path);
                }

                ArticleAccess.UpdateArticle(article);
                return RedirectToAction("Index");
            }
            ViewBag.ART_SCAT_Id = new SelectList(SousCategorieAccess.ListeSousCategorie(0), "SCAT_Id", "SCAT_Libelle", article.ART_SCAT_Id);
            return View(article);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = ArticleAccess.Article((int)id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleAccess.DeleteArticle(id);       
            return RedirectToAction("Index");
        }

    }
}
