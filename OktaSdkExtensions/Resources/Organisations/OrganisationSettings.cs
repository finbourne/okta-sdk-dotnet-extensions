using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationSettings : Resource, IOrganisationSettings
    {
        public IOrganisationSettingsApp App
        {
            get => GetResourceProperty<OrganisationSettingsApp>("app");
            set => this["app"] = value;
        }

        public IOrganisationSettingsLogs Logs
        {
            get => GetResourceProperty<OrganisationSettingsLogs>("logs");
            set => this["logs"] = value;
        }

        public IOrganisationSettingsPortal Portal
        {
            get => GetResourceProperty<OrganisationSettingsPortal>("portal");
            set => this["portal"] = value;
        }

        public IOrganisationSettingsUserAccount UserAccount
        {
            get => GetResourceProperty<OrganisationSettingsUserAccount>("userAccount");
            set => this["userAccount"] = value;
        }
    }
}