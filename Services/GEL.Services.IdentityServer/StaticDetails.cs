﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GEL.Services.IdentityServer
{
    public static class StaticDetails
    {
        public const string Admin = "Admin";
        public const string Viewer = "Viewer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("gel", "GEL Server"),
                new ApiScope(name: "read", displayName: "Read your data."),
                new ApiScope(name: "write", displayName: "Write your data."),
                new ApiScope(name: "delete", displayName: "Delete your data."),
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "read", "write", "profile" }
                },
                new Client
                {
                    ClientId = "mango",
                    ClientSecrets = { new Secret("secrte".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "http://localhost:44382/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:44382/signout-callback-iodc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "gel"
                    }
                }
            };
    }
}
