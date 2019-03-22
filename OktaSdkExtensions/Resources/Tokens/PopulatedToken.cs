namespace Finbourne.Extensions.Okta.Sdk.Resources.Tokens
{
    public class PopulatedToken : TokenInfo, IPopulatedToken
    {
        public string Token 
        { 
            get => GetStringProperty("token");
            set => this["token"] = value;
        }
    }
}