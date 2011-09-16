using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenPac.Models;

using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;
using OpenPac.ViewModels;

namespace OpenPac.Controllers
{   
    public class CandidatesController : Controller
    {
        private OpenPacContext context = new OpenPacContext();

        //
        // GET: /Candidates/

        public ViewResult Index()
        {
            return View(context.Candidates.Include(candidate => candidate.District).Include(candidate => candidate.Education).Include(candidate => candidate.WorkExperience).Include(candidate => candidate.ImportantIssues).ToList());
        }

        //
        // GET: /Candidates/Details/5

        public ViewResult Details(int id)
        {
            Candidate candidate = context.Candidates.Single(x => x.Id == id);

            YouTubeRequest req = new YouTubeRequest(new YouTubeRequestSettings("OpenPac", "AI39si5R4licFRGAWgvNI5G6ANPqGfcuyuTWW55nb7rE49bv5kIyMm7YbGpfvUpCX_5nNBJYXztGiUvhULoBQOoEUVQD8xI-Nw"));

            Uri u = new Uri(string.Format("https://gdata.youtube.com/feeds/api/users/{0}/uploads", candidate.YouTubeId));

            Feed<Video> videos = req.Get<Video>(u);

            List<YouTubeVideo> videoUrls = new List<YouTubeVideo>();

            foreach (Video v in videos.Entries)
            {
                videoUrls.Add(new YouTubeVideo
                {
                    VideoId = v.YouTubeEntry.VideoId,
                    Description = v.Description,
                    Title = v.Title,
                    Rating = v.YouTubeEntry.Rating == null ? 0.0 : v.YouTubeEntry.Rating.Average,
                    Updated = v.YouTubeEntry.Updated,
                    Duration = v.YouTubeEntry.Duration.IntegerValue,
                    YouTubeUrl = v.WatchPage.ToString()
                });
            }

            ViewBag.YouTubeVideos = videoUrls;

            return View(candidate);
        }

        //
        // GET: /Candidates/Create

        public ActionResult Create()
        {
            ViewBag.PossibleDistricts = context.Districts;
            return View();
        } 

        //
        // POST: /Candidates/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                context.Candidates.Add(candidate);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleDistricts = context.Districts;
            return View(candidate);
        }
        
        //
        // GET: /Candidates/Edit/5
 
        public ActionResult Edit(int id)
        {
            Candidate candidate = context.Candidates.Single(x => x.Id == id);
            ViewBag.PossibleDistricts = context.Districts;
            return View(candidate);
        }

        //
        // POST: /Candidates/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                context.Entry(candidate).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleDistricts = context.Districts;
            return View(candidate);
        }

        //
        // GET: /Candidates/Delete/5
 
        public ActionResult Delete(int id)
        {
            Candidate candidate = context.Candidates.Single(x => x.Id == id);
            return View(candidate);
        }

        //
        // POST: /Candidates/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidate candidate = context.Candidates.Single(x => x.Id == id);
            context.Candidates.Remove(candidate);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Pirates()
        {
            List<Candidate> pirates = context.Candidates.Where(c => c.Party == "Pirate").ToList();

            return View(pirates);
        }
    }
}