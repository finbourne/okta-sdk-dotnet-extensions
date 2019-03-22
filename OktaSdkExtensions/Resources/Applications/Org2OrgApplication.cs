using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class Org2OrgApplication : Application, IOrg2OrgApplication 
    {
        public new IApplicationCredentials Credentials
        {
            get => GetResourceProperty<ApplicationCredentials>("credentials");
            set => this["credentials"] = value;
        }
            
        public new IOrg2OrgApplicationVisibility Visibility
        {
            get => GetResourceProperty<Org2OrgApplicationVisibility>("visibility");
            set => this["visibility"] = value;
        }
            
        public new string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
            
        public new IOrg2OrgApplicationSettings Settings 
        {
            get => GetResourceProperty<Org2OrgApplicationSettings>("settings");
            set => this["settings"] = value;
        }
            
        public IOrg2OrgApplicationLinks Links 
        {
            get => GetResourceProperty<Org2OrgApplicationLinks>("_links");
            set => this["_links"] = value;
        }
            
    }
}