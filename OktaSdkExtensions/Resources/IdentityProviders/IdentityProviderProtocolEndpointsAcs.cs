using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderProtocolEndpointsAcs : Resource, IIdentityProviderProtocolEndpointsAcs 
    {
        public string Binding 
        {
            get => GetStringProperty("binding");
            set => this["binding"] = value;
        }

        public string Type 
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
    }
}