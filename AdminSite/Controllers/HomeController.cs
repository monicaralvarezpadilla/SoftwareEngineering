using AdminSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdminSite.Controllers
{
    public class HomeController : Controller
    {
        private AdminPortalDataEntities2 db = new AdminPortalDataEntities2();
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return View();
            }

            int id = Convert.ToInt32(Session["UserID"]);
            Account account = db.Accounts.Find(id);
            if (account != null)
            {
                return View(account);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult ClearSession()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}