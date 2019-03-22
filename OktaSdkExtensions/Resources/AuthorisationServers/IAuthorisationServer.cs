using System;
using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public interface IAuthorisationServer : IResource
    {
        string Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        IList<string> Audiences { get; set; }
        string Issuer { get; set; }
        string Status { get; set; }
        DateTimeOffset? Created { get; set; }
        DateTimeOffset? LastUpdated { get; set; }
        IAuthorisationServerCredentials Credentials { get; set; }
    }
}