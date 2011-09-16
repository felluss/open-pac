using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenPac.Models;

namespace OpenPac.Controllers
{   
    public class MediaOutletIssuesController : Controller
    {
        private OpenPacContext context = new OpenPacContext();

        //
        // GET: /MediaOutletIssues/

        public ViewResult Index()
        {
            return View(context.MediaOutletIssues.Include(mediaoutletissue => mediaoutletissue.MediaOutlet).Include(mediaoutletissue => mediaoutletissue.Issue).ToList());
        }

        //
        // GET: /MediaOutletIssues/Details/5

        public ViewResult Details(int id)
        {
            MediaOutletIssue mediaoutletissue = context.MediaOutletIssues.Single(x => x.Id == id);
            return View(mediaoutletissue);
        }

        //
        // GET: /MediaOutletIssues/Create

        public ActionResult Create()
        {
            ViewBag.PossibleMediaOutlets = context.MediaOutlets;
            ViewBag.PossibleIssues = context.Issues;
            return View();
        } 

        //
        // POST: /MediaOutletIssues/Create

        [HttpPost]
        public ActionResult Create(MediaOutletIssue mediaoutletissue)
        {
            if (ModelState.IsValid)
            {
                context.MediaOutletIssues.Add(mediaoutletissue);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleMediaOutlets = context.MediaOutlets;
            ViewBag.PossibleIssues = context.Issues;
            return View(mediaoutletissue);
        }
        
        //
        // GET: /MediaOutletIssues/Edit/5
 
        public ActionResult Edit(int id)
        {
            MediaOutletIssue mediaoutletissue = context.MediaOutletIssues.Single(x => x.Id == id);
            ViewBag.PossibleMediaOutlets = context.MediaOutlets;
            ViewBag.PossibleIssues = context.Issues;
            return View(mediaoutletissue);
        }

        //
        // POST: /MediaOutletIssues/Edit/5

        [HttpPost]
        public ActionResult Edit(MediaOutletIssue mediaoutletissue)
        {
            if (ModelState.IsValid)
            {
                context.Entry(mediaoutletissue).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleMediaOutlets = context.MediaOutlets;
            ViewBag.PossibleIssues = context.Issues;
            return View(mediaoutletissue);
        }

        //
        // GET: /MediaOutletIssues/Delete/5
 
        public ActionResult Delete(int id)
        {
            MediaOutletIssue mediaoutletissue = context.MediaOutletIssues.Single(x => x.Id == id);
            return View(mediaoutletissue);
        }

        //
        // POST: /MediaOutletIssues/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MediaOutletIssue mediaoutletissue = context.MediaOutletIssues.Single(x => x.Id == id);
            context.MediaOutletIssues.Remove(mediaoutletissue);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}