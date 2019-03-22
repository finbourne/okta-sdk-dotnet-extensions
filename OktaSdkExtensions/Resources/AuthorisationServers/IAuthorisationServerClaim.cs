using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public interface IAuthorisationServerClaim : IResource
    {
        string Id { get; set; }
        string Name { get; set; }
        string Status { get; set; }
        string ClaimType { get; set; }
        string ValueType { get; set; }
        string Value { get; set; }
        string GroupFilterType { get; set; }
        bool? AlwaysIncludeInToken { get; set; }
        bool? System { get; set; }
        IAuthorisationServerClaimCondition Conditions { get; set; }
    }
}