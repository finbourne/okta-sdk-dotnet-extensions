using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderPolicyProvisioningCondition : Resource, IIdentityProviderPolicyProvisioningCondition 
    {
        public string Action 
        {
            get => GetStringProperty("action");
            set => this["action"] = value;
        }
    }
}