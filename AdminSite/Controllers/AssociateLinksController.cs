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
    public class AssociateLinksController : Controller
    {
        private AdminPortalDataEntities2 db = new AdminPortalDataEntities2();

        // GET: AssociateLinks
        public ActionResult Index()
        {
            var associateLinks = db.AssociateLinks.Include(a => a.Link).Include(a => a.UserRole);
            return View(associateLinks.ToList());
        }

        // GET: AssociateLinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociateLink associateLink = db.AssociateLinks.Find(id);
            if (associateLink == null)
            {
                return HttpNotFound();
            }
            return View(associateLink);
        }

        // GET: AssociateLinks/Create
        public ActionResult Create()
        {
            ViewBag.LinkID = new SelectList(db.Links, "LinkID", "URL");
            ViewBag.RoleID = new SelectList(db.UserRoles, "RoleID", "RoleName");
            return View();
        }

        // POST: AssociateLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssociateLinkID,RoleID,LinkID")] AssociateLink associateLink)
        {
            if (ModelState.IsValid)
            {
                db.AssociateLinks.Add(associateLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LinkID = new SelectList(db.Links, "LinkID", "URL", associateLink.LinkID);
            ViewBag.RoleID = new SelectList(db.UserRoles, "RoleID", "RoleName", associateLink.RoleID);
            return View(associateLink);
        }

        // GET: AssociateLinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociateLink associateLink = db.AssociateLinks.Find(id);
            if (associateLink == null)
            {
                return HttpNotFound();
            }
            ViewBag.LinkID = new SelectList(db.Links, "LinkID", "URL", associateLink.LinkID);
            ViewBag.RoleID = new SelectList(db.UserRoles, "RoleID", "RoleName", associateLink.RoleID);
            return View(associateLink);
        }

        // POST: AssociateLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssociateLinkID,RoleID,LinkID")] AssociateLink associateLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associateLink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LinkID = new SelectList(db.Links, "LinkID", "URL", associateLink.LinkID);
            ViewBag.RoleID = new SelectList(db.UserRoles, "RoleID", "RoleName", associateLink.RoleID);
            return View(associateLink);
        }

        // GET: AssociateLinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociateLink associateLink = db.AssociateLinks.Find(id);
            if (associateLink == null)
            {
                return HttpNotFound();
            }
            return View(associateLink);
        }

        // POST: AssociateLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssociateLink associateLink = db.AssociateLinks.Find(id);
            db.AssociateLinks.Remove(associateLink);
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
