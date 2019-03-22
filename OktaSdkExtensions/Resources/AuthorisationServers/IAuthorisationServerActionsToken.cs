namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public interface IAuthorisationServerActionsToken
    {
        int? AccessTokenLifetimeMinutes { get; set; }
        int? RefreshTokenLifetimeMinutes { get; set; }
        int? RefreshTokenWindowMinutes { get; set; }
    }
}