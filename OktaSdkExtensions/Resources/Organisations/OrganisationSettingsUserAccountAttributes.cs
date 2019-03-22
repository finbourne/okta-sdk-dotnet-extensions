using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationSettingsUserAccountAttributes : Resource, IOrganisationSettingsUserAccountAttributes
    {
        public bool? SecondaryEmail
        {
            get => GetBooleanProperty("secondaryEmail");
            set => this["secondaryEmail"] = value;
        }

        public bool? SecondaryImage
        {
            get => GetBooleanProperty("secondaryEmail");
            set => this["secondaryEmail"] = value; 
        }
    }
}