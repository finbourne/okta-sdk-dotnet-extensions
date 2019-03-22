namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public interface IAuthorisationServerPolicyPeopleRuleCondition
    {
        IAuthorisationServersCondition Users { get; set; }
        IAuthorisationServersCondition Groups { get; set; }
        
    }
}