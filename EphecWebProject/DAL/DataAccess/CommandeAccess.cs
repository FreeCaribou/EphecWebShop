using EphecWebProject.Models;
using EphecWebProject.Models.DataModel;
using EphecWebProject.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EphecWebProject.DAL.DataAccess
{
    public static class CommandeAccess
    {

        static WebShopContext db = new WebShopContext();

        public static List<Commande> ListeCommandeClient(int idClient)
        {
            List<Commande> listeCommandesClient = db.Commandes.Where(c => c.COM_CLI_Id == idClient).ToList();
            return listeCommandesClient;
        }

        public static List<Commande> ListeCommande()
        {
            List<Commande> listeCommandes = db.Commandes.ToList();
            return listeCommandes;
        }

        public static Commande DetailCommande(int idCommande)
        {
            Commande commande = db.Commandes.Where(c => c.COM_Id == idCommande).FirstOrDefault();
            return commande;
        }

        public static Commande CreateCommande(FormModelLivraisonCommande model, Client clientActuel)
        {
            Commande commandeActuel = new Commande();
            commandeActuel.COM_CLI_Id = clientActuel.CLI_Id;
            commandeActuel.COM_Adresse = model.Adresse;
            commandeActuel.COM_Civilite = model.Civilite;
            commandeActuel.COM_CodePostal = model.CodePostal;
            commandeActuel.COM_Date = DateTime.Now;
            commandeActuel.COM_DateLivraison = model.DateLivraison;
            commandeActuel.COM_Nom = model.Nom;
            commandeActuel.COM_Prenom = model.Prenom;
            commandeActuel.COM_Ville = model.Ville;
            commandeActuel.COM_Statut = "En attente";
            commandeActuel = db.Commandes.Add(commandeActuel);
            db.SaveChanges();

            Dictionary<int, ArticlePanier> panier = (Dictionary<int, ArticlePanier>) HttpContext.Current.Session["PANIER"];
            foreach (var item in panier)
            {
                Article article = ArticleAccess.Article(item.Value.IdArticle);
                if (article.ART_Stock >= item.Value.QuantiteArticle)
                {
                    DetailCommandeAccess.CreateDetailCommande(
                        commandeActuel.COM_Id, item.Value);
                }
            }
            return commandeActuel;
        }

        public static Commande ChangerStatutCommande(int idCommande, string statutCommande)
        {
            Commande commandeToChange = db.Commandes.Where(c => c.COM_Id == idCommande).FirstOrDefault();
            commandeToChange.COM_Statut = statutCommande;
            db.SaveChanges();
            return commandeToChange;
        }


    }
}