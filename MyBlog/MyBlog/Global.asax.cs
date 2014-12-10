using Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace MyBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception ex = Server.GetLastError();

            Response.Redirect("/Errors/HttpError");
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id =
                            (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;

                        var dao = new UserAccountDao();
                        var user = dao.GetUserAccount(id.Name);
                        if (user == null)
                        {
                            HttpContext.Current.User = null;
                        }
                        else
                        {
                            HttpContext.Current.Items[CurrentUserService.CurrentUserKey] = user;
                            string[] role = user.UserRole.Split(',');
                            HttpContext.Current.User = new GenericPrincipal(id, role);
                        }
                    }
                }
            }
        }
    }
}
