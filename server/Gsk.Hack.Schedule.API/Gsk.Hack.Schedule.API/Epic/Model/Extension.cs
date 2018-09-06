using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Epic.Model
{
    public class Extension
    {
        public string url { get; set; }
        public List<Extension> extension { get; set; }
    }
}