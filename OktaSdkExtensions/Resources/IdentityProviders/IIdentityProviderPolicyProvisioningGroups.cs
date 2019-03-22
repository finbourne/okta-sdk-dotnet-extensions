using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderPolicyProvisioningGroups : IResource
    {
        string Action { get; set; }
        IList<string> Assignments { get; set; }
    }
}