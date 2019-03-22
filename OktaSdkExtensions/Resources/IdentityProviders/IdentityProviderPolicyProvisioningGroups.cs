using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderPolicyProvisioningGroups : Resource, IIdentityProviderPolicyProvisioningGroups 
    {
        public string Action 
        {
            get => GetStringProperty("action");
            set => this["action"] = value;
        }

        public IList<string> Assignments 
        {
            get => GetArrayProperty<string>("assignments");
            set => this["assignments"] = value;
        }
    }
}