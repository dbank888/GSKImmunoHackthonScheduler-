using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Models
{
    public class EpicVacinationsResponse
    {
        public string resourceType { get; set; }
        public string type { get; set; }
        public int total { get; set; }
        public List<Link> link { get; set; }
        public List<Entry> entry { get; set; }
    }

    public class Link
    {
        public string relation { get; set; }
        public string url { get; set; }
    }

    public class Link2
    {
        public string relation { get; set; }
        public string url { get; set; }
    }

    public class Search
    {
        public string mode { get; set; }
    }

  

    public class VaccineCode
    {
        public string text { get; set; }
        public List<Coding> coding { get; set; }
    }

    public class Patient
    {
        public string display { get; set; }
        public string reference { get; set; }
    }

    public class Site
    {
        public string text { get; set; }
        public List<Coding> coding { get; set; }
    }

    public class Route
    {
        public string text { get; set; }
        public List<Coding> coding { get; set; }
    }

    public class Resource
    {
        public string resourceType { get; set; }
        public string status { get; set; }
        public string date { get; set; }
        public bool wasNotGiven { get; set; }
        public bool reported { get; set; }
        public string lotNumber { get; set; }
        public string id { get; set; }
        public VaccineCode vaccineCode { get; set; }
        public Patient patient { get; set; }
        public Site site { get; set; }
        public Route route { get; set; }
    }

    public class Entry
    {
        public string fullUrl { get; set; }
        public List<Link2> link { get; set; }
        public Search search { get; set; }
        public Resource resource { get; set; }
    }
}