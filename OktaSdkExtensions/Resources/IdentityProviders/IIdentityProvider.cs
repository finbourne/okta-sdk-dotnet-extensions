using System;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProvider : IResource
    {
        string Id { get; set; }
        string Type { get; set; }
        string Name { get; set; }
        string Status { get; set; }
        DateTimeOffset? Created { get; set; }
        DateTimeOffset? LastUpdated { get; set; }
        
        IIdentityProviderProtocol Protocol  { get; set; }
        IIdentityProviderPolicy Policy  { get; set; }
    }
}