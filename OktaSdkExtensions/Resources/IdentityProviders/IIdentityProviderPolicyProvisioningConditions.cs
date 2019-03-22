using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderPolicyProvisioningConditions : IResource
    {
        IIdentityProviderPolicyProvisioningCondition Deprovisioned { get; set; }
        IIdentityProviderPolicyProvisioningCondition Suspended { get; set; }
    }
}