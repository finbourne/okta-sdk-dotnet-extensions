namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public interface IAuthorisationServerPolicyRuleConditionSet
    {
        IAuthorisationServerPolicyPeopleRuleCondition People { get; set; }
        IAuthorisationServersCondition GrantTypes { get; set; }
        IAuthorisationServersCondition Scopes { get; set; }
        
    }
}