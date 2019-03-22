namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public interface IOrganisationPolicy
    {
        IOrganisationTokenLifetime TokenLifetime { get; set; }
        IOrganisationJitProvisioning JitProvisioning { get; set; }
        IOrganisationAccountRecovery AccountRecovery { get; set; }
        IOrganisationIdpSettings IdpSettings { get; set; }
        IOrganisationVisibility Visibility { get; set; }
    }
}