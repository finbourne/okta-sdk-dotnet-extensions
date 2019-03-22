using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.TrustedOrigins;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    public class TrustedOriginsClient : ITrustedOriginsClient
    {
        private readonly IOktaClient _client;

        /// <summary>
        /// Create an client for interacting with Okta authorisation servers
        /// </summary>
        /// <param name="client">A sufficiently provisioned and authorised Okta SDK client</param>
        public TrustedOriginsClient(IOktaClient client)
        {
            _client = client;
        }
        
        public async Task<ITrustedOrigin> CreateTrustedOrigin(CreateTrustedOriginOptions options,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl("/api/v1/trustedOrigins");
            return await _client.PostAsync<TrustedOrigin>(requestUrl.AbsoluteUri, options, cancellationToken);
        }
        
        public async Task<ITrustedOrigin> UpdateTrustedOrigin(string id, UpdateTrustedOriginOptions options,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/trustedOrigins/{id}");
            return await _client.PutAsync<TrustedOrigin>(requestUrl.AbsoluteUri, options, cancellationToken);
        }

        public ICollectionClient<TrustedOrigin> ListTrustedOrigins()
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/trustedOrigins");
            return _client.GetCollection<TrustedOrigin>(requestUrl.AbsoluteUri);
        }
    }
}