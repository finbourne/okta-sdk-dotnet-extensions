using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderPolicyProvisioningCondition : IResource
    {
        string Action { get; set; }
    }
}