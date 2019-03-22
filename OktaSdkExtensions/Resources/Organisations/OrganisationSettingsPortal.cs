using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationSettingsPortal : Resource,IOrganisationSettingsPortal
    {
        public string ErrorRedirectUrl
        {
            get => GetStringProperty("errorRedirectUrl");
            set => this["errorRedirectUrl"] = value;
        }

        public string SignOutUrl
        {
            get => GetStringProperty("signOutUrl");
            set => this["signOutUrl"] = value;
        }
    }
}