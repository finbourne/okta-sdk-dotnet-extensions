namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public interface IOrganisationSettings
    {
        IOrganisationSettingsApp App { get; set; }

        IOrganisationSettingsLogs Logs { get; set; }

        IOrganisationSettingsPortal Portal { get; set; }

        IOrganisationSettingsUserAccount UserAccount { get; set; }
    }
}