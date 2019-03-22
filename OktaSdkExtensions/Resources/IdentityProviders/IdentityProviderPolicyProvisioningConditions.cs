using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderPolicyProvisioningConditions : Resource, IIdentityProviderPolicyProvisioningConditions 
    {
        public IIdentityProviderPolicyProvisioningCondition Deprovisioned 
        {
            get => GetResourceProperty<IdentityProviderPolicyProvisioningCondition>("deprovisioned");
            set => this["deprovisioned"] = value;
        }
        public IIdentityProviderPolicyProvisioningCondition Suspended 
        {
            get => GetResourceProperty<IdentityProviderPolicyProvisioningCondition>("suspended");
            set => this["suspended"] = value;
        }
    }
}