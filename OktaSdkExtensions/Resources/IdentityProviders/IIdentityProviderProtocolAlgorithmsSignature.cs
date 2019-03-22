using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderProtocolAlgorithmsSignature : IResource
    {
        string Algorithm { get; set; }
        string Scope { get; set; }
    }
}