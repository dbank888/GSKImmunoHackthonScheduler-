using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Epic.Model
{
    public class Security
    {
        public bool cors { get; set; }
        public List<Service> service { get; set; }
        public List<Extension> extension { get; set; }
    }
}