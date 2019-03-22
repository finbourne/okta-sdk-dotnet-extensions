using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderPolicySubject : Resource, IIdentityProviderPolicySubject 
    {
        public IIdentityProviderPolicySubjectUserNameTemplate UserNameTemplate 
        {
            get => GetResourceProperty<IdentityProviderPolicySubjectUserNameTemplate>("userNameTemplate");
            set => this["userNameTemplate"] = value;
        }

        public string Filter 
        {
            get => GetStringProperty("filter");
            set => this["filter"] = value;
        }

        public string MatchType 
        {
            get => GetStringProperty("matchType");
            set => this["matchType"] = value;
        }
        public string MatchAttribute 
        {
            get => GetStringProperty("matchAttribute");
            set => this["matchAttribute"] = value;
        }
    }
}