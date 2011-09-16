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
    public class DistrictIssuesController : Controller
    {
        private OpenPacContext context = new OpenPacContext();

        //
        // GET: /DistrictIssues/

        public ViewResult Index()
        {
            return View(context.DistrictIssues.Include(districtissue => districtissue.District).Include(districtissue => districtissue.Issue).ToList());
        }

        //
        // GET: /DistrictIssues/Details/5

        public ViewResult Details(int id)
        {
            DistrictIssue districtissue = context.DistrictIssues.Single(x => x.Id == id);
            return View(districtissue);
        }

        //
        // GET: /DistrictIssues/Create

        public ActionResult Create()
        {
            ViewBag.PossibleDistricts = context.Districts;
            ViewBag.PossibleIssues = context.Issues;
            return View();
        } 

        //
        // POST: /DistrictIssues/Create

        [HttpPost]
        public ActionResult Create(DistrictIssue districtissue)
        {
            if (ModelState.IsValid)
            {
                context.DistrictIssues.Add(districtissue);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleDistricts = context.Districts;
            ViewBag.PossibleIssues = context.Issues;
            return View(districtissue);
        }
        
        //
        // GET: /DistrictIssues/Edit/5
 
        public ActionResult Edit(int id)
        {
            DistrictIssue districtissue = context.DistrictIssues.Single(x => x.Id == id);
            ViewBag.PossibleDistricts = context.Districts;
            ViewBag.PossibleIssues = context.Issues;
            return View(districtissue);
        }

        //
        // POST: /DistrictIssues/Edit/5

        [HttpPost]
        public ActionResult Edit(DistrictIssue districtissue)
        {
            if (ModelState.IsValid)
            {
                context.Entry(districtissue).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleDistricts = context.Districts;
            ViewBag.PossibleIssues = context.Issues;
            return View(districtissue);
        }

        //
        // GET: /DistrictIssues/Delete/5
 
        public ActionResult Delete(int id)
        {
            DistrictIssue districtissue = context.DistrictIssues.Single(x => x.Id == id);
            return View(districtissue);
        }

        //
        // POST: /DistrictIssues/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DistrictIssue districtissue = context.DistrictIssues.Single(x => x.Id == id);
            context.DistrictIssues.Remove(districtissue);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}