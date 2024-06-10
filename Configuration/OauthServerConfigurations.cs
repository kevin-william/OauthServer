using IdentityServer4.Test;
using IdentityServer4.Models;

namespace OauthServer.Configuration
{
    public static class OauthServerConfigurations
    {
        public static void ConfigureOauthServer(this IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryClients(GetClients())
                .AddInMemoryApiScopes(GetApiScopes())
                .AddInMemoryApiResources(GetApiResources())
                .AddInMemoryIdentityResources(GetIdentityResources())
                .AddTestUsers(GetUsers())
                .AddDeveloperSigningCredential();
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
        {
            new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "api1" }
            }
        };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
        {
            new ApiScope("api1", "My API")
        };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
        {
            new ApiResource("api1", "My API")
        };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "alice",
                Password = "password"
            }
        };
        }
    }
}
