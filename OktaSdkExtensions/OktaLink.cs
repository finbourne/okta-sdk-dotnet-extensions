using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk
{
    public class OktaLink : Resource, IOktaLink 
    {
        public string Href 
        {
            get => GetStringProperty("href");
            set => this["href"] = value;
        }
            
        public string Type 
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
            
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
    }
}