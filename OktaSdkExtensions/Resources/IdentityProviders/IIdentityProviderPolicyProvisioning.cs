using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderPolicyProvisioning : IResource
    {
        string Action { get; set; }
        bool? ProfileMaster { get; set; }
        IIdentityProviderPolicyProvisioningGroups Groups { get; set; }
        IIdentityProviderPolicyProvisioningConditions Conditions { get; set; }
    }
}