using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("api")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                ////machine to machine client
                //new Client
                //{
                //    ClientId = "client",

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,

                //    ClientSecrets = { new Secret("secret".Sha256()) },

                //    AllowedScopes = { "api" }
                //},
                //// ASP.NET Core MVC client
                //new Client
                //{
                //    ClientId = "mvc",
                //    ClientSecrets = { new Secret("secret".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.Code,

                //    RedirectUris = { "http://mvc.client/signin-oidc" },
                //    //RedirectUris = { "https://localhost:5003/signin-oidc" },

                //    PostLogoutRedirectUris = { "http://mvc.client/signout-callback-oidc" },
                //    //PostLogoutRedirectUris = { "https://localhost:5003/signout-callback-oidc" },

                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile
                //    }
                //},
                new Client
                {
                    ClientId = "angular_spa",
                    ClientName = "Angular SPA",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "api" },
                    RedirectUris = { "http://localhost:4200/secure" },
                    PostLogoutRedirectUris = { "http://localhost:4200" },
                    AllowedCorsOrigins = { "http://localhost:4200" },
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600,

                    EnableLocalLogin = true,
                    RequireConsent = false,
                    RequireClientSecret = false,
                }
            };
    }
}