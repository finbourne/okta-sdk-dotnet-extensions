namespace Finbourne.Extensions.Okta.Sdk.Resources.Tokens
{
    public interface ITokenEmbeddedUser
    {
        string Id { get; set; }
        string DisplayName { get; set; }
        string Login { get; set; }
        string Role { get; set; }
    }
}