using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    /// <inheritdoc />
    public class IdentityProvidersClient : IIdentityProvidersClient
    {
        private readonly IOktaClient _client;

        /// <summary>
        /// Create an client for interacting with Okta identity providers.
        /// </summary>
        public IdentityProvidersClient(IOktaClient client)
        {
            _client = client;
        }
        
        /// <inheritdoc />
        public ICollectionClient<IdentityProviderCredentialKey> GetAllCredentialKeys()
        {
            var requestUrl = _client.Configuration.BuildUrl("/api/v1/idps/credentials/keys");
            return _client.GetCollection<IdentityProviderCredentialKey>(requestUrl.AbsoluteUri);
        }

        public async Task<IIdentityProviderCredentialKey> CreateCredentialKey(CreateIdentityProviderCredentialKeyOptions options,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl("/api/v1/idps/credentials/keys");
            return await _client.PostAsync<IdentityProviderCredentialKey>(requestUrl.AbsoluteUri, options, cancellationToken);
        }

        public ICollectionClient<IdentityProvider> GetAllIdentityProviders()
        {
            var requestUrl = _client.Configuration.BuildUrl("/api/v1/idps");
            return _client.GetCollection<IdentityProvider>(requestUrl.AbsoluteUri);
        }
    }
}