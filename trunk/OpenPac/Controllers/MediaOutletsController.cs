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
    public class MediaOutletsController : Controller
    {
        private OpenPacContext context = new OpenPacContext();

        //
        // GET: /MediaOutlets/

        public ViewResult Index()
        {
            return View(context.MediaOutlets.Include(mediaoutlet => mediaoutlet.Districts).Include(mediaoutlet => mediaoutlet.ImportantIssues).ToList());
        }

        //
        // GET: /MediaOutlets/Details/5

        public ViewResult Details(int id)
        {
            MediaOutlet mediaoutlet = context.MediaOutlets.Single(x => x.Id == id);
            return View(mediaoutlet);
        }

        //
        // GET: /MediaOutlets/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /MediaOutlets/Create

        [HttpPost]
        public ActionResult Create(MediaOutlet mediaoutlet)
        {
            if (ModelState.IsValid)
            {
                context.MediaOutlets.Add(mediaoutlet);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(mediaoutlet);
        }
        
        //
        // GET: /MediaOutlets/Edit/5
 
        public ActionResult Edit(int id)
        {
            MediaOutlet mediaoutlet = context.MediaOutlets.Single(x => x.Id == id);
            return View(mediaoutlet);
        }

        //
        // POST: /MediaOutlets/Edit/5

        [HttpPost]
        public ActionResult Edit(MediaOutlet mediaoutlet)
        {
            if (ModelState.IsValid)
            {
                context.Entry(mediaoutlet).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mediaoutlet);
        }

        //
        // GET: /MediaOutlets/Delete/5
 
        public ActionResult Delete(int id)
        {
            MediaOutlet mediaoutlet = context.MediaOutlets.Single(x => x.Id == id);
            return View(mediaoutlet);
        }

        //
        // POST: /MediaOutlets/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MediaOutlet mediaoutlet = context.MediaOutlets.Single(x => x.Id == id);
            context.MediaOutlets.Remove(mediaoutlet);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}