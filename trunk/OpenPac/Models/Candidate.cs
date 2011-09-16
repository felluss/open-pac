using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OpenPac.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Seat { get; set; }

        [MaxLength(255)]
        public string WebSiteUrl { get; set; }

        [MaxLength(50)]
        public string Party { get; set; }

        public bool IsIncumbent { get; set; }

        public string SelfDescription { get; set; }

        public DateTime Birthday { get; set; }

        [MaxLength(100)]
        public string TwitterId { get; set; }

        [MaxLength(100)]
        public string YouTubeId { get; set; }

        [MaxLength(100)]
        public string FacebookId { get; set; }

        [MaxLength(100)]
        public string LinkedInId { get; set; }

        public int DistrictId { get; set; }
        public virtual District District { get; set; }

        public virtual ICollection<Education> Education { get; set; }
        public virtual ICollection<WorkExperience> WorkExperience { get; set; }

        public virtual ICollection<CandidateIssue> ImportantIssues { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", LastName, FirstName);
        }
    }
}