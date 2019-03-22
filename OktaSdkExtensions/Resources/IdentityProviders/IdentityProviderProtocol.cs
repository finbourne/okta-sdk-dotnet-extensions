using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderProtocol : Resource, IIdentityProviderProtocol 
    {
        public string Type   
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        public IIdentityProviderProtocolEndpoints Endpoints    
        {
            get => GetResourceProperty<IdentityProviderProtocolEndpoints>("endpoints");
            set => this["endpoints"] = value;
        }
        public IIdentityProviderProtocolAlgorithms Algorithms    
        {
            get => GetResourceProperty<IdentityProviderProtocolAlgorithms>("algorithms");
            set => this["algorithms"] = value;
        }
        public IIdentityProviderProtocolSettings Settings    
        {
            get => GetResourceProperty<IdentityProviderProtocolSettings>("settings");
            set => this["settings"] = value;
        }
        public IIdentityProviderProtocolCredentials Credentials    
        {
            get => GetResourceProperty<IdentityProviderProtocolCredentials>("credentials");
            set => this["credentials"] = value;
        }
    }
}