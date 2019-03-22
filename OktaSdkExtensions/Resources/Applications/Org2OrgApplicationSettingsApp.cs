using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class Org2OrgApplicationSettingsApp : Resource, IOrg2OrgApplicationSettingsApp
    {
        public string BaseUrl
        {
            get => GetStringProperty("baseUrl");
            set => this["baseUrl"] = value;
        }

        public string AcsUrl 
        {
            get => GetStringProperty("acsUrl");
            set => this["acsUrl"] = value;
        }
        public string AudRestriction 
        {
            get => GetStringProperty("audRestriction");
            set => this["audRestriction"] = value;
        }
    }
}