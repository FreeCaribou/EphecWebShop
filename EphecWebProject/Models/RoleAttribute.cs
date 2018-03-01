using EphecWebProject.Models.DataModel;
using EphecWebProject.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EphecWebProject.Models.Role
{
    public class IsClientAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Client connectedClient = (Client)HttpContext.Current.Session["CLIENT"];
            if (connectedClient == null)
            {
                return false;
            }
            // pour éviter de perdre trop rapidement la session
            HttpContext.Current.Session["CLIENT"] = connectedClient;
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
    
    public class IsAdminAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            FormModelAdmin connectedAdmin = (FormModelAdmin)HttpContext.Current.Session["ADMIN"];
            if (connectedAdmin == null)
            {
                return false;
            }
            // pour éviter de perdre trop rapidement la session
            HttpContext.Current.Session["ADMIN"] = connectedAdmin;
            return true;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
    
    }
    

}