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
using EphecWebProject.DAL.DataAccess;

namespace EphecWebProject.Controllers
{
    [IsAdmin]
    public class AdminCommandeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListeCommande()
        {
            List<Commande> listeCommandes = CommandeAccess.ListeCommande();
            return PartialView("_ListeCommande", listeCommandes);
        }

        public ActionResult EditStatut(int idCommande, string statutCommande)
        {
            CommandeAccess.ChangerStatutCommande(idCommande, statutCommande);
            List<Commande> listeCommandes = CommandeAccess.ListeCommande();
            return PartialView("_ListeCommande", listeCommandes);
        }

    }
}
