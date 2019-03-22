using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderPolicySubjectUserNameTemplate : Resource, IIdentityProviderPolicySubjectUserNameTemplate 
    {
        public string Template 
        {
            get => GetStringProperty("template");
            set => this["template"] = value;
        }
    }
}