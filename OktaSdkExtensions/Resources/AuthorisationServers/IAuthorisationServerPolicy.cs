using System;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public interface IAuthorisationServerPolicy : IResource
    {
        string Id { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        string Status { get; set; }
        string Type { get; set; }
        int? Priority { get; set; }
        bool? System { get; set; }
        DateTimeOffset? Created { get; set; }
        DateTimeOffset? LastUpdated { get; set; }
        IAuthorisationServerPolicyCondition Conditions { get; set; }
    }
}