using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderProtocolEndpointsAcs : IResource
    {
        string Binding { get; set; }
        string Type { get; set; }
    }
}