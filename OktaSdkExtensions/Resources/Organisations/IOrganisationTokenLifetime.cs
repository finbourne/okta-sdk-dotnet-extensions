namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public interface IOrganisationTokenLifetime
    {
        int? IdleSession { get; set; }
        int? Activation { get; set; }
    }
}