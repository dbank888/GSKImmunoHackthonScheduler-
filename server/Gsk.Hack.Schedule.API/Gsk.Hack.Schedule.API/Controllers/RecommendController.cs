using Gsk.Hack.Schedule.API.Models;
using Gsk.Hack.Schedule.API.Repositories;
using System;
using System.Web.Http;

namespace Gsk.Hack.Schedule.API.Controllers
{
    [RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
        [HttpPost]
        [Route("recommend")]
        public IHttpActionResult Recommend(RecommendRequest request)
        {
            try
            {
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