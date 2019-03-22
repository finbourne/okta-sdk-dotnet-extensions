using System;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Tokens
{
    public interface ITokenInfo : IResource
    {
        string TokenType { get; set; }
        string ClientName { get; set; }
        string Status { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        
        DateTimeOffset? Created { get; set; }
        DateTimeOffset? LastUpdated { get; set; }
        DateTimeOffset? ExpiresAt { get; set; }
        
        ITokenEmbedded Embedded { get; set; }
    }
}