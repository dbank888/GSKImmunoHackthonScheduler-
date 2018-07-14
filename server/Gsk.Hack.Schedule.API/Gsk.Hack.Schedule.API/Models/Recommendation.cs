using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Models
{
    public class Recommendation
    {
        public string FullName { get; set; }
        public string VacineName { get; set; }
        public string RecommendationText { get; set; }
    }
}