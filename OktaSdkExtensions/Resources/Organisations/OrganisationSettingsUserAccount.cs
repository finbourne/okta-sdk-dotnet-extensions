using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationSettingsUserAccount : Resource, IOrganisationSettingsUserAccount
    {
        public IOrganisationSettingsUserAccountAttributes Attributes
        {
            get => GetResourceProperty<OrganisationSettingsUserAccountAttributes>("attributes");
            set => this["attributes"] = value;
        }
    }
}