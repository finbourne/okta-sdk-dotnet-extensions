using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderProtocolCredentials : IResource
    {
        IIdentityProviderProtocolCredentialsTrust Trust { get; set; }
        IIdentityProviderProtocolCredentialsSigning Signing { get; set; }
    }
}