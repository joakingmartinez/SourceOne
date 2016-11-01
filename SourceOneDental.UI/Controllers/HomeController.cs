using SourceOneDental.BO;
using SourceOneDental.BO.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceOneDental.UI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Menu()
        {
            ViewBag.UserRolId = 0;

            if(LoggedUser != null)
            {
                ViewBag.UserRolId = LoggedUser.UserRolId;
            }

            return PartialView();
        }

        public JsonResult Comp_Lookup()
        {
            var rep = new BaseRepository<Comp_Lookup>();

            var products = rep.GetAll().OrderBy(i=> i.OriginalSort);

            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}