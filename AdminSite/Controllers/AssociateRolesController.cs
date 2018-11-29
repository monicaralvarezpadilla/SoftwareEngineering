using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminSite.Models;

namespace AdminSite.Controllers
{
    public class AssociateRolesController : Controller
    {
        private AdminPortalData db = new AdminPortalData();

        // GET: AssociateRoles
        public ActionResult Index()
        {
            var associateRoles = db.AssociateRoles.Include(a => a.Account).Include(a => a.UserRole);
            return View(associateRoles.ToList());
        }

        // GET: AssociateRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociateRole associateRole = db.AssociateRoles.Find(id);
            if (associateRole == null)
            {
                return HttpNotFound();
            }
            return View(associateRole);
        }

        // GET: AssociateRoles/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username");
            ViewBag.RoleID = new SelectList(db.UserRoles, "RoleID", "RoleName");
            return View();
        }

        // POST: AssociateRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssociateRoleID,AccountID,RoleID")] AssociateRole associateRole)
        {
            if (ModelState.IsValid)
            {
                db.AssociateRoles.Add(associateRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", associateRole.AccountID);
            ViewBag.RoleID = new SelectList(db.UserRoles, "RoleID", "RoleName", associateRole.RoleID);
            return View(associateRole);
        }

        // GET: AssociateRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociateRole associateRole = db.AssociateRoles.Find(id);
            if (associateRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", associateRole.AccountID);
            ViewBag.RoleID = new SelectList(db.UserRoles, "RoleID", "RoleName", associateRole.RoleID);
            return View(associateRole);
        }

        // POST: AssociateRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssociateRoleID,AccountID,RoleID")] AssociateRole associateRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associateRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Username", associateRole.AccountID);
            ViewBag.RoleID = new SelectList(db.UserRoles, "RoleID", "RoleName", associateRole.RoleID);
            return View(associateRole);
        }

        // GET: AssociateRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociateRole associateRole = db.AssociateRoles.Find(id);
            if (associateRole == null)
            {
                return HttpNotFound();
            }
            return View(associateRole);
        }

        // POST: AssociateRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssociateRole associateRole = db.AssociateRoles.Find(id);
            db.AssociateRoles.Remove(associateRole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
