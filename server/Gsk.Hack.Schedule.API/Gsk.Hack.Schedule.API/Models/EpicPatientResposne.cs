using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Models
{
    public class EpicPatientResposne
    {
        public string resourceType { get; set; }
        public string birthDate { get; set; }
        public bool active { get; set; }
        public string gender { get; set; }
        public bool deceasedBoolean { get; set; }
        public string id { get; set; }
        public List<CareProvider> careProvider { get; set; }
        public List<Name> name { get; set; }
        public List<Identifier> identifier { get; set; }
        public List<Address> address { get; set; }
        public List<Telecom> telecom { get; set; }
        public MaritalStatus maritalStatus { get; set; }
        public List<Communication> communication { get; set; }
        public List<Extension> extension { get; set; }
    }

    public class CareProvider
    {
        public string display { get; set; }
        public string reference { get; set; }
    }

    public class Name
    {
        public string use { get; set; }
        public string text { get; set; }
        public List<string> family { get; set; }
        public List<string> given { get; set; }
    }

    public class Identifier
    {
        public string use { get; set; }
        public string system { get; set; }
        public string value { get; set; }
    }

    public class Period
    {
        public string start { get; set; }
        public string end { get; set; }
    }

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
    
    public class Telecom
    {
        public string system { get; set; }
        public string value { get; set; }
        public string use { get; set; }
        public Period period { get; set; }
    }

    

    public class MaritalStatus
    {
        public string text { get; set; }
        public List<Coding> coding { get; set; }
    }

   
    public class Language
    {
        public string text { get; set; }
        public List<Coding> coding { get; set; }
    }

    public class Communication
    {
        public bool preferred { get; set; }
        public Language language { get; set; }
    }

   

    public class ValueCodeableConcept
    {
        public string text { get; set; }
        public List<Coding> coding { get; set; }
    }

    public class Extension
    {
        public string url { get; set; }
        public ValueCodeableConcept valueCodeableConcept { get; set; }
    }
}