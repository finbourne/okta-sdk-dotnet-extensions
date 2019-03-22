using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderPolicyAccountLink : Resource, IIdentityProviderPolicyAccountLink 
    {
        public string Filter 
        {
            get => GetStringProperty("filter");
            set => this["filter"] = value;
        }

        public string Action 
        {
            get => GetStringProperty("action");
            set => this["action"] = value;
        }
    }
}