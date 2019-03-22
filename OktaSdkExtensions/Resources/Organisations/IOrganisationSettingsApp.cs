namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public interface IOrganisationSettingsApp
    {
        string ErrorRedirectUrl  { get; set; }
        string InterstitialUrl  { get; set; }
        int? InterstitialMinWaitTime { get; set; } 
    }
}