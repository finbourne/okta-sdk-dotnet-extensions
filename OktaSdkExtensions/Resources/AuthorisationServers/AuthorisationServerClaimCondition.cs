using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class AuthorisationServerClaimCondition : Resource, IAuthorisationServerClaimCondition
    {
        public IList<string> Scopes
        {
            get => GetArrayProperty<string>("scopes");
            set => this["scopes"] = value;
        }
    }
}