using EphecWebProject.Models.DataModel;
using EphecWebProject.Models.FormModel;
using EphecWebProject.AesCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EphecWebProject.Models.Role;
using EphecWebProject.DAL.DataAccess;

namespace EphecWebProject.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAccount(FormModelCreateAccount model)
        {
            if (ModelState.IsValid)
            {
                Client newClient = ClientAccess.CreateClient(model);
                FormsAuthentication.SetAuthCookie(newClient.CLI_Email, true);
                Session.Add("CLIENT", newClient);
                return RedirectToAction("Index", "Home");
            }
            Session["MESSAGE"] = "Formulaire mal rempli";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormModelLogin model)
        {
            if (!ModelState.IsValid)
            {
                Session["MESSAGE"] = "Mot de passe ou nom d'utilisateur manquant";
                return Redirect("/Account/Login");
            }
            Client client = ClientAccess.ClientConnection(model);
            if (client != null)
            {
                Session.Add("CLIENT", client);
                FormsAuthentication.SetAuthCookie(client.CLI_Email, true);
                return RedirectToAction("Index", "Home");
            }
            Session["MESSAGE"] = "Utilisateur inexistant ou mauvais mot de passe";
            return View();
        }

       
        [IsClient]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("CLIENT");
            return RedirectToAction("Index", "Home");
        }

    }
}