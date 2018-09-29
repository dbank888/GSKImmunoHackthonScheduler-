using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Models
{
    public class PatientResposne
    {
        public EpicPatientResposne Patient { get; set; }
        public EpicVacinationsResponse Vacinations { get; set; }

        public PatientResposne(EpicPatientResposne patient, EpicVacinationsResponse vacinations)
        {
            Patient = patient;
            Vacinations = vacinations;
        }
    }
}