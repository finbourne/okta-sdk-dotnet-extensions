namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public interface IAuthorisationServerPolicyCondition
    {
        IAuthorisationServersCondition Clients { get; set; }
    }
}