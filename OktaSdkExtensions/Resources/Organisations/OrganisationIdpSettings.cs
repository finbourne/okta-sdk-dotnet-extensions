using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationIdpSettings : Resource, IOrganisationIdpSettings
    {
        public string DefaultIdp
        {
            get => GetStringProperty("defaultIdp");
            set => this["defaultIdp"] = value;
        }
    }
}