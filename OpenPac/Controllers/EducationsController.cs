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
    public class EducationsController : Controller
    {
        private OpenPacContext context = new OpenPacContext();

        //
        // GET: /Educations/

        public ViewResult Index()
        {
            return View(context.Educations.ToList());
        }

        //
        // GET: /Educations/Details/5

        public ViewResult Details(int id)
        {
            Education education = context.Educations.Single(x => x.Id == id);
            return View(education);
        }

        //
        // GET: /Educations/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Educations/Create

        [HttpPost]
        public ActionResult Create(Education education)
        {
            if (ModelState.IsValid)
            {
                context.Educations.Add(education);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(education);
        }
        
        //
        // GET: /Educations/Edit/5
 
        public ActionResult Edit(int id)
        {
            Education education = context.Educations.Single(x => x.Id == id);
            return View(education);
        }

        //
        // POST: /Educations/Edit/5

        [HttpPost]
        public ActionResult Edit(Education education)
        {
            if (ModelState.IsValid)
            {
                context.Entry(education).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(education);
        }

        //
        // GET: /Educations/Delete/5
 
        public ActionResult Delete(int id)
        {
            Education education = context.Educations.Single(x => x.Id == id);
            return View(education);
        }

        //
        // POST: /Educations/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Education education = context.Educations.Single(x => x.Id == id);
            context.Educations.Remove(education);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddInline(Education education)
        {
            if (ModelState.IsValid)
            {
                context.Educations.Add(education);
                context.SaveChanges();
            }

            List<Education> edus = (from e in context.Educations
                                    where e.CandidateId == education.CandidateId
                                    select e).ToList();

            return PartialView("ListInline", edus);
        }
    }
}