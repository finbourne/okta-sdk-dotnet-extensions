using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderPolicy : IResource
    {
        
        IIdentityProviderPolicyProvisioning Provisioning { get; set; }
        IIdentityProviderPolicyAccountLink AccountLink { get; set; }
        IIdentityProviderPolicySubject Subject { get; set; }
        int? MaxClockSkew { get; set; }
    }
}