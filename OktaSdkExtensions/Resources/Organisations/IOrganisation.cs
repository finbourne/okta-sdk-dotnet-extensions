using System;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public interface IOrganisation
    {
        string Id { get; set; }
        string SubDomain { get; set; }
        string Name { get; set; }
        string Website { get; set; }
        string Status { get; set; }
        string Edition { get; set; }
        DateTimeOffset? ExpiresAt { get; set; }
        DateTimeOffset? Created { get; set; }
        DateTimeOffset? LastUpdated { get; set; }
        IOrganisationLicensing Licensing { get; set; }
        IOrganisationSettings Settings { get; set; }
    }
}