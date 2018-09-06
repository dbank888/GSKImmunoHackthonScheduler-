using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Epic.Model
{
    public class Telecom
    {
        public string system { get; set; }
        public string value { get; set; }
        public string use { get; set; }
        public Period period { get; set; }
    }
}