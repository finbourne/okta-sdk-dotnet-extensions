using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderProtocolEndpoints : IResource
    {
        IIdentityProviderProtocolEndpointsSso Sso { get; set; }
        IIdentityProviderProtocolEndpointsAcs Acs { get; set; }
    }
}