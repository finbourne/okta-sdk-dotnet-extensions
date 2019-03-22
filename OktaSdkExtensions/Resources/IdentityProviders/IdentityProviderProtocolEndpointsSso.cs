using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderProtocolEndpointsSso : Resource, IIdentityProviderProtocolEndpointsSso 
    {
        public string Url 
        {
            get => GetStringProperty("url");
            set => this["url"] = value;
        }
        public string Binding 
        {
            get => GetStringProperty("binding");
            set => this["binding"] = value;
        }
        public string Destination 
        {
            get => GetStringProperty("destination");
            set => this["destination"] = value;
        }
    }
}