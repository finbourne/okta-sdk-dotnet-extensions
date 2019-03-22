using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationContacts : Resource, IOrganisationContacts
    {
        public ILocation Organization
        {
            get => GetResourceProperty<Location>("organization");
            set => this["organization"] = value;
        }
        
        public IEndUserSupport Support
        {
            get => GetResourceProperty<EndUserSupport>("support");
            set => this["support"] = value;
        }
    }
}