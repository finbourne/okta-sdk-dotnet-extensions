using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationSettingsLogs: Resource, IOrganisationSettingsLogs
    {
        public string Level 
        { 
            get => GetStringProperty("level");
            set => this["level"] = value; }
    }
}