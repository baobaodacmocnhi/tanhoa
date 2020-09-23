using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DangBoWeb.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DangNhapModel usersession = CUserSession.getUserSession();
            //check login
            if (usersession == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "User", action = "DangNhap" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}