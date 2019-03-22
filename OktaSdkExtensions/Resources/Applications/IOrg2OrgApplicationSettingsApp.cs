using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public interface IOrg2OrgApplicationSettingsApp : IResource
    {
        string BaseUrl { get; set; }
        string AcsUrl { get; set; }
        string AudRestriction { get; set; }
    }
}