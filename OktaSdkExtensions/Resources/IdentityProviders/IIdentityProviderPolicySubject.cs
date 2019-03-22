using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderPolicySubject : IResource
    {
        IIdentityProviderPolicySubjectUserNameTemplate UserNameTemplate { get; set; }
        string Filter { get; set; }
        string MatchType { get; set; }
        string MatchAttribute { get; set; }
    }
}