using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public class SchemaDefinitionMaster : Resource, ISchemaDefinitionMaster
    {
        public string Type
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
    }
}