using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderProtocolEndpointsSso : IResource
    {
        string Url { get; set; }
        string Binding { get; set; }
        string Destination { get; set; }
    }
}