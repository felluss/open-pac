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
    public partial class DistrictsController : Controller
    {
        private OpenPacContext context = new OpenPacContext();

        //
        // GET: /Districts/

        public ViewResult Index()
        {
            return View(context.Districts.Include(district => district.Candidates).Include(district => district.MediaOutlets).Include(district => district.ImportantIssues).ToList());
        }

        //
        // GET: /Districts/Details/5

        public ViewResult Details(int id)
        {
            District district = context.Districts.Single(x => x.Id == id);
            return View(district);
        }

        //
        // GET: /Districts/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Districts/Create

        [HttpPost]
        public ActionResult Create(District district)
        {
            if (ModelState.IsValid)
            {
                context.Districts.Add(district);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(district);
        }
        
        //
        // GET: /Districts/Edit/5
 
        public ActionResult Edit(int id)
        {
            District district = context.Districts.Single(x => x.Id == id);
            return View(district);
        }

        //
        // POST: /Districts/Edit/5

        [HttpPost]
        public ActionResult Edit(District district)
        {
            if (ModelState.IsValid)
            {
                context.Entry(district).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(district);
        }

        //
        // GET: /Districts/Delete/5
 
        public ActionResult Delete(int id)
        {
            District district = context.Districts.Single(x => x.Id == id);
            return View(district);
        }

        //
        // POST: /Districts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            District district = context.Districts.Single(x => x.Id == id);
            context.Districts.Remove(district);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}