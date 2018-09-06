using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Epic.Model
{
    public class Language
    {
        public string text { get; set; }
        public List<Coding> coding { get; set; }
    }
}