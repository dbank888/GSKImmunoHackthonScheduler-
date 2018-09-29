using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gsk.Hack.Schedule.API.Cache
{
    public class AuthToken
    {
        private static AuthToken _authToken = new AuthToken();

        private string Code;
        private string AccessToken;

        private AuthToken() { }

        public static AuthToken Instance()
        {
            return _authToken;
        }

        public void SetCode(string code)
        {
            _authToken.Code = code;
        }

        public string GetCode()
        {
            return _authToken.Code;
        }

        public void SetAccessToken(string accessToken)
        {
            _authToken.AccessToken = accessToken;
        }

        public string GetAccessToken()
        {
            return _authToken.AccessToken;
        }
    }
}