using System;
using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.TrustedOrigins
{
    public interface ITrustedOrigin : IResource
    {
        string Id { get; set; }
        string Name { get; set; }
        string Origin { get; set; }
        string Status { get; set; }
        
        IList<ITrustedOriginScope> Scopes { get; set; }
        
        DateTimeOffset? Created { get; set; }
        string CreatedBy { get; set; }
        DateTimeOffset? LastUpdated { get; set; }
        string LastUpdatedBy { get; set; }
    }
}