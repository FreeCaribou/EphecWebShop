using EphecWebProject.DAL.DataAccess;
using EphecWebProject.Models;
using EphecWebProject.Models.DataModel;
using EphecWebProject.Models.FormModel;
using EphecWebProject.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EphecWebProject.Controllers
{

    public class CommandeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [IsClient]
        public ActionResult MesCommandes()
        {
            Client clientSession = (Client)Session["CLIENT"];
            return View(CommandeAccess.ListeCommandeClient(clientSession.CLI_Id));
        }

        public ActionResult DetailCommande(int idCommande)
        {
            Commande commande = CommandeAccess.DetailCommande(idCommande);
            Client clientSession = (Client)Session["CLIENT"];
            FormModelAdmin connectedAdmin = (FormModelAdmin)Session["ADMIN"];
            if (connectedAdmin != null || commande.COM_CLI_Id == clientSession.CLI_Id)
            {
                return View(commande);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }   
        }

        public ActionResult ListeArticleCommande(int idCommande)
        {
            List<DetailCommande> listeDetailCommande = DetailCommandeAccess.ListeDetailCommandeUneCommande(idCommande);
            return PartialView("_ListeArticleCommande", listeDetailCommande);
        }

        [IsClient]
        public ActionResult CommanderPanier()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [IsClient]
        public ActionResult CommanderPanier(FormModelLivraisonCommande model)
        {
            if (ModelState.IsValid && Session["PANIER"] != null)
            {
                Client clientSession = (Client) Session["CLIENT"];
                Client clientActuel = ClientAccess.Client(clientSession.CLI_Id);
                CommandeAccess.CreateCommande(model, clientActuel);
                Session["PANIER"] = null;
                return RedirectToAction("MesCommandes", "Commande");
            }
            return View();
        }


        public ActionResult DetailLivraisonCommande()
        {
            return PartialView("_DetailLivraisonCommande");
        }

        [IsClient]
        public ActionResult ListePanierCommande()
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

            return PartialView("_ListePanierCommande", panierToReturn);
        }
    }
}