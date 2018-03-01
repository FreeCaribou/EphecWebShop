using EphecWebProject.DAL.DataAccess;
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
    [IsAdmin]
    public class AdminController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataTableClient()
        {
            return View(ClientAccess.ListeClient());
        }

        [AllowAnonymous]
        public ActionResult Connect()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Connect(FormModelAdmin model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name.Equals("Admin") && model.Password.Equals("azerty"))
                {
                    Session.Add("ADMIN", model);
                    return RedirectToAction("Index", "Admin");
                }
                return View();
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("ADMIN");
            return RedirectToAction("Index", "Home");
        }

    }
}