using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public interface IOrg2OrgApplication : IApplication
    {
        new IApplicationCredentials Credentials { get; set; }

        new string Name { get; set; }

        new IOrg2OrgApplicationSettings Settings { get; set; }
        
        IOrg2OrgApplicationLinks Links { get; set; }
    }
}