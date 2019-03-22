using System.Collections.Generic;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public interface IAuthorisationServersCondition 
    {
        IList<string> Include { get; set; }
        IList<string> Exclude { get; set; }
    }
}