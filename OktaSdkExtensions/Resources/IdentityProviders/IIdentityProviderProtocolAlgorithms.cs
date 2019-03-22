using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderProtocolAlgorithms : IResource
    {
        IIdentityProviderProtocolAlgorithmsScopedAlgorithm Request { get; set; }
        IIdentityProviderProtocolAlgorithmsScopedAlgorithm Response { get; set; }
    }
}