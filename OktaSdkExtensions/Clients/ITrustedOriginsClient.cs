using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.TrustedOrigins;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    /// <summary>A client that works with Okta Authorisation Trusted Origin resources.</summary>
    public interface ITrustedOriginsClient 
    {
        /// <summary>
        /// Create a trusted origin
        /// </summary>
        Task<ITrustedOrigin> CreateTrustedOrigin(CreateTrustedOriginOptions options, CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Update a trusted origin
        /// </summary>
        Task<ITrustedOrigin> UpdateTrustedOrigin(string id, UpdateTrustedOriginOptions options, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List the existing trusted origins
        /// </summary>
        /// <returns></returns>
        ICollectionClient<TrustedOrigin> ListTrustedOrigins();
    }
}