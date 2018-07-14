using Gsk.Hack.Schedule.API.Models;
using Gsk.Hack.Schedule.API.Repositories;
using System;
using System.Web.Http;

namespace Gsk.Hack.Schedule.API.Controllers
{
    [RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
        [HttpGet]
        [Route]
        [Route("resources")]
        public IHttpActionResult Resources(string names)
        {
            string[] patientNames = names.Split(',');

            try
            {
                using (MySqlRepository repository = new MySqlRepository())
                {
                    var results = repository.GetNumberOfResources(patientNames.Length);
                    return Ok(results);
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("recommend")]
        public IHttpActionResult Recommend(RecommendRequest request)
        {
            try
            {
                if(request == null)
                {
                    return BadRequest("The request body is null");
                }

                if(string.IsNullOrEmpty(request.ApointmentTime))
                {
                    return BadRequest("No apointment set");
                }

                if(string.IsNullOrEmpty(request.CallerName))
                {
                    return BadRequest("No caller name set");
                }

                if (string.IsNullOrEmpty(request.PatientName))
                {
                    return BadRequest("No patient name set");
                }

                DateTime appointmentTime;

                if (DateTime.TryParse(request.ApointmentTime, out appointmentTime))
                {
                    using (MySqlRepository repository = new MySqlRepository())
                    {
                        var results = repository.GetVaccines(request.CallerName);
                        return Ok(results);
                    }
                }
                else
                {
                    return BadRequest("Could not parse date time");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }  
        }
    }
}