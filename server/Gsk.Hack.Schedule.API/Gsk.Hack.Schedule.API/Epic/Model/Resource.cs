using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Epic.Model
{
    public class Resource
    {
        public string type { get; set; }
        public bool readHistory { get; set; }
        public bool updateCreate { get; set; }
        public bool conditionalCreate { get; set; }
        public bool conditionalUpdate { get; set; }
        public string conditionalDelete { get; set; }
        public List<Interaction> interaction { get; set; }
        public List<SearchParam> searchParam { get; set; }
    }
}