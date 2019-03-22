using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public interface IOrg2OrgApplicationSettings : IApplicationSettings
    {
        new IOrg2OrgApplicationSettingsApp App { get; set; }
        IOrg2OrgApplicationSettingsSignOn SignOn { get; set; }
    }
}