using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Epic.Model
{
    public class Name
    {
        public string use { get; set; }
        public string text { get; set; }
        public List<string> family { get; set; }
        public List<string> given { get; set; }
    }
}