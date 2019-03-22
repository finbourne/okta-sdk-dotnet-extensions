using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderPolicy : Resource, IIdentityProviderPolicy 
    {
        public IIdentityProviderPolicyProvisioning Provisioning     
        {
            get => GetResourceProperty<IdentityProviderPolicyProvisioning>("provisioning");
            set => this["provisioning"] = value;
        }
        public IIdentityProviderPolicyAccountLink AccountLink    
        {
            get => GetResourceProperty<IdentityProviderPolicyAccountLink>("accountLink");
            set => this["accountLink"] = value;
        }
        public IIdentityProviderPolicySubject Subject     
        {
            get => GetResourceProperty<IdentityProviderPolicySubject>("subject");
            set => this["subject"] = value;
        }
        public int? MaxClockSkew 
        {
            get => GetIntegerProperty("maxClockSkew");
            set => this["maxClockSkew"] = value;
        }
    }
}