using SourceOneDental.BO;
using SourceOneDental.BO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceOneDental.UI.Controllers
{
    public class BaseController : Controller
    {
        public User LoggedUser
        {
            get
            {
                if (Session["User"] != null)
                {

                    return (User)Session["User"];
                }

                if (User.Identity.IsAuthenticated)
                {
                    var RepUser = new UserRepository();

                    Session["User"] = RepUser.ValidateUser(User.Identity.Name);

                    return (User)Session["User"];
                }

                RedirectToAction("Login", "Account");
                return null;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.DisplayName = "";

            if (LoggedUser != null)
            {
                ViewBag.DisplayName = LoggedUser.DisplayName;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}