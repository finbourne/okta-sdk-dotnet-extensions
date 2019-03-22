namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class CreatedOrganisation : Organisation, ICreatedOrganisation
    {
        public string Token 
        { 
            get => GetStringProperty("token");
            set => this["token"] = value;
        }
        
        public string TokenType
        { 
            get => GetStringProperty("tokenType");
            set => this["tokenType"] = value;
        }
    }
}