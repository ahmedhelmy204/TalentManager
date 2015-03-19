using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace TalentManager.Modules
{
    public class MyHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                // Authenticate here using the credentials from authorization header

                // On successful authentication, set principal
                var identity = new ClaimsIdentity(new[] { new Claim("type", "value") }, "AuthnType");

                var principal = new ClaimsPrincipal(identity);

                Thread.CurrentPrincipal = principal;

                if (HttpContext.Current != null)
                    HttpContext.Current.User = principal;
            }
        }

        void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;

            // Do anything with response such as checking status code and
            // adding response headers
        }

        public void Dispose() { }


    }
}