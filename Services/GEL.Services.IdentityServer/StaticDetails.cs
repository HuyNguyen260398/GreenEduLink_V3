using Duende.IdentityServer;
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
                    ClientId = "gel",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:44342/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44342/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        "gel"
                    }
                }
            };
    }
}
