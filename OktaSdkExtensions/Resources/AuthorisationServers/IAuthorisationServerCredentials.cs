namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public interface IAuthorisationServerCredentials
    {
        IAuthorisationServerCredentialSigning Signing { get; set; }
    }
}