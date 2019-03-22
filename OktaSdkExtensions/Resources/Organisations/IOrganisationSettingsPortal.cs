namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public interface IOrganisationSettingsPortal
    {
        string ErrorRedirectUrl  { get; set; }
        string SignOutUrl  { get; set; }
    }
}