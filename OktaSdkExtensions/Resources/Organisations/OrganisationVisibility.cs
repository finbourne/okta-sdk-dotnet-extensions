using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationVisibility : Resource, IOrganisationVisibility
    {
        public IOrganisationVisibilityHide Hide
        {
            get => GetResourceProperty<OrganisationVisibilityHide>("hide");
            set => this["hide"] = value;
        }
    }
}