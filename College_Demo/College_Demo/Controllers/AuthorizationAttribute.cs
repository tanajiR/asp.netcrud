using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College_Demo.Controllers
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //return httpContext.Session["loginUser"] != null;

            if (httpContext.Session["loginUser"] != null)
                return true;
            else
                return false;
        }
    }
}