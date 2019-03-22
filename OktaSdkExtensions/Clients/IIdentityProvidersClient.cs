using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    /// <summary>A client that works with Okta Identity Provider resources.</summary>
    public interface IIdentityProvidersClient 
    {
        /// <summary>
        /// List all of the currently registered identity provider credential keys (certificates)
        /// </summary>
        /// <returns></returns>
        ICollectionClient<IdentityProviderCredentialKey> GetAllCredentialKeys();
        
        /// <summary>
        /// Add a credential key (certificate) to the key store
        /// </summary>
        /// <returns></returns>
        Task<IIdentityProviderCredentialKey> CreateCredentialKey(CreateIdentityProviderCredentialKeyOptions options, CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// List all of the currently registered identity providers
        /// </summary>
        /// <returns></returns>
        ICollectionClient<IdentityProvider> GetAllIdentityProviders();
        
    }
}