using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public class SchemaCustomDefinitionSet : Resource, ISchemaCustomDefinitionSet
    {
        public ISchemaDefinition Custom
        {
            get => GetResourceProperty<SchemaDefinition>("custom");
            set => this["custom"] = value;
        }
    }
}