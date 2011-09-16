using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenPac.ViewModels
{
    public class YouTubeVideo
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public DateTime Updated { get; set; }
        public int Duration { get; set; }
        public string YouTubeUrl { get; set; }
    }
}