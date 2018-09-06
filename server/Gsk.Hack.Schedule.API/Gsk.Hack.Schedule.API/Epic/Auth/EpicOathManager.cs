using Aaks.Restclient;
using Gsk.Hack.Schedule.API.Epic.Model;
using Gsk.Hack.Schedule.API.Epic.Requests;
using Gsk.Hack.Schedule.API.Epic.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Epic.Auth
{
    public class EpicOathManager
    {
        private const string ClinetId = "230ebfda-20dc-438a-9935-b85d42ddeb11";
        private const string RedirectUrl = "https://alburt.us/api/epic";

        public AuthMetaDataResponse MakeMetaDataRequest()
        {
            const string baseUrl = "https://open-ic.epic.com/Argonaut/api/FHIR/Argonaut/metadata";

            var client = new HttpRestClient();
            var response = client.Get<AuthMetaDataResponse>(baseUrl);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Body;
            }
            else
            {
                return null;
            }
        }

        public string MakeAccessTokenRequest(string code)
        {
            const string baseUrl = "https://open-ic.epic.com/argonaut/oauth2/token";

            var accessTokenRequest = new AccessTokenRequest();
            accessTokenRequest.grant_type = "authorization_code";
            accessTokenRequest.code = code;
            accessTokenRequest.redirect_uri = RedirectUrl;
            accessTokenRequest.client_id = ClinetId;
            
            var client = new HttpRestClient();
            var response = client.Post<string, AccessTokenRequest>(baseUrl, accessTokenRequest, null, "application/x-www-form-urlencoded");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Body;
            }
            else
            {
                return null;
            }
        }

        public PatientResponse FetchPatientData(string accessToken)
        {
            const string patientUrl = "https://open-ic.epic.com/argonaut/api/FHIR/Argonaut/Patient/Tbt3KuCY0B5PSrJvCu2j-PlK.aiHsu2xUjUM8bWpetXoB";

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", "Bearer " + accessToken);

            var client = new HttpRestClient();
            var response = client.Get<PatientResponse>(patientUrl, headers);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Body;
            }
            else
            {
                return null;
            }
        }
    }
}