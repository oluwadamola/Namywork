using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using NamyWork.Core.Manager;
using NamyWork.Data;
using Owin;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NamyWork.Web
{
    public static partial class AuthStartup
    {
        public static IAppBuilder ConfigureAuth(this IAppBuilder app)
        {
            OAuthAuthorizationServerOptions authOpts = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthTokenProvider()
            };

            app.UseOAuthAuthorizationServer(authOpts);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            return app;
        }
    }

    public class SimpleAuthTokenProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (var db = new DataEntities())
            {
                var usermanager = new UserManager(new EntityRepository(db));
                var validate = usermanager.ValidateUser(context.UserName, context.Password);
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                if (validate.Succeeded)
                {
                    //if validating the user succeeded...

                    //aggregate the claims that makeup the token
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                    //add any other relevant claim here...
                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, validate.Result.UserId.ToString()));


                    //Create Extra properties
                    var props = new Dictionary<string, string>
                        {
                            { "UserId", validate.Result.UserId.ToString() },
                            { "Email", validate.Result.Email },
                            { "FirstName", validate.Result.FirstName },
                            { "LastName", validate.Result.LastName },
                            { "ImageUrl", validate.Result.ImageUrl ?? "" }
                        };

                    context.Validated(new AuthenticationTicket(identity, new AuthenticationProperties(props)));
                }
                else
                {
                    //if validating the user didnt succeed...

                    context.SetError("invalid_grant", validate.Message);
                    return;
                }
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach(KeyValuePair<string,string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
    }
}