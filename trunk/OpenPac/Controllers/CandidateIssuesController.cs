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
    public class CandidateIssuesController : Controller
    {
        private OpenPacContext context = new OpenPacContext();

        //
        // GET: /CandidateIssues/

        public ViewResult Index()
        {
            return View(context.CandidateIssues.Include(candidateissue => candidateissue.Candidate).Include(candidateissue => candidateissue.Issue).ToList());
        }

        //
        // GET: /CandidateIssues/Details/5

        public ViewResult Details(int id)
        {
            CandidateIssue candidateissue = context.CandidateIssues.Single(x => x.Id == id);
            return View(candidateissue);
        }

        //
        // GET: /CandidateIssues/Create

        public ActionResult Create()
        {
            ViewBag.PossibleCandidates = context.Candidates;
            ViewBag.PossibleIssues = context.Issues;
            return View();
        } 

        //
        // POST: /CandidateIssues/Create

        [HttpPost]
        public ActionResult Create(CandidateIssue candidateissue)
        {
            if (ModelState.IsValid)
            {
                context.CandidateIssues.Add(candidateissue);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleCandidates = context.Candidates;
            ViewBag.PossibleIssues = context.Issues;
            return View(candidateissue);
        }
        
        //
        // GET: /CandidateIssues/Edit/5
 
        public ActionResult Edit(int id)
        {
            CandidateIssue candidateissue = context.CandidateIssues.Single(x => x.Id == id);
            ViewBag.PossibleCandidates = context.Candidates;
            ViewBag.PossibleIssues = context.Issues;
            return View(candidateissue);
        }

        //
        // POST: /CandidateIssues/Edit/5

        [HttpPost]
        public ActionResult Edit(CandidateIssue candidateissue)
        {
            if (ModelState.IsValid)
            {
                context.Entry(candidateissue).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleCandidates = context.Candidates;
            ViewBag.PossibleIssues = context.Issues;
            return View(candidateissue);
        }

        //
        // GET: /CandidateIssues/Delete/5
 
        public ActionResult Delete(int id)
        {
            CandidateIssue candidateissue = context.CandidateIssues.Single(x => x.Id == id);
            return View(candidateissue);
        }

        //
        // POST: /CandidateIssues/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CandidateIssue candidateissue = context.CandidateIssues.Single(x => x.Id == id);
            context.CandidateIssues.Remove(candidateissue);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}