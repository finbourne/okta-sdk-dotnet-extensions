using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public interface IOrg2OrgApplicationVisibilityAppLinks : IResource
    {
        bool? Login { get; set; }
    }
}