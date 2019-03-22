using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.Tokens;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    /// <inheritdoc />
    public class TokensClient : ITokensClient
    {
        private readonly IOktaClient _client;

        /// <summary>
        /// Create an client for interacting with Okta tokens.
        /// </summary>
        public TokensClient(IOktaClient client)
        {
            _client = client;
        }
        
        /// <inheritdoc />
        public async Task<IPopulatedToken> CreateToken(CreateTokenOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl("/api/internal/tokens?expand=user");
            return await _client.PostAsync<PopulatedToken>(requestUrl.AbsoluteUri, options, cancellationToken);
        }

        /// <inheritdoc />
        public ICollectionClient<TokenInfo> ListTokens()
        {
            var requestUrl = _client.Configuration.BuildUrl("/api/internal/tokens?expand=user");
            return _client.GetCollection<TokenInfo>(requestUrl.AbsoluteUri);
        }
    }
}