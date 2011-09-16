using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenPac.Models
{
    public class District
    {
        public int Id { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string State { get; set; }
        public int DistrictNumber { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<MediaOutlet> MediaOutlets { get; set; }
        public virtual ICollection<DistrictIssue> ImportantIssues { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", State, DistrictNumber);
        }
    }
}