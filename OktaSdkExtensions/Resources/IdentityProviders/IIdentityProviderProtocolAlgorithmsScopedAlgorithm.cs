using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderProtocolAlgorithmsScopedAlgorithm : IResource
    {
        IIdentityProviderProtocolAlgorithmsSignature Signature { get; set; }
    }
}