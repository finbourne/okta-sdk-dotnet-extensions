using System.Collections.Generic;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public interface IOrganisationLicensing
    {
        IList<string> Apps { get; set; }
    }
}