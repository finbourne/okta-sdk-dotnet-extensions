using System;
using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderCredentialKey : IResource
    {
        string Kty { get; set; }
        DateTimeOffset? Created { get; set; }
        DateTimeOffset? LastUpdated { get; set; }
        DateTimeOffset? ExpiresAt { get; set; }
        IList<string> X5C { get; set; }
        
        string Kid { get; set; }
        string Use { get; set; }
        string E { get; set; }
        string N { get; set; }
        string X5tS256Hash { get; set; }
    }
}