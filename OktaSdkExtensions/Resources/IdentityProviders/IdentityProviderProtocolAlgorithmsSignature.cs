using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderProtocolAlgorithmsSignature : Resource, IIdentityProviderProtocolAlgorithmsSignature 
    {
        public string Algorithm  
        {
            get => GetStringProperty("algorithm");
            set => this["algorithm"] = value;
        }
        public string Scope 
        {
            get => GetStringProperty("scope");
            set => this["scope"] = value;
        }
    }
}