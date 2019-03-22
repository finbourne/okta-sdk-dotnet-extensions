namespace Finbourne.Extensions.Okta.Sdk.Resources.Tokens
{
    public interface IPopulatedToken : ITokenInfo
    {
        string Token { get; set; }
    }
}