using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public interface IOrg2OrgApplicationVisibility : IApplicationVisibility
    {
        IOrg2OrgApplicationVisibilityAppLinks AppLinks { get; set; }
    }
}