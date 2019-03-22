using System.Collections.Generic;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public interface IAuthorisationServerClaimCondition
    {
        IList<string> Scopes { get; set; }
    }
}