using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenPac.Models
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Position { get; set; }
        public string Responsibilities { get; set; }

        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}