using Microsoft.AspNetCore.Http;
using SwaggerOAS3RestAPI.Security;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerOAS3RestAPI.Middlewares
{
    public class SwaggerBasicAuth
    {
        private readonly RequestDelegate RequestDelegate;

        public SwaggerBasicAuth(RequestDelegate RequestDelegate)
        {
            this.RequestDelegate = RequestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // If the user tries to access some documentation page, he is asked to insert his credentials. Otherwise the process continues.
            if (context.Request.Path.StartsWithSegments("/docs"))
            {
                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Basic "))
                {
                    var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
                    var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                    var username = decodedUsernamePassword.Split(':', 2)[0];
                    var password = decodedUsernamePassword.Split(':', 2)[1];

                    Security.ICredentials UserCredentials = new UserCredentials(username, password);

                    if (IsAuthorized(UserCredentials))
                    {
                        await RequestDelegate.Invoke(context);
                        return;
                    }
                }
                context.Response.Headers["WWW-Authenticate"] = "Basic";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                await RequestDelegate.Invoke(context);
            }
        }

        public bool IsAuthorized(Security.ICredentials UserCredentials)
        {
            bool isValidWebServiceUser = (UserCredentials.UserName == "dragon" && UserCredentials.Password == "ball");
            return isValidWebServiceUser;
        }
    }
}