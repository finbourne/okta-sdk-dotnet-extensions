using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderProtocolEndpoints : Resource, IIdentityProviderProtocolEndpoints 
    {
        public IIdentityProviderProtocolEndpointsSso Sso 
        {
            get => GetResourceProperty<IdentityProviderProtocolEndpointsSso>("sso");
            set => this["sso"] = value;
        }
        public IIdentityProviderProtocolEndpointsAcs Acs 
        {
            get => GetResourceProperty<IdentityProviderProtocolEndpointsAcs>("acs");
            set => this["acs"] = value;
        }
    }
}