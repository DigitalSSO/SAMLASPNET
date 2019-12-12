using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Sustainsys.Saml2;
using Sustainsys.Saml2.Configuration;
using Sustainsys.Saml2.Metadata;
using Sustainsys.Saml2.Owin;

namespace SAMLASPNET
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            var options = new Saml2AuthenticationOptions(false);
            options.SPOptions = CreateSPOptions();
            options.SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
            options.IdentityProviders.Add(new IdentityProvider(new EntityId("http://adfs.groupyfy.com/adfs/services/trust"), options.SPOptions)
            {
                MetadataLocation = "https://adfs.groupyfy.com/FederationMetadata/2007-06/FederationMetadata.xml",
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/saml2/signin")
            });

            app.UseSaml2Authentication(options);
        }

        private static SPOptions CreateSPOptions()
        {
            var spOptions = new SPOptions
            {
                EntityId = new EntityId("https://localhost:44338/saml2"),
                ReturnUrl = new Uri("https://localhost:44338/"),
                Logger = new Saml2DebugLogger()
            };

            return spOptions;
        }
    }
}