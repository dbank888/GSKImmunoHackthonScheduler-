using Gsk.Hack.Schedule.API.Epic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Epic.Responses
{
    public class AuthMetaDataResponse
    {
        public string resourceType { get; set; }
        public string url { get; set; }
        public string version { get; set; }
        public string copyright { get; set; }
        public string status { get; set; }
        public bool experimental { get; set; }
        public string date { get; set; }
        public string fhirVersion { get; set; }
        public string acceptUnknown { get; set; }
        public List<string> format { get; set; }
        public string id { get; set; }
        public string kind { get; set; }
        public Software software { get; set; }
        public List<Rest> rest { get; set; }
    }
}