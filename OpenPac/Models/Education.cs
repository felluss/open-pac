using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenPac.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string School { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
        public string Degree { get; set; }

        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}