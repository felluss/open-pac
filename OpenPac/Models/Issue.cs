using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OpenPac.Models
{
    public class Issue
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        public virtual ICollection<MediaOutletIssue> MediaOutletIssues { get; set; }
        public virtual ICollection<CandidateIssue> CandidateIssues { get; set; }
        public virtual ICollection<DistrictIssue> DistrictIssues { get; set; }
    }
}