using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class Org2OrgApplicationSettings : ApplicationSettings, IOrg2OrgApplicationSettings
    {
        public new IOrg2OrgApplicationSettingsApp App
        {
            get => GetResourceProperty<Org2OrgApplicationSettingsApp>("app");
            set => this["app"] = value;
        }

        public IOrg2OrgApplicationSettingsSignOn SignOn
        {
            get => GetResourceProperty<Org2OrgApplicationSettingsSignOn>("signOn");
            set => this["signOn"] = value;
        }
    }
}