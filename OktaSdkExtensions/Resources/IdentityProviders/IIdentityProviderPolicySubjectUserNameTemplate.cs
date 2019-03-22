using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderPolicySubjectUserNameTemplate : IResource
    {
        string Template { get; set; }
    }
}