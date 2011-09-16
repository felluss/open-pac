using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OpenPac.Models
{
    public class CandidateIssue
    {
        public int Id { get; set; }

        [Range(0, 10)]
        public int Importance { get; set; }

        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

        public int IssueId { get; set; }
        public virtual Issue Issue { get; set; }
    }
}