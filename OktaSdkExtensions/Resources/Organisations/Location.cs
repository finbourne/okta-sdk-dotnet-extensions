using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class Location : Resource, ILocation
    {

        public IList<string> StreetAddress
        {
            get => GetArrayProperty<string>("streetAddress");
            set => this["streetAddress"] = value;
        }

        public string Locality
        {
            get => GetStringProperty("locality");
            set => this["locality"] = value;
        }

        public string PostalCode
        {
            get => GetStringProperty("postalCode");
            set => this["postalCode"] = value;
        }

        public string Country
        {
            get => GetStringProperty("country");
            set => this["country"] = value;
        }
    }
}