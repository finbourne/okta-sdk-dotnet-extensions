using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderPolicyAccountLink : IResource
    {
        string Filter { get; set; }
        string Action { get; set; }
    }
}