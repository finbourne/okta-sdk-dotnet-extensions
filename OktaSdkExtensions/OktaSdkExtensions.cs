using Finbourne.Extensions.Okta.Sdk.Clients;
using Finbourne.Extensions.Okta.Sdk.Resources.Settings;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk
{
    /// <summary>
    /// Addition features from the Okta API that have not yet made it into the SDK
    /// </summary>
    public static class OktaSdkExtensions
    {
        /// <summary>
        /// Gets an OrganisationsClient that interacts with the Okta Organisations API.
        /// </summary>
        /// <param name="client">A suitably authorised Okta client</param>
        /// <returns>An client for interacting with Okta organisations</returns>
        public static IOrganisationsClient Organisations(this IOktaClient client)
        {
            return new OrganisationsClient(client);
        }

        /// <summary>
        /// Get a AuthorisationServersClient that interacts with the Okta AuthorisationServers API
        /// </summary>
        /// <param name="client">A suitably authorised Okta client</param>
        /// <returns>An client for interacting with Okta authorisation servers</returns>
        public static IAuthorisationServersClient AuthorisationServers(this IOktaClient client)
        {
            return new AuthorisationServersClient(client);
        }
        
        /// <summary>
        /// Get a TokensClient that interacts with the Okta Tokens API
        /// </summary>
        /// <param name="client">A suitably authorised Okta client</param>
        /// <returns>An client for interacting with Okta tokens</returns>
        public static ITokensClient Tokens(this IOktaClient client)
        {
            return new TokensClient(client);
        }
        
        /// <summary>
        /// Get a TrustedOriginsClient that interacts with the Okta TrustedOrigins API
        /// </summary>
        /// <param name="client">A suitably authorised Okta client</param>
        /// <returns>An client for interacting with Okta trusted origins</returns>
        public static ITrustedOriginsClient TrustedOrigins(this IOktaClient client)
        {
            return new TrustedOriginsClient(client);
        }
        
        
        /// <summary>
        /// Get a ISchemasClient that interacts with the Okta Schemas API
        /// </summary>
        /// <param name="client">A suitably authorised Okta client</param>
        /// <returns>An client for interacting with Okta schemas</returns>
        public static ISchemasClient Schemas(this IOktaClient client)
        {
            return new SchemasClient(client);
        }
        
        
        /// <summary>
        /// Get a ISettingsClient that interacts with the Okta settings APIs
        /// </summary>
        /// <param name="client">A suitably authorised Okta client</param>
        /// <returns>An client for interacting with Okta organisation settings</returns>
        public static IOrganisationSettingsClient OrganisationSettings(this IOktaClient client)
        {
            return new OrganisationSettingsClient(client);
        }
        
        
        /// <summary>
        /// Get a I that interacts with the Okta identity provider APIs
        /// </summary>
        /// <param name="client">A suitably authorised Okta client</param>
        /// <returns>An client for interacting with Okta identity providers</returns>
        public static IIdentityProvidersClient IdentityProviders(this IOktaClient client)
        {
            return new IdentityProvidersClient(client);
        }
    }
}