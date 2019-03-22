using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class Org2OrgApplicationVisibilityAppLinks : Resource, IOrg2OrgApplicationVisibilityAppLinks
    {
        public bool? Login 
        {
            get => GetBooleanProperty("login");
            set => this["login"] = value;
        }
    }
}