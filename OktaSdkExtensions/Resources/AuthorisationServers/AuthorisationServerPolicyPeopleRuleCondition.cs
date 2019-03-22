using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class AuthorisationServerPolicyPeopleRuleCondition : Resource, IAuthorisationServerPolicyPeopleRuleCondition
    {
        public IAuthorisationServersCondition Users
        {
            get => GetResourceProperty<AuthorisationServersCondition>("users");
            set => this["users"] = value;
        }
        
        public IAuthorisationServersCondition Groups
        {
            get => GetResourceProperty<AuthorisationServersCondition>("groups");
            set => this["groups"] = value;
        }
    }
}