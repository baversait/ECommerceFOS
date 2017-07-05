using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.AuthorizationFilters
{
    public class AdminAuthorization : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["userRole"] != null && ((string)HttpContext.Current.Session["userRole"]).Equals("admin"))
            {
            }
            else
            {
                filterContext.Result = new RedirectResult("/Login");
            }
        }
    }
}