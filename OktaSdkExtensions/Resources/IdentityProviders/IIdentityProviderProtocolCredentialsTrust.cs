using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderProtocolCredentialsTrust : IResource
    {
        string Issuer { get; set; }
        string Audience { get; set; }
        string Kid { get; set; }
        string Revocation { get; set; }
        int? RevocationCacheLifetime { get; set; }
    }
}