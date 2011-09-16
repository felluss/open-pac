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
    public class WorkExperiencesController : Controller
    {
        private OpenPacContext context = new OpenPacContext();

        //
        // GET: /WorkExperiences/

        public ViewResult Index()
        {
            return View(context.WorkExperiences.ToList());
        }

        //
        // GET: /WorkExperiences/Details/5

        public ViewResult Details(int id)
        {
            WorkExperience workexperience = context.WorkExperiences.Single(x => x.Id == id);
            return View(workexperience);
        }

        //
        // GET: /WorkExperiences/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /WorkExperiences/Create

        [HttpPost]
        public ActionResult Create(WorkExperience workexperience)
        {
            if (ModelState.IsValid)
            {
                context.WorkExperiences.Add(workexperience);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(workexperience);
        }
        
        //
        // GET: /WorkExperiences/Edit/5
 
        public ActionResult Edit(int id)
        {
            WorkExperience workexperience = context.WorkExperiences.Single(x => x.Id == id);
            return View(workexperience);
        }

        //
        // POST: /WorkExperiences/Edit/5

        [HttpPost]
        public ActionResult Edit(WorkExperience workexperience)
        {
            if (ModelState.IsValid)
            {
                context.Entry(workexperience).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workexperience);
        }

        //
        // GET: /WorkExperiences/Delete/5
 
        public ActionResult Delete(int id)
        {
            WorkExperience workexperience = context.WorkExperiences.Single(x => x.Id == id);
            return View(workexperience);
        }

        //
        // POST: /WorkExperiences/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkExperience workexperience = context.WorkExperiences.Single(x => x.Id == id);
            context.WorkExperiences.Remove(workexperience);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddInline(WorkExperience workexperience)
        {
            if (ModelState.IsValid)
            {
                context.WorkExperiences.Add(workexperience);
                context.SaveChanges();
            }

            List<WorkExperience> results = (from e in context.WorkExperiences
                                    where e.CandidateId == workexperience.CandidateId
                                    select e).ToList();

            return PartialView("ListInline", results);
        }
    }
}