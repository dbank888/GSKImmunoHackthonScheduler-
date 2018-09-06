using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Epic.Model
{
    public class Rest
    {
        public string mode { get; set; }
        public Security security { get; set; }
        public List<Resource> resource { get; set; }
    }
}