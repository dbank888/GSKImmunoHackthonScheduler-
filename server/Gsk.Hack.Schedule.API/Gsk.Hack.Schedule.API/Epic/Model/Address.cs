using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Epic.Model
{
    public class Address
    {
        public string use { get; set; }
        public List<string> line { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public Period period { get; set; }
    }
}