using Aaks.Restclient;
using Gsk.Hack.Schedule.API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Gsk.Hack.Schedule.API.Controllers
{
    [RoutePrefix("api/epic")]
    public class EpicController : ApiController
    {
        [HttpGet]
        [Route("code")]
        [EnableCors("*", "*", "GET")]
        public IHttpActionResult Code([FromUri]string code)
        {
            Cache.AuthToken.Instance().SetCode(code);

            return Ok();
        }

        [HttpGet]
        [Route("authurl")]
        [EnableCors("*", "*", "GET")]
        public IHttpActionResult GetAuthUrl()
        {
            return Ok(
                string.Format(
                    "https://open-ic.epic.com/argonaut/oauth2/authorize?response_type=code&client_id={0}&redirect_uri={1}",
                    ConfigurationManager.AppSettings["EpicClinetId"],
                    ConfigurationManager.AppSettings["EpicCallbackUrl"]));
        }


        [HttpGet]
        [Route("patientinfo")]
        [EnableCors("*", "*", "GET")]
        public IHttpActionResult GetPatientInfo()
        {
            try
            {
                if (string.IsNullOrEmpty(Cache.AuthToken.Instance().GetAccessToken()))
                {
                    if (string.IsNullOrEmpty(Cache.AuthToken.Instance().GetCode()))
                    {
                        return BadRequest("Authoriaztion Code is empty");
                    }

                    var authResponse = GetAuthResponse();

                    if (authResponse.StatusCode != HttpStatusCode.OK)
                    {
                        return BadRequest(authResponse.ErrorMessage);
                    }
                }

                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", "Bearer " + Cache.AuthToken.Instance().GetAccessToken());

                HttpRestClient client = new HttpRestClient();
                var patientResponse = client.Get<EpicPatientResposne>(
                    "https://open-ic.epic.com/argonaut/api/FHIR/Argonaut/Patient/Tbt3KuCY0B5PSrJvCu2j-PlK.aiHsu2xUjUM8bWpetXoB",
                    headers);

                var immunizationResponse = client.Get<EpicVacinationsResponse>(
                    "https://open-ic.epic.com/FHIR/api/FHIR/DSTU2/Immunization?patient=Tbt3KuCY0B5PSrJvCu2j-PlK.aiHsu2xUjUM8bWpetXoB",
                    headers);

                return Ok(new PatientResposne(patientResponse.Body, immunizationResponse.Body));

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        private static Aaks.RestclientTests.Model.HttpResponse<EpicOauthResponse> GetAuthResponse()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("grant_type=authorization_code&code=");
            sb.Append(Cache.AuthToken.Instance().GetCode());
            sb.Append("&redirect_uri=");
            sb.Append(ConfigurationManager.AppSettings["EpicCallbackUrl"]);
            sb.Append("&client_id=");
            sb.Append(ConfigurationManager.AppSettings["EpicClinetId"]);

            HttpRestClient client = new HttpRestClient();
            var authResponse =
                client.PostApplicationForm<EpicOauthResponse>(
                    "https://open-ic.epic.com/argonaut/oauth2/token",
                    sb.ToString());

            if(authResponse.StatusCode == HttpStatusCode.OK)
            {
                Cache.AuthToken.Instance().SetAccessToken(authResponse.Body.access_token);
            }
            
            return authResponse;
        }
    }
}
