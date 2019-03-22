using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class AuthorisationServerPolicyRuleConditionSet : Resource, IAuthorisationServerPolicyRuleConditionSet
    {
        public IAuthorisationServerPolicyPeopleRuleCondition People
        {
            get => GetResourceProperty<AuthorisationServerPolicyPeopleRuleCondition>("people");
            set => this["people"] = value;
        }
        
        public IAuthorisationServersCondition GrantTypes
        {
            get => GetResourceProperty<AuthorisationServersCondition>("grantTypes");
            set => this["grantTypes"] = value;
        }
        
        public IAuthorisationServersCondition Scopes
        {
            get => GetResourceProperty<AuthorisationServersCondition>("scopes");
            set => this["scopes"] = value;
        }
    }
}