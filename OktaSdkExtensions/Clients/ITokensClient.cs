using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.Tokens;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    /// <summary>A client that works with Okta Authorisation Token resources.</summary>
    public interface ITokensClient 
    {
        /// <summary>
        /// Create a token. This is the only way to get the actual token secret for a token. The token will be created for the current user.
        /// </summary>
        Task<IPopulatedToken> CreateToken(CreateTokenOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List the existing tokens. This will not return any of the actual token secrets, just the metadata.
        /// </summary>
        /// <returns></returns>
        ICollectionClient<TokenInfo> ListTokens();
    }
}