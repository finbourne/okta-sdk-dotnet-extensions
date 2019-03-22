using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderPolicyProvisioning : Resource, IIdentityProviderPolicyProvisioning 
    {
        public string Action 
        {
            get => GetStringProperty("action");
            set => this["action"] = value;
        }
        public bool? ProfileMaster 
        {
            get => GetBooleanProperty("profileMaster");
            set => this["profileMaster"] = value;
        }
        public IIdentityProviderPolicyProvisioningGroups Groups 
        {
            get => GetResourceProperty<IdentityProviderPolicyProvisioningGroups>("groups");
            set => this["groups"] = value;
        }
        public IIdentityProviderPolicyProvisioningConditions Conditions
        {
            get => GetResourceProperty<IdentityProviderPolicyProvisioningConditions>("conditions");
            set => this["conditions"] = value;
        }
    }
}