using System.Collections.Generic;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public interface ILocation
    {
        IList<string> StreetAddress { get; set; }
        string Locality { get; set; }
        string PostalCode { get; set; }
        string Country { get; set; }
    }
}