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
            

            return Ok("{\"resourceType\":\"Patient\",\"birthDate\":\"1985-08-01\",\"active\":true,\"gender\":\"male\",\"deceasedBoolean\":false,\"id\":\"Tbt3KuCY0B5PSrJvCu2j-PlK.aiHsu2xUjUM8bWpetXoB\",\"careProvider\":[{\"display\":\"Physician Family Medicine\",\"reference\":\"https:////open-ic.epic.com//Argonaut//api//FHIR//DSTU2//Practitioner//T3Mz3KLBDVXXgaRoee3EKAAB\"}],\"name\":[{\"use\":\"usual\",\"text\":\"Jason Argonaut\",\"family\":[\"Argonaut\"],\"given\":[\"Jason\"]}],\"identifier\":[{\"use\":\"usual\",\"system\":\"urn:oid:1.2.840.114350.1.13.327.1.7.5.737384.0\",\"value\":\"E3826\"},{\"use\":\"usual\",\"system\":\"urn:oid:1.2.3.4\",\"value\":\"203579\"}],\"address\":[{\"use\":\"home\",\"line\":[\"1979 Milky Way Dr.\"],\"city\":\"Verona\",\"state\":\"WI\",\"postalCode\":\"53593\",\"country\":\"US\"},{\"use\":\"temp\",\"line\":[\"5301 Tokay Blvd\"],\"city\":\"MADISON\",\"state\":\"WI\",\"postalCode\":\"53711\",\"country\":\"US\",\"period\":{\"start\":\"2011-08-04T00:00:00Z\",\"end\":\"2014-08-04T00:00:00Z\"}}],\"telecom\":[{\"system\":\"phone\",\"value\":\"608-271-9000\",\"use\":\"home\"},{\"system\":\"phone\",\"value\":\"608-771-9000\",\"use\":\"work\"},{\"system\":\"phone\",\"value\":\"608-771-9000\",\"use\":\"mobile\"},{\"system\":\"fax\",\"value\":\"608-771-9000\",\"use\":\"home\"},{\"system\":\"phone\",\"value\":\"608-771-9000\",\"use\":\"temp\",\"period\":{\"start\":\"2011-08-04T00:00:00Z\",\"end\":\"2014-08-04T00:00:00Z\"}},{\"system\":\"email\",\"value\":\"open@epic.com\"}],\"maritalStatus\":{\"text\":\"Single\",\"coding\":[{\"system\":\"http:////hl7.org//fhir//ValueSet//marital-status\",\"code\":\"S\",\"display\":\"Never Married\"}]},\"communication\":[{\"preferred\":true,\"language\":{\"text\":\"English\",\"coding\":[{\"system\":\"urn:oid:2.16.840.1.113883.6.99\",\"code\":\"en\",\"display\":\"English\"}]}}],\"extension\":[{\"url\":\"http:////hl7.org//fhir//StructureDefinition//us-core-race\",\"valueCodeableConcept\":{\"text\":\"Asian\",\"coding\":[{\"system\":\"2.16.840.1.113883.5.104\",\"code\":\"2028-9\",\"display\":\"Asian\"}]}},{\"url\":\"http:////hl7.org//fhir//StructureDefinition//us-core-ethnicity\",\"valueCodeableConcept\":{\"text\":\"Not Hispanic or Latino\",\"coding\":[{\"system\":\"2.16.840.1.113883.5.50\",\"code\":\"2186-5\",\"display\":\"Not Hispanic or Latino\"}]}},{\"url\":\"http:////hl7.org//fhir//StructureDefinition//us-core-birth-sex\",\"valueCodeableConcept\":{\"text\":\"Male\",\"coding\":[{\"system\":\"http:////hl7.org//fhir//v3//AdministrativeGender\",\"code\":\"M\",\"display\":\"Male\"}]}}]}");
        }

        [HttpGet]
        [Route("oauthtest")]
        [EnableCors("*", "*", "GET")]
        public IHttpActionResult TestOauth()
        {
            try
            {
                if(string.IsNullOrEmpty(Cache.AuthToken.Instance().GetAccessToken()))
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
