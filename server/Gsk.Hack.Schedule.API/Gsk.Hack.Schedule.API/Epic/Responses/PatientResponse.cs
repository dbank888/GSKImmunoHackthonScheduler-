using Gsk.Hack.Schedule.API.Epic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Epic.Responses
{
    public class PatientResponse
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
}