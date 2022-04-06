using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections;
using System.Collections.Generic;

namespace WhereBy.WebApi.Identity
{
    public class IdentityConfiguration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("WhereByWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("WhereByWebAPI", "Web API", new []
                {
                    JwtClaimTypes.Name
                })
                {
                    Scopes = { "WhereByWebAPI" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "whereby-web-api",
                    ClientName = "WhereBy Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "http://.../sign-in"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://..."
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://.../sing-out"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "WhereByWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
