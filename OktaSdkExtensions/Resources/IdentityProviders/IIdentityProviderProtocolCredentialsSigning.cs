using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderProtocolCredentialsSigning : IResource
    {
        string Kid { get; set; }
    }
}