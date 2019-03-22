using System;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public interface IAuthorisationServerPolicyRule : IResource
    {
        string Type { get; set; }
        string Id { get; set; }
        string Status { get; set; }
        string Name { get; set; }
        int? Priority { get; set; }
        bool? System { get; set; }
        DateTimeOffset? Created { get; set; }
        DateTimeOffset? LastUpdated { get; set; }
        IAuthorisationServerPolicyRuleConditionSet Conditions { get; set; }
        
        IAuthorisationServerActions Actions { get; set; }
    }
}