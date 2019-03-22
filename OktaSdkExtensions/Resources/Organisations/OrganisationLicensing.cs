using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationLicensing : Resource, IOrganisationLicensing
    {
        /// <inheritdoc />
        public IList<string> Apps
        {
            get => GetArrayProperty<string>("apps");
            set => this["apps"] = value;
        }
    }
}