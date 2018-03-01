using EphecWebProject.AesCrypto;
using EphecWebProject.Models.DataModel;
using EphecWebProject.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EphecWebProject.DAL.DataAccess
{
    public static class ClientAccess
    {

        static WebShopContext db = new WebShopContext();
        static AesFunction crypto = new AesFunction();

        public static Client Client(int idClient)
        {
            return db.Clients.Where(c => c.CLI_Id == idClient).FirstOrDefault();
        }

        public static List<Client> ListeClient()
        {
            List<Client> listeClient = db.Clients.ToList();
            return listeClient;
        }

        public static Client CreateClient(FormModelCreateAccount model)
        {
            Client newClient = db.Clients.Add(new Client
            {
                CLI_Nom = model.Nom,
                CLI_Prenom = model.Prenom,
                CLI_Password = crypto.EncryptPassword(model.Password),
                CLI_Adresse = model.Adresse,
                CLI_Telephone = model.Telephone,
                CLI_Civilite = model.Civilite,
                CLI_CodePostal = model.CodePostal,
                CLI_Email = model.Email,
                CLI_Ville = model.Ville
            });
            db.SaveChanges();
            return newClient;
        }

        public static Client ClientConnection(FormModelLogin model)
        {
            string matchPassword = crypto.EncryptPassword(model.Password);
            Client client = db.Clients.Where(c => c.CLI_Email.Equals(model.Email)
                && c.CLI_Password.Equals(matchPassword)).FirstOrDefault();
            return client;
        }


    }
}