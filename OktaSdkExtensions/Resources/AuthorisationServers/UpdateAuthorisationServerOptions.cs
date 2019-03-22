using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class UpdateAuthorisationServerOptions : CreateAuthorisationServerOptions
    {
        public IAuthorisationServerCredentials Credentials
        {
            get => GetResourceProperty<AuthorisationServerCredentials>("credentials");
            set => this["credentials"] = value;
        }
    }
}