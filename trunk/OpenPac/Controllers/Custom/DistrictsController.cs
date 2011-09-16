using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using OpenPac.Models;

namespace OpenPac.Controllers
{
    public partial class DistrictsController
    {
        [HttpPost]
        public ActionResult AddFromAddress(string street, string city, string state, string zip)
        {
            string url = string.Format("http://www.govtrack.us/perl/district-lookup.cgi?address={0},{1}%20{2}%20{3}",
                street, city, state, zip);

            XDocument results = XDocument.Load(url);

            District d = (from x in results.Elements("congressional-district")
                          select
                              new District
                              {
                                  DistrictNumber = Convert.ToInt32(x.Element("district").Value),
                                  Latitude = Convert.ToDecimal(x.Element("latitude").Value),
                                  Longitude = Convert.ToDecimal(x.Element("longitude").Value),
                                  State = x.Element("state").Value
                              }).FirstOrDefault();

            var exists = (from district in context.Districts
                          where district.State == d.State && district.DistrictNumber == d.DistrictNumber
                          select district).FirstOrDefault() != null;

            if (!exists)
            {
                context.Districts.Add(d);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
