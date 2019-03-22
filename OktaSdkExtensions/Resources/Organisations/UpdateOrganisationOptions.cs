using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class UpdateOrganisationOptions : Resource
    {
        /// <summary>
        /// The display name of the new organisation
        /// </summary>
        public string Name
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }

        /// <summary>
        /// The website of the company that owns the new org
        /// </summary>
        public string Website
        {
            get => GetStringProperty("website");
            set => this["website"] = value;
        }

        /// <summary>
        /// The Okta licence level of the org
        /// </summary>
        public string Edition
        {
            get => GetStringProperty("edition");
            set => this["edition"] = value;
        }

        /// <summary>
        /// Any licensing provisions related to the new org
        /// </summary>
        public IOrganisationLicensing Licensing
        {
            get => GetResourceProperty<OrganisationLicensing>("licensing");
            set => this["licensing"] = value;
        }

        /// <summary>
        /// The details of the user admin of the new org
        /// </summary>
        public IUser Admin
        {
            get => GetResourceProperty<User>("admin");
            set => this["admin"] = value;
        }
    }
}