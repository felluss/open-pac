using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenPac.Models
{
    public class MediaOutlet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Abbreviation { get; set; }

        public string PerceivedBias { get; set; }

        public string PrimaryContact { get; set; }
        public string PrimaryContactType { get; set; }
        public string PrimaryContactValue { get; set; }

        public string SecondaryContact { get; set; }
        public string SecondaryContactType { get; set; }
        public string SecondaryContactValue { get; set; }

        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<MediaOutletIssue> ImportantIssues { get; set; }
    }
}