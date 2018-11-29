using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminSite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(AdminSite.Models.Account user)
        {
            using (AdminSite.Models.AdminPortalData db = new AdminSite.Models.AdminPortalData())
            {
                var userDetails = db.Accounts.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //Assign Session Variables and Check if the Admin is an Assigner
                    Session["UserID"] = userDetails.AccountID;
                    bool canAssign = false;
                    foreach (var role in userDetails.AssociateRoles)
                    {
                        if (role.RoleID == 2 && role.AccountID == userDetails.AccountID)
                        {
                            canAssign = true;
                        }
                    }
                    if (canAssign)
                    {
                        Session["CanAssign"] = true;
                    }
                    return RedirectToAction("Index", "Home", new { AccountID = userDetails.AccountID });
                }
            }
        }
    }
}